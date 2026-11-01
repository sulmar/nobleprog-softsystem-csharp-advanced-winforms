namespace Lims.Problem
{
    /// <summary>Wynik badania. Obiekt niezmienny, więc korekta tworzy nowy obiekt.</summary>
    internal class TestResult
    {
        public TestResult(string sampleCode, string patientCode, string analyte, decimal value, string unit)
        {
            SampleCode = sampleCode;
            PatientCode = patientCode;
            Analyte = analyte;
            Value = value;
            Unit = unit;
        }

        public string SampleCode { get; }
        public string PatientCode { get; }
        public string Analyte { get; }
        public decimal Value { get; }
        public string Unit { get; }

        public TestResult WithValue(decimal value)
        {
            return new TestResult(SampleCode, PatientCode, Analyte, value, Unit);
        }
    }
}
