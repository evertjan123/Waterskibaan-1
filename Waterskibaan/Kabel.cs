using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Kabel
    {
        public LinkedList<Lijn> Lijnen { get; } = new LinkedList<Lijn>();

        public bool IsStartPositieLeeg()
        {
            return Lijnen == null || Lijnen.Count == 0 || Lijnen.First.Value.PositieOpDeKabel != 0;
        }
        public void NeemLijnInGebruik(Lijn lijn)
        {
            if (IsStartPositieLeeg() && lijn != null)
            {
                Lijnen?.AddFirst(lijn);
            }
        }
        public void VerschuifLijnen()
        {
            if (Lijnen?.Last?.Value?.PositieOpDeKabel >= 9)
            {
                Lijn r = Lijnen.Last.Value;
                Lijnen.RemoveLast();
                Lijnen.AddFirst(r);
            }

            for (LinkedListNode<Lijn> current = Lijnen?.First; current != null; current = current.Next)
            {
                 current.Value.PositieOpDeKabel++;
            }
        }
        public Lijn VerwijderLijnVanKabel()
        {
            Lijn r = null;

            if (Lijnen != null && Lijnen.Count != 0 && Lijnen.Last.Value.PositieOpDeKabel == 9 && (Lijnen.Last.Value.Sporter == null || Lijnen.Last.Value.Sporter.AantalRondenNogTeGaan == 1))
            {
                r = Lijnen.Last.Value;
                Lijnen.RemoveLast();
            }

            return r;
        }
        public override string ToString()
        {
            if (Lijnen != null && Lijnen.Count > 0)
            {
                List<int> integers = new List<int>();

                for (LinkedListNode<Lijn> current = Lijnen.First; current != null; current = current.Next)
                {
                    integers.Add(current.Value.PositieOpDeKabel);
                }

                return String.Join("|", integers.ToArray());
            }
            else
            {
                return "";
            }
        }
    }
}
