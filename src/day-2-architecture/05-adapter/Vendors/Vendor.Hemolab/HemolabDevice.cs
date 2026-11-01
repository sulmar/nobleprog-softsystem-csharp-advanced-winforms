using System;
using System.Text;
using System.Threading;

namespace Vendor.Hemolab
{
    // Biblioteka zewnętrzna producenta Hemolab. Nie wolno jej zmieniać.
    // Klasa jest zamknięta i nie ma interfejsu, więc nie da się jej podmienić w teście.
    public sealed class HemolabDevice : IDisposable
    {
        private string _port;

        public void Connect(string port)
        {
            // Nawiązanie połączenia z urządzeniem trwa.
            Thread.Sleep(100);

            if (!HemolabBench.IsPoweredOn(port))
            {
                throw new HemolabCommException(HemolabErrors.NoDevice, "E101 NO DEVICE ON PORT " + port);
            }

            _port = port;
        }

        // Zwraca wiadomość w stylu HL7. Wartość glukozy jest w mmol/L.
        public string ReadMessage(string sampleId)
        {
            if (_port == null)
            {
                throw new HemolabCommException(HemolabErrors.NotConnected, "E102 NOT CONNECTED");
            }

            if (HemolabBench.IsBusyFor(_port, sampleId))
            {
                throw new HemolabCommException(HemolabErrors.DeviceBusy, "E301 DEVICE BUSY");
            }

            HemolabBench.LoadedSample sample;
            if (!HemolabBench.TryGetSample(_port, sampleId, out sample))
            {
                throw new HemolabCommException(HemolabErrors.SampleUnknown, "E204 SAMPLE UNKNOWN " + sampleId);
            }

            return new StringBuilder()
                .Append("MSH|^~\\&|HEMOLAB|H200|LIMS|LAB|").Append(DateTime.Now.ToString("yyyyMMddHHmmss")).Append("||ORU^R01|1|P|2.3\r")
                .Append("OBR|1||").Append(sampleId).Append("|GLU^Glukoza\r")
                .Append("OBX|1|ST|DEV^Status||OK\r")
                .Append("OBX|2|NM|GLU^Glukoza||").Append(sample.Value).Append("|").Append(sample.Unit).Append("|3.9-5.6|N|||F")
                .ToString();
        }

        public void Disconnect()
        {
            _port = null;
        }

        public void Dispose()
        {
            Disconnect();
        }
    }
}
