using System;
using System.IO;

namespace LabelTech.Sdk
{
    /// <summary>
    /// Symulacja SDK drukarki etykiet jednego dostawcy. Prawdziwe SDK łączy się z urządzeniem
    /// przez port szeregowy, tu zapisuje etykiety do pliku.
    /// </summary>
    public class LabelTechPrinter
    {
        private string _port;

        public void Connect(string port)
        {
            _port = port;
        }

        public void PrintLine(string text)
        {
            if (_port == null) throw new InvalidOperationException("Drukarka nie jest podłączona");

            File.AppendAllText("labels.txt", "[" + _port + "] " + text + Environment.NewLine);
        }

        public void Disconnect()
        {
            _port = null;
        }
    }
}
