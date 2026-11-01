using System;
using System.Collections.Generic;

namespace Lims.Problem
{
    public static class LabData
    {
        public static List<LabResult> Results { get; } = new List<LabResult>
        {
            new LabResult { Code = "W-1001", Analyte = "Glukoza", ValueText = "90", RangeLow = 70, RangeHigh = 100 },
            new LabResult { Code = "W-1002", Analyte = "Glukoza", ValueText = "250", RangeLow = 70, RangeHigh = 100 },
            new LabResult { Code = "W-1003", Analyte = "Hemoglobina", ValueText = "14", RangeLow = 12, RangeHigh = 16 },
            new LabResult { Code = "W-1004", Analyte = "Potas", ValueText = "<2", RangeLow = 3, RangeHigh = 5 },
            new LabResult { Code = "W-1005", Analyte = "Sód", ValueText = "140", RangeLow = 135, RangeHigh = 145 },
            new LabResult { Code = "W-1006", Analyte = "Cholesterol", ValueText = "180", RangeLow = 0, RangeHigh = 190 }
        };

        // TODO: refaktoryzacja: zdarzenie o znaczeniu biznesowym i subskrypcja, którą można zwolnić jednym wywołaniem.
        // PROBLEM: statyczne zdarzenie żyje tyle co aplikacja i trzyma każde okno, które się zapisało.
        // Każdy odbiorca musi sam pamiętać o -=, a o lambdzie nie da się tego zrobić.
        public static event Action<LabResult> ResultChanged;

        public static int SubscriberCount
        {
            get { return ResultChanged == null ? 0 : ResultChanged.GetInvocationList().Length; }
        }

        // Licznik diagnostyczny do demo: ile powiadomień trafiło do okien, które już zamknięto.
        public static int DeliveriesToClosedWindows { get; set; }

        public static void RaiseResultChanged(LabResult result)
        {
            ResultChanged?.Invoke(result);
        }
    }
}
