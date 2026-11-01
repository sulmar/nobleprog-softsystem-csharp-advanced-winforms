using System.Collections.Generic;

namespace Lims.Problem
{
    // Symulacja bazy w pamięci. Moduł nie zajmuje się dostępem do danych.
    public static class SampleDatabase
    {
        private static readonly List<Sample> Samples = new List<Sample>
        {
            new Sample("S-1001", "Anna Testowa", "Glukoza", false),
            new Sample("S-1002", "Jan Przykładowy", "Hemoglobina", true),
            new Sample("S-1003", "Maria Fikcyjna", "Morfologia", false) { Comment = "Próbka lekko mętna" },
            new Sample("S-1004", "Piotr Testowy", "Glukoza", true) { Status = SampleStatus.Approved },
            new Sample("S-1005", "Ewa Przykładowa", "CRP", false) { Status = SampleStatus.Rejected, Comment = "Hemoliza" },
            new Sample("S-1006", "Adam Fikcyjny", "Morfologia", true)
        };

        public static IReadOnlyList<Sample> All()
        {
            return Samples;
        }
    }
}
