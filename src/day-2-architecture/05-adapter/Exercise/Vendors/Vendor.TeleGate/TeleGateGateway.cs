using System;
using System.Linq;

namespace Vendor.TeleGate
{
    public sealed class TeleGateEnvelope
    {
        // Numer w formacie międzynarodowym, np. +48600100200.
        public string Recipient { get; set; }

        // Tylko znaki ASCII, bez polskich liter. Najwyżej 70 znaków w jednej kopercie.
        public string Body { get; set; }
    }

    // Biblioteka nowego operatora. Nie wolno jej zmieniać.
    public sealed class TeleGateGateway
    {
        private readonly string _apiKey;

        public TeleGateGateway(string apiKey)
        {
            _apiKey = apiKey;
        }

        // Zwraca identyfikator przesyłki. Odrzucenie: TeleGateRejectedException. Awaria: TeleGateUnavailableException.
        public Guid Dispatch(TeleGateEnvelope envelope)
        {
            if (TeleGateSandbox.IsDown(_apiKey))
            {
                throw new TeleGateUnavailableException("GATEWAY 503");
            }

            var recipient = envelope.Recipient ?? string.Empty;
            if (recipient.Length != 12 || !recipient.StartsWith("+48") || !recipient.Skip(3).All(character => character >= '0' && character <= '9')
                || TeleGateSandbox.IsRejected(_apiKey, recipient))
            {
                throw new TeleGateRejectedException("RECIPIENT_FORMAT", "Recipient rejected: " + recipient);
            }

            var body = envelope.Body ?? string.Empty;
            if (body.Any(character => character > 127))
            {
                throw new TeleGateRejectedException("BODY_CHARSET", "Body contains non-ASCII characters");
            }

            if (body.Length > 70)
            {
                throw new TeleGateRejectedException("BODY_TOO_LONG", "Body is longer than 70 characters");
            }

            TeleGateSandbox.Record(_apiKey, recipient, body);
            return Guid.NewGuid();
        }
    }
}
