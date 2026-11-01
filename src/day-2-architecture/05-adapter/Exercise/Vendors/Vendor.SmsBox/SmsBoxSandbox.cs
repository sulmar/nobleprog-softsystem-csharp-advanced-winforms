using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Vendor.SmsBox
{
    public sealed class SmsBoxMessage
    {
        public SmsBoxMessage(string msisdn, string text)
        {
            Msisdn = msisdn;
            Text = text;
        }

        public string Msisdn { get; }

        public string Text { get; }
    }

    // Piaskownica operatora: pokazuje, co „dotarło”, i pozwala zasymulować awarię.
    // Każde konto ma osobną skrzynkę. Nic nie jest naprawdę wysyłane.
    public static class SmsBoxSandbox
    {
        private static readonly ConcurrentDictionary<string, ConcurrentQueue<SmsBoxMessage>> Sent = new ConcurrentDictionary<string, ConcurrentQueue<SmsBoxMessage>>();
        private static readonly ConcurrentDictionary<string, bool> Down = new ConcurrentDictionary<string, bool>();
        private static readonly ConcurrentDictionary<string, bool> Rejected = new ConcurrentDictionary<string, bool>();

        public static void SimulateOutage(string account)
        {
            Down[account] = true;
        }

        public static void RejectNumber(string account, string msisdn)
        {
            Rejected[account + "/" + msisdn] = true;
        }

        public static IReadOnlyList<SmsBoxMessage> Delivered(string account)
        {
            return Sent.GetOrAdd(account, _ => new ConcurrentQueue<SmsBoxMessage>()).ToList();
        }

        internal static bool IsDown(string account)
        {
            return Down.ContainsKey(account);
        }

        internal static bool IsRejected(string account, string msisdn)
        {
            return Rejected.ContainsKey(account + "/" + msisdn);
        }

        internal static void Record(string account, string msisdn, string text)
        {
            Sent.GetOrAdd(account, _ => new ConcurrentQueue<SmsBoxMessage>()).Enqueue(new SmsBoxMessage(msisdn, text));
        }
    }
}
