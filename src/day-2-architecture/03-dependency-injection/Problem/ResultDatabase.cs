using System.Collections.Generic;

namespace Lims.Problem
{
    // TODO: refaktoryzacja: instancja o czasie życia aplikacji, którą składa jedno miejsce.
    // PROBLEM: statyczny stan żyje między testami, więc wynik testu zależy od kolejności uruchomienia (DIP).
    public sealed class ResultDatabase
    {
        public static ResultDatabase Instance { get; } = new ResultDatabase();

        private ResultDatabase()
        {
            Rows = new List<LabResult>
            {
                new LabResult { Code = "S-001", Analyte = "Glukoza", Value = 90m, UpperLimit = 100m },
                new LabResult { Code = "S-002", Analyte = "Glukoza", Value = 250m, UpperLimit = 100m },
                new LabResult { Code = "S-003", Analyte = "Hemoglobina", Value = 14m, UpperLimit = 16m },
                new LabResult { Code = "S-004", Analyte = "Kreatynina", Value = 1m, UpperLimit = 1.2m }
            };
        }

        public List<LabResult> Rows { get; }
    }
}
