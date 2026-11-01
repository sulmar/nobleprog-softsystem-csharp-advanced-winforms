using System;

namespace Lims.Problem
{
    public class ResultApprovalService
    {
        private readonly DbSession _session;

        public ResultApprovalService(DbSession session)
        {
            _session = session;
        }

        public ApprovalOutcome Approve(string code, string approvedBy)
        {
            if (string.IsNullOrWhiteSpace(approvedBy))
            {
                return Refused("Podaj nazwisko zatwierdzającego");
            }

            var result = _session.Find(code);
            if (result == null)
            {
                return Refused("Nieznana próbka: " + code);
            }

            if (result.IsApproved)
            {
                return Refused("Wynik " + code + " jest już zatwierdzony");
            }

            // TODO: refaktoryzacja: bieżący czas jako zależność.
            // PROBLEM: DateTime.Now uniemożliwia sprawdzenie godziny zatwierdzenia w teście (DIP).
            result.IsApproved = true;
            result.ApprovedBy = approvedBy;
            result.ApprovedAt = DateTime.Now;

            // TODO: refaktoryzacja: dziennik przez konstruktor.
            // PROBLEM: statyczny singleton nie jest widoczny w konstruktorze, więc klasa ukrywa zależność (DIP).
            AuditLog.Instance.Write("Zatwierdzono " + code + ", " + approvedBy);

            if (result.IsCritical)
            {
                // TODO: refaktoryzacja: powiadomienie przez interfejs przekazany w konstruktorze.
                // PROBLEM: `new` wiąże regułę z konkretną bramką. Każdy test wyniku krytycznego czeka
                // półtorej sekundy i naprawdę wysyła SMS, a zmiana kanału wymaga zmiany tej klasy (DIP, OCP).
                new SmsGateway().Send(LabSettings.Instance.DoctorPhone, "Wynik krytyczny " + code);
            }

            return new ApprovalOutcome { IsSuccess = true, Message = "Zatwierdzono " + code };
        }

        private static ApprovalOutcome Refused(string message)
        {
            return new ApprovalOutcome { IsSuccess = false, Message = message };
        }
    }
}
