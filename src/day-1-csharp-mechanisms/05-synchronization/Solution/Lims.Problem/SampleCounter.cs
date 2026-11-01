namespace Lims.Problem
{
    internal class SampleCounter
    {
        public int Count { get; private set; }

        public void Add()
        {
            // TODO: naprawić błąd: zabezpieczyć zwiększanie licznika.
            // PROBLEM: Count++ to trzy kroki: odczyt, zwiększenie i zapis. Dwa wątki mogą odczytać
            // tę samą wartość, więc jedno zwiększenie przepada i licznik pokazuje za mało próbek.
            Count++;
        }
    }
}
