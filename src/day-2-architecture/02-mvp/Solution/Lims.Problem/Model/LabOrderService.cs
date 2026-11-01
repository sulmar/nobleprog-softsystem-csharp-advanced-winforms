using System;
using System.Collections.Generic;

namespace Lims.Problem.Model
{
    /// <summary>Przypadki użycia zlecenia. Ta część jest już wydzielona: to efekt podziału na warstwy z poprzedniego modułu.</summary>
    public class LabOrderService
    {
        private readonly ILabOrderRepository _orders;

        public LabOrderService(ILabOrderRepository orders)
        {
            if (orders == null) throw new ArgumentNullException(nameof(orders));

            _orders = orders;
        }

        public IReadOnlyList<LabOrder> All()
        {
            return _orders.All();
        }

        public LabOrder Find(string code)
        {
            return _orders.Find(code);
        }

        public OperationResult Save(string code, OrderChanges changes)
        {
            if (changes == null) throw new ArgumentNullException(nameof(changes));

            var order = _orders.Find(code);
            if (order == null)
            {
                return OperationResult.Failure("Nie znaleziono zlecenia");
            }

            if (!order.CanEdit)
            {
                return OperationResult.Failure("Zlecenia w tym stanie nie można zmieniać");
            }

            if (changes.Analyte != order.Analyte && !order.CanChangeAnalyte)
            {
                return OperationResult.Failure("Badania nie można zmienić po rozpoczęciu realizacji");
            }

            var errors = LabOrderRules.Validate(changes);
            if (errors.Count > 0)
            {
                return OperationResult.Failure(errors);
            }

            order.Analyte = changes.Analyte;
            order.Priority = changes.Priority;
            order.Physician = changes.Physician.Trim();
            order.Notes = (changes.Notes ?? "").Trim();
            _orders.Update(order);

            return OperationResult.Success();
        }

        public OperationResult Cancel(string code)
        {
            var order = _orders.Find(code);
            if (order == null)
            {
                return OperationResult.Failure("Nie znaleziono zlecenia");
            }

            if (!order.CanCancel)
            {
                return OperationResult.Failure("Tego zlecenia nie można już anulować");
            }

            order.Status = OrderStatus.Cancelled;
            _orders.Update(order);

            return OperationResult.Success();
        }
    }
}
