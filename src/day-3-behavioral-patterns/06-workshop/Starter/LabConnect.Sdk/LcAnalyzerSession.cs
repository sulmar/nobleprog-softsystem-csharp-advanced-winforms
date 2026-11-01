using System.Collections.Generic;
using System.Threading;

namespace LabConnect.Sdk
{
    // Symulacja biblioteki dostawcy analizatora. Wywołania są synchroniczne i trwają długo.
    public class LcAnalyzerSession
    {
        public const int LC_OK = 0;
        public const int LC_ERR_PORT = -1;
        public const int LC_ERR_NOT_OPEN = -2;

        public static int SimulatedOpenDelayMs = 1500;
        public static int SimulatedFrameDelayMs = 1200;

        // Pola ramki: próbka|pacjent|identyfikator|rodzaj|badanie|wartość
        private static readonly string[] DeviceFrames =
        {
            "P-2026-0201|Alina Testowa|00000000011|BIO|GLU|6.4",
            "P-2026-0202|Bogdan Próbny|00000000012|HEM|WBC|7.2",
            "P-2026-0203|Celina Wzorcowa|00000000013|KOA|INR|2.4",
            "P-2026-0204|Daniel Modelowy|00000000014|MIK|UCX|POS",
            "P-2026-0101|Jan Testowy|00000000001|BIO|GLU|5.2"
        };

        private Queue<string> _pending;

        public int PendingFrames
        {
            get { return _pending == null ? 0 : _pending.Count; }
        }

        public int Open(string port, int baudRate)
        {
            Thread.Sleep(SimulatedOpenDelayMs);

            if (port == null || !port.StartsWith("COM"))
            {
                return LC_ERR_PORT;
            }

            _pending = new Queue<string>(DeviceFrames);
            return LC_OK;
        }

        public int NextFrame(out string frame)
        {
            frame = null;

            if (_pending == null || _pending.Count == 0)
            {
                return LC_ERR_NOT_OPEN;
            }

            Thread.Sleep(SimulatedFrameDelayMs);
            frame = _pending.Dequeue();
            return LC_OK;
        }

        public void Close()
        {
            _pending = null;
        }
    }
}
