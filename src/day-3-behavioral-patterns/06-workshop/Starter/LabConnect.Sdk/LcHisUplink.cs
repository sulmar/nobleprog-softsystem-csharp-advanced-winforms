using System;
using System.Collections.Generic;
using System.Threading;

namespace LabConnect.Sdk
{
    // Symulacja łącza do systemu szpitalnego. Wysłane komunikaty trafiają do skrzynki w pamięci.
    public class LcHisUplink
    {
        public const int LC_OK = 0;
        public const int LC_ERR_NO_PATIENT = -3;

        public static int SimulatedTransmitDelayMs = 3000;

        private static readonly object OutboxLock = new object();
        private static readonly List<string> SentMessages = new List<string>();

        public static IReadOnlyList<string> Outbox
        {
            get
            {
                lock (OutboxLock)
                {
                    return SentMessages.ToArray();
                }
            }
        }

        public int Transmit(string message, out string ack)
        {
            Thread.Sleep(SimulatedTransmitDelayMs);

            if (message == null || message.IndexOf("PID||", StringComparison.Ordinal) >= 0)
            {
                ack = "AR: brak identyfikatora pacjenta";
                return LC_ERR_NO_PATIENT;
            }

            lock (OutboxLock)
            {
                SentMessages.Add(message);
                ack = "AA: przyjęto, numer " + SentMessages.Count;
            }

            return LC_OK;
        }
    }
}
