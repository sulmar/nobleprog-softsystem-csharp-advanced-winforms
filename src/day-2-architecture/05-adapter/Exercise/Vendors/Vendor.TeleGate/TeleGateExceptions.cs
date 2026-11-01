using System;

namespace Vendor.TeleGate
{
    public class TeleGateRejectedException : Exception
    {
        public TeleGateRejectedException(string reasonCode, string message) : base(message)
        {
            ReasonCode = reasonCode;
        }

        // RECIPIENT_FORMAT, BODY_CHARSET albo BODY_TOO_LONG.
        public string ReasonCode { get; }
    }

    public class TeleGateUnavailableException : Exception
    {
        public TeleGateUnavailableException(string message) : base(message)
        {
        }
    }
}
