using System.Collections.Generic;
using Lims.Domain;

namespace Lims.Problem
{
    internal class ResultCollector
    {
        // TODO: naprawić błąd: użyć kolekcji bezpiecznej przy pracy wielu wątków.
        // PROBLEM: List<T> nie jest bezpieczna wątkowo. Równoległe Add gubi elementy
        // albo zgłasza wyjątek przy powiększaniu wewnętrznej tablicy.
        private readonly List<TestResult> _results = new List<TestResult>();

        public int Count
        {
            get { return _results.Count; }
        }

        public void Add(TestResult result)
        {
            _results.Add(result);
        }
    }
}
