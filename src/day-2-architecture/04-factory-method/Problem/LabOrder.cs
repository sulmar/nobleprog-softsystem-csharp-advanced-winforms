using System.Collections.Generic;

namespace Lims.Problem
{
    public enum TestType
    {
        Blood,
        Urine,
        Microbiology
    }

    public enum OrderStatus
    {
        New,
        ResultsEntered,
        AwaitingVerification
    }

    public class ResultValue
    {
        public ResultValue(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }

        public string Value { get; }
    }

    public class LabOrder
    {
        private static readonly Dictionary<TestType, string> TestNames = new Dictionary<TestType, string>
        {
            { TestType.Blood, "Krew" },
            { TestType.Urine, "Mocz" },
            { TestType.Microbiology, "Mikrobiologia" }
        };

        private static readonly Dictionary<OrderStatus, string> StatusNames = new Dictionary<OrderStatus, string>
        {
            { OrderStatus.New, "Nowe" },
            { OrderStatus.ResultsEntered, "Wyniki wprowadzone" },
            { OrderStatus.AwaitingVerification, "Czeka na weryfikację" }
        };

        private readonly List<ResultValue> _results = new List<ResultValue>();

        public LabOrder(string code, string patientName, TestType testType)
        {
            Code = code;
            PatientName = patientName;
            TestType = testType;
            Status = OrderStatus.New;
        }

        public string Code { get; }

        public string PatientName { get; }

        public TestType TestType { get; }

        public OrderStatus Status { get; private set; }

        public IReadOnlyList<ResultValue> Results
        {
            get { return _results; }
        }

        public string TestName
        {
            get { return TestNames[TestType]; }
        }

        public string StatusName
        {
            get { return StatusNames[Status]; }
        }

        public void RecordResults(IEnumerable<ResultValue> values, OrderStatus status)
        {
            _results.Clear();
            _results.AddRange(values);
            Status = status;
        }
    }
}
