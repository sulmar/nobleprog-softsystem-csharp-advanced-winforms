namespace Lims.Domain
{
    /// <summary>Wynik pojedynczego oznaczenia wraz z zakresem referencyjnym.</summary>
    public class TestResult
    {
        public string SampleCode { get; set; }
        public string Analyte { get; set; }
        public decimal Value { get; set; }
        public string Unit { get; set; }
        public decimal ReferenceLow { get; set; }
        public decimal ReferenceHigh { get; set; }
    }
}
