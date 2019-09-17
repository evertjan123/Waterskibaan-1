using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Kabel
    {
        private LinkedList<Lijn> _lijnen;

        public bool IsStartPositieLeeg()
        {
            return _lijnen.First == null;
        }
        public void NeemLijnInGebruik(Lijn lijn)
        {
            if (IsStartPositieLeeg())
            {
                _lijnen.AddFirst(lijn);
            }
        }
        public void VerschuifLijnen()
        {
            
        }
        public Lijn VerwijderLijnVanKabel()
        {
            Lijn l = _lijnen.ElementAt<Lijn>(9);

            if (l != null)
            {
                _lijnen.Remove(l);
            }
            
            return l;
        }
        public override string ToString()
        {
            List<int> integers = new List<int>();
            foreach (var item in _lijnen)
            {
                if (item != null)
                {
                    integers.Add(item.PositieOpDeKabel);
                }
            }

            // return integers.Join<int>("|");
            return base.ToString();
        }
    }
}
