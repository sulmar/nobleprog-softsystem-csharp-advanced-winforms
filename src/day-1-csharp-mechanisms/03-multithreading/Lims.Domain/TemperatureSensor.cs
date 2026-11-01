using System.Threading;

namespace Lims.Domain
{
    /// <summary>Symulacja czujnika temperatury w lodówce z odczynnikami. Odczyt trwa około sekundy.</summary>
    public class TemperatureSensor
    {
        private const int ReadMilliseconds = 1000;

        private static readonly decimal[] Readings = { 4.1m, 4.3m, 4.6m, 5.0m, 5.4m, 5.1m, 4.7m, 4.2m, 3.9m, 3.8m };

        private int _index;

        public decimal Read()
        {
            Thread.Sleep(ReadMilliseconds);

            var reading = Readings[_index];
            _index = (_index + 1) % Readings.Length;
            return reading;
        }
    }
}
