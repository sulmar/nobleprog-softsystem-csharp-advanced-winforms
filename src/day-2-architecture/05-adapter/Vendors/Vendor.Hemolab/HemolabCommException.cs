using System;

namespace Vendor.Hemolab
{
    // Producent zgłasza każdy błąd tym samym wyjątkiem. Rozróżnia je tylko numer.
    public class HemolabCommException : Exception
    {
        public HemolabCommException(int errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public int ErrorCode { get; }
    }

    public static class HemolabErrors
    {
        public const int NoDevice = 101;
        public const int NotConnected = 102;
        public const int SampleUnknown = 204;
        public const int DeviceBusy = 301;
    }
}
