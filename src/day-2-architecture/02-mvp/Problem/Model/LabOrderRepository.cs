using System.Collections.Generic;
using System.Linq;

namespace Lims.Problem.Model
{
    public interface ILabOrderRepository
    {
        LabOrder Find(string code);
        IReadOnlyList<LabOrder> All();
        void Update(LabOrder order);
    }

    /// <summary>Symulacja bazy. Zwraca kopie, więc zmiana bez zapisu nie trafia do magazynu.</summary>
    public class InMemoryLabOrderRepository : ILabOrderRepository
    {
        private readonly List<LabOrder> _orders;

        public InMemoryLabOrderRepository(params LabOrder[] orders)
        {
            _orders = orders.Select(order => order.Copy()).ToList();
        }

        public static InMemoryLabOrderRepository WithSampleData()
        {
            return new InMemoryLabOrderRepository(
                new LabOrder { Code = "Z-2026-000101", PatientName = "Anna Testowa", Analyte = "Glukoza", Priority = OrderPriority.Normal, Physician = "Jan Przykładowy", Notes = "", Status = OrderStatus.New },
                new LabOrder { Code = "Z-2026-000102", PatientName = "Piotr Fikcyjny", Analyte = "Hemoglobina", Priority = OrderPriority.Urgent, Physician = "Ewa Wzorcowa", Notes = "", Status = OrderStatus.InProgress },
                new LabOrder { Code = "Z-2026-000103", PatientName = "Maria Przykładowa", Analyte = "Morfologia", Priority = OrderPriority.Immediate, Physician = "Jan Przykładowy", Notes = "Oddział intensywnej terapii", Status = OrderStatus.Completed },
                new LabOrder { Code = "Z-2026-000104", PatientName = "Adam Testowy", Analyte = "Glukoza", Priority = OrderPriority.Normal, Physician = "Ewa Wzorcowa", Notes = "", Status = OrderStatus.Cancelled });
        }

        public LabOrder Find(string code)
        {
            var order = _orders.FirstOrDefault(candidate => candidate.Code == code);
            return order == null ? null : order.Copy();
        }

        public IReadOnlyList<LabOrder> All()
        {
            return _orders.Select(order => order.Copy()).ToList();
        }

        public void Update(LabOrder order)
        {
            var index = _orders.FindIndex(candidate => candidate.Code == order.Code);
            _orders[index] = order.Copy();
        }
    }
}
