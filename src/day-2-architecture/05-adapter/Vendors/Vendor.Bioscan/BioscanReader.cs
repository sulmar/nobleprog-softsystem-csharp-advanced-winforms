using System.Threading;

namespace Vendor.Bioscan
{
    public static class BioscanStatus
    {
        public const int Ok = 0;
        public const int NoDevice = -1;
        public const int BarcodeUnknown = 2;
        public const int Busy = 3;
    }

    // Biblioteka zewnętrzna producenta Bioscan. Nie wolno jej zmieniać.
    // Nie zgłasza wyjątków: zwraca kod statusu, a wynik w gramach na litr przez parametr out.
    public sealed class BioscanReader
    {
        private readonly int _channel;

        public BioscanReader(int channel)
        {
            _channel = channel;
        }

        public int Measure(string barcode, out double gramsPerLiter)
        {
            Thread.Sleep(100);

            gramsPerLiter = 0;

            if (!BioscanBench.IsPoweredOn(_channel))
            {
                return BioscanStatus.NoDevice;
            }

            if (BioscanBench.IsBusyFor(_channel, barcode))
            {
                return BioscanStatus.Busy;
            }

            return BioscanBench.TryGetSample(_channel, barcode, out gramsPerLiter)
                ? BioscanStatus.Ok
                : BioscanStatus.BarcodeUnknown;
        }
    }
}
