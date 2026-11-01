using System;

namespace Vendor.SmsBox
{
    // Biblioteka obecnego operatora. Nie wolno jej zmieniać.
    public sealed class SmsBoxClient
    {
        private readonly string _account;

        public SmsBoxClient(string account)
        {
            _account = account;
        }

        // Numer: dokładnie 9 cyfr, np. 600100200. Treść: najwyżej 160 znaków.
        // Odpowiedź: "OK:<numer wiadomości>" albo jeden z kodów:
        // "ERR:21" numer odrzucony, "ERR:22" za długa treść, "ERR:50" usługa niedostępna.
        public string Send(string msisdn, string text)
        {
            if (SmsBoxSandbox.IsDown(_account))
            {
                return "ERR:50";
            }

            if (msisdn == null || msisdn.Length != 9 || !IsDigitsOnly(msisdn) || SmsBoxSandbox.IsRejected(_account, msisdn))
            {
                return "ERR:21";
            }

            if (text == null || text.Length > 160)
            {
                return "ERR:22";
            }

            SmsBoxSandbox.Record(_account, msisdn, text);
            return "OK:" + Guid.NewGuid().ToString("N");
        }

        private static bool IsDigitsOnly(string value)
        {
            foreach (var character in value)
            {
                if (character < '0' || character > '9')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
