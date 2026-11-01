using System;
using System.Collections.Generic;

namespace Lims.Problem
{
    // TODO: refaktoryzacja: usunąć. Klasy deklarują, czego potrzebują, w konstruktorze.
    // PROBLEM: pierwsza próba porządków. Zniknęły `new`, ale zależności nadal są ukryte: z sygnatury
    // klasy nic nie wynika, a brak rejestracji wychodzi dopiero podczas działania (DIP).
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> Services = new Dictionary<Type, object>();

        public static void Register<T>(T service)
        {
            Services[typeof(T)] = service;
        }

        public static T Get<T>()
        {
            object service;
            if (!Services.TryGetValue(typeof(T), out service))
            {
                throw new InvalidOperationException("Nie zarejestrowano usługi: " + typeof(T).Name);
            }

            return (T)service;
        }
    }
}
