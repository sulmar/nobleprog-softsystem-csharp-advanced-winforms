using System;
using System.Collections.Generic;
using System.IO;

namespace Lims.Problem
{
    // TODO: refaktoryzacja: zostawić tu tylko pobieranie i korektę wyniku, a resztę wydzielić.
    // PROBLEM: jedna klasa odpowiada za wyniki, logowanie, cache i uprawnienia (SRP). Każde nowe
    // wymaganie wokół serwisu to zmiana tych samych metod (OCP), a żadnego z tych działań nie da się
    // wyłączyć ani sprawdzić osobno. Automat nocny nie potrzebuje cache, ale nie ma jak z niego zrezygnować.
    internal class ResultService
    {
        public const string LogPath = "operations.log";

        private static readonly TimeSpan CacheLifetime = TimeSpan.FromMinutes(5);

        private readonly Dictionary<string, TestResult> _cachedResults = new Dictionary<string, TestResult>();
        private readonly Dictionary<string, DateTime> _cachedAt = new Dictionary<string, DateTime>();

        public TestResult GetResult(string sampleCode)
        {
            // TODO: refaktoryzacja: najpierw sprawdzić uprawnienia, a dopiero potem zaglądać do cache.
            // PROBLEM: „dla szybkości” cache jest sprawdzany jako pierwszy. Rejestratorka bez uprawnień
            // dostanie wynik, jeśli wcześniej otworzył go diagnosta.
            // PROBLEM: wyjście z metody przed logowaniem. Odczyt z cache nie zostawia śladu w logu,
            // więc nawet nie wiadomo, kto zobaczył dane pacjenta.
            TestResult cached;
            if (_cachedResults.TryGetValue(sampleCode, out cached)
                && DateTime.Now - _cachedAt[sampleCode] < CacheLifetime)
            {
                return cached;
            }

            // TODO: refaktoryzacja: wydzielić sprawdzanie uprawnień, a użytkownika przekazać jako zależność.
            // PROBLEM: statyczna sesja (DIP) i powtórzony schemat sprawdzenia w każdej metodzie (DRY).
            var user = Session.CurrentUser;
            if (!user.CanReadResults)
            {
                WriteLog(user.Name, "GetResult " + sampleCode, "Odmowa");
                throw new AccessDeniedException(user.Name, "odczyt wyniku");
            }

            var result = Database.Find(sampleCode);

            // TODO: refaktoryzacja: wydzielić cache, a czas przekazać jako zależność.
            // PROBLEM: DateTime.Now uniemożliwia sprawdzenie wygasania testem bez czekania 5 minut.
            if (result != null)
            {
                _cachedResults[sampleCode] = result;
                _cachedAt[sampleCode] = DateTime.Now;
            }

            WriteLog(user.Name, "GetResult " + sampleCode, result == null ? "Brak wyniku" : "OK");
            return result;
        }

        public void CorrectResult(string sampleCode, decimal newValue)
        {
            var user = Session.CurrentUser;
            if (!user.CanCorrectResults)
            {
                WriteLog(user.Name, "CorrectResult " + sampleCode, "Odmowa");
                throw new AccessDeniedException(user.Name, "korekta wyniku");
            }

            Database.UpdateValue(sampleCode, newValue);

            // TODO: refaktoryzacja: po korekcie usunąć wynik z cache.
            // PROBLEM: tej linii tu nie ma, bo cache jest rozsiany po klasie i łatwo o nim zapomnieć.
            // Przez 5 minut po korekcie wszyscy widzą starą wartość.
            WriteLog(user.Name, "CorrectResult " + sampleCode, "OK");
        }

        // TODO: refaktoryzacja: wydzielić logowanie, a miejsce zapisu ukryć za interfejsem.
        // PROBLEM: każde wywołanie serwisu, także w teście, dopisuje do pliku (DIP).
        // Błąd bazy w ogóle nie trafia do logu, bo wyjątek omija WriteLog.
        private static void WriteLog(string userName, string operation, string outcome)
        {
            File.AppendAllText(
                LogPath,
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " | " + userName + " | " + operation + " | " + outcome + Environment.NewLine);
        }
    }
}
