using System.Text;
using System.Threading;

namespace Vendor.Chemtron
{
    // Biblioteka zewnętrzna producenta Chemtron. Nie wolno jej zmieniać.
    // Inne nazwy metod niż u Hemolab, inny format odpowiedzi i inna jednostka (mg/dL).
    public sealed class ChemtronClient
    {
        private readonly string _address;
        private bool _isOpen;

        public ChemtronClient(string address)
        {
            _address = address;
        }

        public void Open()
        {
            Thread.Sleep(100);

            if (!ChemtronBench.IsPoweredOn(_address))
            {
                throw new ChemtronException(ChemtronStatus.LinkDown, "LINK DOWN: " + _address);
            }

            _isOpen = true;
        }

        // Zwraca rekordy w stylu ASTM. Gdy analizator nie zna próbki, nie ma wyjątku:
        // odpowiedź po prostu nie zawiera rekordu wyniku (R).
        public string QueryRecords(string specimen)
        {
            if (!_isOpen)
            {
                throw new ChemtronException(ChemtronStatus.LinkDown, "LINK NOT OPEN");
            }

            if (ChemtronBench.IsBusyFor(_address, specimen))
            {
                throw new ChemtronException(ChemtronStatus.Busy, "ANALYZER BUSY");
            }

            var records = new StringBuilder()
                .Append("H|\\^&|||CHEMTRON^C5\r")
                .Append("P|1\r")
                .Append("O|1|").Append(specimen).Append("\r");

            ChemtronBench.LoadedSample sample;
            if (ChemtronBench.TryGetSample(_address, specimen, out sample))
            {
                records.Append("R|1|^^^GLU|").Append(sample.Value).Append("|").Append(sample.Unit).Append("||N||F\r");
            }

            return records.Append("L|1|N").ToString();
        }

        public void Close()
        {
            _isOpen = false;
        }
    }
}
