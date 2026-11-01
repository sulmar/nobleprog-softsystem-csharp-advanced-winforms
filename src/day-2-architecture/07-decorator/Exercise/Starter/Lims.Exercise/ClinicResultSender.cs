using System;

namespace Lims.Exercise
{
    /// <summary>Wynik badania przygotowany do wysłania do przychodni.</summary>
    public class ResultMessage
    {
        public ResultMessage(string sampleCode, string clinicCode, string content)
        {
            SampleCode = sampleCode;
            ClinicCode = clinicCode;
            Content = content;
        }

        public string SampleCode { get; }
        public string ClinicCode { get; }
        public string Content { get; }
    }

    /// <summary>Przychodnia chwilowo nie odpowiada. Później może się udać.</summary>
    public class ClinicUnavailableException : Exception
    {
        public ClinicUnavailableException(string clinicCode)
            : base("Przychodnia " + clinicCode + " chwilowo nie odpowiada")
        {
        }
    }

    /// <summary>Przychodnia odrzuciła wynik, np. przez błędne dane. Powtórzenie niczego nie zmieni.</summary>
    public class ClinicRejectedException : Exception
    {
        public ClinicRejectedException(string clinicCode, string reason)
            : base("Przychodnia " + clinicCode + " odrzuciła wynik: " + reason)
        {
        }
    }

    /// <summary>Z tego interfejsu korzystają już okno wysyłki i automat nocny.</summary>
    public interface IResultSender
    {
        /// <summary>Wysyła wynik albo zgłasza wyjątek, gdy się nie udało.</summary>
        void Send(ResultMessage message);
    }

    /// <summary>
    /// Działająca wysyłka do przychodni. Tej klasy nie wolno zmieniać.
    /// Na szkoleniu symuluje połączenie: co trzecia próba trafia na niedostępną przychodnię.
    /// </summary>
    public class ClinicResultSender : IResultSender
    {
        private int _attempts;

        public void Send(ResultMessage message)
        {
            _attempts++;
            if (_attempts % 3 == 0)
            {
                throw new ClinicUnavailableException(message.ClinicCode);
            }

            if (string.IsNullOrWhiteSpace(message.Content))
            {
                throw new ClinicRejectedException(message.ClinicCode, "pusta treść");
            }
        }
    }
}
