using System.Collections.Concurrent;
using System.Globalization;

namespace Vendor.Chemtron
{
    // Część symulacji szkoleniowej: zastępuje fizyczny analizator.
    // W prawdziwej bibliotece producenta tej klasy nie ma.
    public static class ChemtronBench
    {
        private static readonly ConcurrentDictionary<string, LoadedSample> Samples = new ConcurrentDictionary<string, LoadedSample>();
        private static readonly ConcurrentDictionary<string, bool> Busy = new ConcurrentDictionary<string, bool>();
        private static readonly ConcurrentDictionary<string, bool> PoweredOn = new ConcurrentDictionary<string, bool>();

        public static void PowerOn(string address)
        {
            PoweredOn[address] = true;
        }

        public static void LoadSample(string address, string specimen, decimal value, string unit = "mg/dL")
        {
            Samples[Key(address, specimen)] = new LoadedSample(value.ToString(CultureInfo.InvariantCulture), unit);
        }

        public static void BusyOnSample(string address, string specimen)
        {
            Busy[Key(address, specimen)] = true;
        }

        internal static bool IsPoweredOn(string address)
        {
            return address != null && PoweredOn.ContainsKey(address);
        }

        internal static bool IsBusyFor(string address, string specimen)
        {
            return Busy.ContainsKey(Key(address, specimen));
        }

        internal static bool TryGetSample(string address, string specimen, out LoadedSample sample)
        {
            return Samples.TryGetValue(Key(address, specimen), out sample);
        }

        private static string Key(string address, string specimen)
        {
            return address + "/" + specimen;
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
