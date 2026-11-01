using System;
using System.IO;
using System.Threading;

namespace Lims.Problem
{
    // Symulacja płatnej bramki SMS: trwa długo i zostawia ślad w pliku.
    public class SmsGateway
    {
        public const string OutboxFile = "sms-wyslane.txt";

        public void Send(string phone, string text)
        {
            Thread.Sleep(1500);
            File.AppendAllText(OutboxFile, phone + ": " + text + Environment.NewLine);
        }
    }
}
