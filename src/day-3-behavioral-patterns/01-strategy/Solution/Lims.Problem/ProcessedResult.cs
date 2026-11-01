using System.Collections.Generic;

namespace Lims.Problem
{
    public enum ResultFlag
    {
        Normal,
        Low,
        High
    }

    public class ProcessedResult
    {
        public List<string> Errors { get; } = new List<string>();

        public decimal Value { get; set; }

        public string Unit { get; set; }

        public decimal Low { get; set; }

        public decimal High { get; set; }

        public ResultFlag Flag { get; set; }
    }
}
