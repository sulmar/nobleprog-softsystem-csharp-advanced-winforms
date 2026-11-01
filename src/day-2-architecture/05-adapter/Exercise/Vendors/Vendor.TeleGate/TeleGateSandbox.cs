using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Vendor.TeleGate
{
    public sealed class TeleGateMessage
    {
        public TeleGateMessage(string recipient, string body)
        {
            Recipient = recipient;
            Body = body;
        }

        public string Recipient { get; }

        public string Body { get; }
    }

    // Piaskownica operatora: pokazuje, co „dotarło”, i pozwala zasymulować awarię.
    // Każdy klucz ma osobną skrzynkę. Nic nie jest naprawdę wysyłane.
    public static class TeleGateSandbox
    {
        private static readonly ConcurrentDictionary<string, ConcurrentQueue<TeleGateMessage>> Sent = new ConcurrentDictionary<string, ConcurrentQueue<TeleGateMessage>>();
        private static readonly ConcurrentDictionary<string, bool> Down = new ConcurrentDictionary<string, bool>();
        private static readonly ConcurrentDictionary<string, bool> Rejected = new ConcurrentDictionary<string, bool>();

        public static void SimulateOutage(string apiKey)
        {
            Down[apiKey] = true;
        }

        public static void RejectNumber(string apiKey, string recipient)
        {
            Rejected[apiKey + "/" + recipient] = true;
        }

        public static IReadOnlyList<TeleGateMessage> Delivered(string apiKey)
        {
            return Sent.GetOrAdd(apiKey, _ => new ConcurrentQueue<TeleGateMessage>()).ToList();
        }

        internal static bool IsDown(string apiKey)
        {
            return Down.ContainsKey(apiKey);
        }

        internal static bool IsRejected(string apiKey, string recipient)
        {
            return Rejected.ContainsKey(apiKey + "/" + recipient);
        }

        internal static void Record(string apiKey, string recipient, string body)
        {
            Sent.GetOrAdd(apiKey, _ => new ConcurrentQueue<TeleGateMessage>()).Enqueue(new TeleGateMessage(recipient, body));
        }
    }
}
