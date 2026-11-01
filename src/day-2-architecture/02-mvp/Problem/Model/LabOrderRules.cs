using System.Collections.Generic;

namespace Lims.Problem.Model
{
    /// <summary>Reguły biznesowe zlecenia. Zwracają dane, a o tym, jak je pokazać, decyduje ktoś inny.</summary>
    public static class LabOrderRules
    {
        public static readonly IReadOnlyList<string> Analytes = new[] { "Glukoza", "Hemoglobina", "Morfologia" };

        public static IReadOnlyList<string> Validate(OrderChanges changes)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(changes.Analyte))
            {
                errors.Add("Wybierz badanie");
            }

            if (string.IsNullOrWhiteSpace(changes.Physician))
            {
                errors.Add("Podaj lekarza zlecającego");
            }

            if (changes.Priority == OrderPriority.Immediate && string.IsNullOrWhiteSpace(changes.Notes))
            {
                errors.Add("Zlecenie Cito wymaga uwag");
            }

            return errors;
        }
    }
}
