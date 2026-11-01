using System;

namespace Vendor.Chemtron
{
    public enum ChemtronStatus
    {
        LinkDown,
        Busy
    }

    public class ChemtronException : Exception
    {
        public ChemtronException(ChemtronStatus status, string message) : base(message)
        {
            Status = status;
        }

        public ChemtronStatus Status { get; }
    }
}
