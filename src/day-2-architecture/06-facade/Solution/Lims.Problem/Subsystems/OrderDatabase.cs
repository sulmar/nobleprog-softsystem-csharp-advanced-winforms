using System;
using System.Collections.Generic;
using System.Linq;

namespace Lims.Problem
{
    public sealed class OrderDatabase
    {
        private readonly LabJournal _journal;
        private readonly List<Order> _orders = new List<Order>
        {
            new Order { Code = "Z-1001", PatientName = "Jan Testowy", PatientPhone = "+48 500 000 001", Analyte = "Glukoza", Clinic = "Przychodnia Północ", Price = 12m },
            new Order { Code = "Z-1002", PatientName = "Anna Przykładowa", PatientPhone = "+48 500 000 002", Analyte = "Morfologia", Clinic = "Przychodnia Północ", Price = 50m, IsUrgent = true },
            new Order { Code = "Z-1003", PatientName = "Piotr Fikcyjny", PatientPhone = "+48 500 000 003", Analyte = "Hemoglobina", Clinic = "Przychodnia Południe", Price = 18m },
            new Order { Code = "Z-1004", PatientName = "Ewa Testowa", PatientPhone = "+48 500 000 004", Analyte = "Glukoza", Clinic = "Przychodnia Południe", Price = 24m, IsUrgent = true },
            new Order { Code = "Z-1005", PatientName = "Adam Próbny", PatientPhone = "+48 500 000 005", Analyte = "Morfologia", Clinic = "Przychodnia Północ", Price = 25m },
            new Order { Code = "Z-1006", PatientName = "Maria Wzorcowa", PatientPhone = "+48 500 000 006", Analyte = "Hemoglobina", Clinic = "Przychodnia Północ", Price = 18m }
        };

        public OrderDatabase(LabJournal journal)
        {
            _journal = journal;
        }

        public Order Find(string code)
        {
            return _orders.FirstOrDefault(order => order.Code == code);
        }

        public IReadOnlyList<Order> All()
        {
            return _orders;
        }

        public void MarkApproved(string code, string approver, DateTime at)
        {
            var order = Find(code);
            order.Status = OrderStatus.Approved;
            order.ApprovedBy = approver;
            order.ApprovedAt = at;
            _journal.Add("Zapis: " + code + " zatwierdził " + approver);
        }

        public void RevertApproval(string code)
        {
            var order = Find(code);
            order.Status = OrderStatus.Pending;
            order.ApprovedBy = null;
            order.ApprovedAt = null;
            _journal.Add("Cofnięcie zapisu: " + code);
        }
    }
}
