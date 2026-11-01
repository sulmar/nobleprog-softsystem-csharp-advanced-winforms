using System;

namespace Lims.Problem
{
    internal class UserAccount
    {
        public UserAccount(string name, bool canReadResults, bool canCorrectResults)
        {
            Name = name;
            CanReadResults = canReadResults;
            CanCorrectResults = canCorrectResults;
        }

        public string Name { get; }
        public bool CanReadResults { get; }
        public bool CanCorrectResults { get; }

        public override string ToString()
        {
            return Name;
        }
    }

    /// <summary>Konta fikcyjnych pracowników laboratorium.</summary>
    internal static class UserAccounts
    {
        public static readonly UserAccount Diagnostician = new UserAccount("Anna Kowalska (diagnosta)", true, true);
        public static readonly UserAccount Technician = new UserAccount("Tomasz Wiśniewski (technik)", true, false);
        public static readonly UserAccount Registrar = new UserAccount("Ewa Lis (rejestracja)", false, false);
    }

    // TODO: refaktoryzacja: przekazać bieżącego użytkownika jako zależność.
    // PROBLEM: statyczny stan widoczny w całej aplikacji. Test musi go ustawiać i pamiętać o nim,
    // a serwis nie mówi w konstruktorze, że potrzebuje użytkownika (DIP).
    internal static class Session
    {
        public static UserAccount CurrentUser = UserAccounts.Diagnostician;
    }

    internal class AccessDeniedException : Exception
    {
        public AccessDeniedException(string userName, string operation)
            : base("Użytkownik " + userName + " nie ma uprawnień do operacji: " + operation)
        {
        }
    }
}
