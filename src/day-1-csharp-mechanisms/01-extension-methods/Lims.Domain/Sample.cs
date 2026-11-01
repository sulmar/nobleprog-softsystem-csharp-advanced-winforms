using System;

namespace Lims.Domain
{
    public enum SampleStatus
    {
        Registered,
        InAnalysis,
        Approved,
        Rejected
    }

    /// <summary>Próbka zarejestrowana w laboratorium.</summary>
    public class Sample
    {
        public string Code { get; set; }
        public string Material { get; set; }
        public SampleStatus Status { get; set; }
        public DateTime DueAt { get; set; }
    }
}
