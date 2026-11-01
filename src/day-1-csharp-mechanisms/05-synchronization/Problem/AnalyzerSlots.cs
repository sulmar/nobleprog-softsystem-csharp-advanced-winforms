using System.Threading;

namespace Lims.Problem
{
    internal class AnalyzerSlots
    {
        private int _free;

        public AnalyzerSlots(int capacity)
        {
            _free = capacity;
        }

        public int Free
        {
            get { return _free; }
        }

        public bool TryReserve()
        {
            // TODO: naprawić błąd: sprawdzenie i rezerwacja muszą być jedną operacją.
            // PROBLEM: między sprawdzeniem a zmniejszeniem inny wątek może zająć to samo miejsce,
            // więc analizator dostaje więcej próbek, niż ma miejsc.
            if (_free > 0)
            {
                // Symulacja zapisu rezerwacji w systemie. Poszerza okno, w którym dochodzi do błędu.
                Thread.Sleep(1);
                _free--;
                return true;
            }

            return false;
        }
    }
}
