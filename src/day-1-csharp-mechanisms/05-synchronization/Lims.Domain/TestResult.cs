namespace Lims.Domain
{
    /// <summary>Wynik badania pojedynczej próbki.</summary>
    public class TestResult
    {
        public string SampleCode { get; set; }
        public string Analyte { get; set; }
        public decimal Value { get; set; }
    }
}
