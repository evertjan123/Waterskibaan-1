using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Kabel
    {
        private LinkedList<Lijn> _lijnen = new LinkedList<Lijn>();

        public bool IsStartPositieLeeg()
        {
            return _lijnen == null || _lijnen.Count == 0 || _lijnen.First.Value.PositieOpDeKabel != 0;
        }
        public void NeemLijnInGebruik(Lijn lijn)
        {
            if (IsStartPositieLeeg() && lijn != null)
            {
                _lijnen?.AddFirst(lijn);
            }
        }
        public void VerschuifLijnen()
        {
            if (_lijnen?.Last.Value.PositieOpDeKabel >= 9)
            {
                Lijn r = _lijnen.Last.Value;
                _lijnen.RemoveLast();
                _lijnen.AddFirst(r);
            }

            for (LinkedListNode<Lijn> current = _lijnen?.First; current != null; current = current.Next)
            {
                 current.Value.PositieOpDeKabel++;
            }
        }
        public Lijn VerwijderLijnVanKabel()
        {
            Lijn r = null;

            if (_lijnen != null && _lijnen.Count != 0 && _lijnen.Last.Value.PositieOpDeKabel == 9 && (_lijnen.Last.Value.Sporter == null || _lijnen.Last.Value.Sporter.AantalRondenNogTeGaan == 1))
            {
                r = _lijnen.Last.Value;
                _lijnen.RemoveLast();
            }

            return r;
        }
        public override string ToString()
        {
            if (_lijnen != null && _lijnen.Count > 0)
            {
                List<int> integers = new List<int>();

                for (LinkedListNode<Lijn> current = _lijnen.First; current != null; current = current.Next)
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
