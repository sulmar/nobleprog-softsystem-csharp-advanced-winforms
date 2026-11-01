using System;
using System.Collections.Generic;
using System.IO;

namespace Lims.Problem
{
    // Druga próba rozwiązania problemu: każdą kombinację działań opisuje osobna klasa pochodna.
    // Ten kod nie jest używany przez okno. Służy do porównania w Demo 2.

    internal class BasicResultService
    {
        public virtual TestResult GetResult(string sampleCode)
        {
            return Database.Find(sampleCode);
        }

        public virtual void CorrectResult(string sampleCode, decimal newValue)
        {
            Database.UpdateValue(sampleCode, newValue);
        }
    }

    internal class AuditedResultService : BasicResultService
    {
        public override TestResult GetResult(string sampleCode)
        {
            var result = base.GetResult(sampleCode);
            File.AppendAllText(ResultService.LogPath, "GetResult " + sampleCode + Environment.NewLine);
            return result;
        }
    }

    internal class CachedResultService : BasicResultService
    {
        private readonly Dictionary<string, TestResult> _cache = new Dictionary<string, TestResult>();

        public override TestResult GetResult(string sampleCode)
        {
            TestResult cached;
            if (_cache.TryGetValue(sampleCode, out cached))
            {
                return cached;
            }

            var result = base.GetResult(sampleCode);
            _cache[sampleCode] = result;
            return result;
        }
    }

    // TODO: refaktoryzacja: zastąpić kombinacje klas składaniem niezależnych elementów.
    // PROBLEM: C# nie ma wielokrotnego dziedziczenia klas, więc cache trzeba skopiować z CachedResultService (DRY).
    // PROBLEM: logowanie jest w klasie bazowej, czyli pod cache, więc odczyt z cache nie trafia do logu.
    // Odwrotnej kolejności nie da się uzyskać bez kolejnej klasy.
    internal class CachedAuditedResultService : AuditedResultService
    {
        private readonly Dictionary<string, TestResult> _cache = new Dictionary<string, TestResult>();

        public override TestResult GetResult(string sampleCode)
        {
            TestResult cached;
            if (_cache.TryGetValue(sampleCode, out cached))
            {
                return cached;
            }

            var result = base.GetResult(sampleCode);
            _cache[sampleCode] = result;
            return result;
        }
    }

    // TODO: refaktoryzacja: uprawnienia jako osobny, niezależny element.
    // PROBLEM: trzy działania to 8 zestawów, a przy każdym działaniu dochodzi jeszcze kolejność (OCP).
    // Brakuje SecuredResultService, SecuredAuditedResultService i SecuredCachedResultService.
    // Kolejność jest zapisana w drzewie dziedziczenia, a klasy bazowej nie da się podmienić, więc test
    // cache nadal uruchamia bazę z Database.
    internal class SecuredCachedAuditedResultService : CachedAuditedResultService
    {
        public override TestResult GetResult(string sampleCode)
        {
            var user = Session.CurrentUser;
            if (!user.CanReadResults)
            {
                throw new AccessDeniedException(user.Name, "odczyt wyniku");
            }

            return base.GetResult(sampleCode);
        }
    }
}
