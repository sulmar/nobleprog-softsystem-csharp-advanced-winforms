using System.Collections.Concurrent;

namespace Vendor.Bioscan
{
    // Część symulacji szkoleniowej: zastępuje fizyczny czytnik.
    // W prawdziwej bibliotece producenta tej klasy nie ma.
    public static class BioscanBench
    {
        private static readonly ConcurrentDictionary<string, double> Samples = new ConcurrentDictionary<string, double>();
        private static readonly ConcurrentDictionary<string, bool> Busy = new ConcurrentDictionary<string, bool>();
        private static readonly ConcurrentDictionary<int, bool> PoweredOn = new ConcurrentDictionary<int, bool>();

        public static void PowerOn(int channel)
        {
            PoweredOn[channel] = true;
        }

        public static void LoadSample(int channel, string barcode, double gramsPerLiter)
        {
            Samples[Key(channel, barcode)] = gramsPerLiter;
        }

        public static void BusyOnSample(int channel, string barcode)
        {
            Busy[Key(channel, barcode)] = true;
        }

        internal static bool IsPoweredOn(int channel)
        {
            return PoweredOn.ContainsKey(channel);
        }

        internal static bool IsBusyFor(int channel, string barcode)
        {
            return Busy.ContainsKey(Key(channel, barcode));
        }

        internal static bool TryGetSample(int channel, string barcode, out double gramsPerLiter)
        {
            return Samples.TryGetValue(Key(channel, barcode), out gramsPerLiter);
        }

        private static string Key(int channel, string barcode)
        {
            return channel + "/" + barcode;
        }
    }
}
