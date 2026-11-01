using System;

namespace Lims.Problem
{
    // TODO: refaktoryzacja: każdy status staje się klasą, która sama wie, co wolno z niego zrobić.
    // PROBLEM: reguły obiegu próbki są rozsiane po warunkach. Każda operacja wylicza inne statusy,
    // a warunki mówią, czego nie wolno, więc to, czego nikt nie wymienił, jest dozwolone (OCP).
    public static class SampleOperations
    {
        public static void StartAnalysis(Sample sample, string user)
        {
            if (sample.Status != SampleStatus.Registered)
            {
                throw new InvalidOperationException("Analizę można rozpocząć tylko dla próbki zarejestrowanej.");
            }

            sample.Status = SampleStatus.InAnalysis;

            // PROBLEM: ta zmiana statusu nie trafia do historii, a zatwierdzenie już tak (DRY).
        }

        public static void EnterResult(Sample sample, decimal value, string user)
        {
            // PROBLEM: wynik można wpisać próbce odrzuconej i takiej, której analiza się nie zaczęła.
            if (sample.Status == SampleStatus.Approved || sample.Status == SampleStatus.Archived)
            {
                throw new InvalidOperationException("Nie można zmienić wyniku po zatwierdzeniu.");
            }

            sample.Result = value;
            sample.ResultEnteredBy = user;
        }

        public static void Approve(Sample sample, string user)
        {
            // PROBLEM: warunek wyklucza tylko archiwum, więc da się zatwierdzić próbkę odrzuconą.
            if (sample.Status == SampleStatus.Archived)
            {
                throw new InvalidOperationException("Nie można zatwierdzić próbki z archiwum.");
            }

            if (!sample.Result.HasValue)
            {
                throw new InvalidOperationException("Nie można zatwierdzić próbki bez wyniku.");
            }

            sample.Status = SampleStatus.Approved;
            sample.ApprovedBy = user;
            sample.History.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm") + " zatwierdzona przez " + user);
        }

        public static void Reject(Sample sample, string user, string reason)
        {
            // PROBLEM: da się odrzucić próbkę już zatwierdzoną, choć wynik mógł trafić do lekarza.
            if (sample.Status == SampleStatus.Archived)
            {
                throw new InvalidOperationException("Nie można odrzucić próbki z archiwum.");
            }

            if (string.IsNullOrWhiteSpace(reason))
            {
                throw new InvalidOperationException("Odrzucenie wymaga podania powodu.");
            }

            sample.Status = SampleStatus.Rejected;
            sample.RejectionReason = reason;
            sample.History.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm") + " odrzucona przez " + user);
        }

        public static void Archive(Sample sample, string user)
        {
            // PROBLEM: warunek wyklucza tylko próbkę zarejestrowaną, więc do archiwum trafia też próbka w analizie.
            if (sample.Status == SampleStatus.Registered)
            {
                throw new InvalidOperationException("Nie można zarchiwizować próbki przed analizą.");
            }

            sample.Status = SampleStatus.Archived;

            // PROBLEM: tej zmiany też nie ma w historii.
        }
    }
}
