using System.Collections.Concurrent;
using System.Globalization;

namespace Vendor.Hemolab
{
    // Część symulacji szkoleniowej: zastępuje fizyczne urządzenie stojące na stole.
    // W prawdziwej bibliotece producenta tej klasy nie ma. Bez wywołania PowerOn urządzenia po prostu nie ma.
    public static class HemolabBench
    {
        private static readonly ConcurrentDictionary<string, LoadedSample> Samples = new ConcurrentDictionary<string, LoadedSample>();
        private static readonly ConcurrentDictionary<string, bool> Busy = new ConcurrentDictionary<string, bool>();
        private static readonly ConcurrentDictionary<string, bool> PoweredOn = new ConcurrentDictionary<string, bool>();

        public static void PowerOn(string port)
        {
            PoweredOn[port] = true;
        }

        public static void LoadSample(string port, string sampleId, decimal value, string unit = "mmol/L")
        {
            Samples[Key(port, sampleId)] = new LoadedSample(value.ToString(CultureInfo.InvariantCulture), unit);
        }

        public static void BusyOnSample(string port, string sampleId)
        {
            Busy[Key(port, sampleId)] = true;
        }

        internal static bool IsPoweredOn(string port)
        {
            return port != null && PoweredOn.ContainsKey(port);
        }

        internal static bool IsBusyFor(string port, string sampleId)
        {
            return Busy.ContainsKey(Key(port, sampleId));
        }

        internal static bool TryGetSample(string port, string sampleId, out LoadedSample sample)
        {
            return Samples.TryGetValue(Key(port, sampleId), out sample);
        }

        private static string Key(string port, string sampleId)
        {
            return port + "/" + sampleId;
        }

        internal sealed class LoadedSample
        {
            public LoadedSample(string value, string unit)
            {
                Value = value;
                Unit = unit;
            }

            public string Value { get; }

            public string Unit { get; }
        }
    }
}
