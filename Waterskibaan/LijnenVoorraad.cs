using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class LijnenVoorraad
    {
        private Queue<Lijn> _lijnen = new Queue<Lijn>();

        public void LijnToevoegenAanRij(Lijn lijn)
        {
            if (lijn != null)
            {
                _lijnen.Enqueue(lijn);
            }
        }
        public Lijn VerwijderEersteLijn()
        {
            if (GetAantalLijnen() > 0)
            {
                return _lijnen.Dequeue();
            }

            return null;
        }
        public int GetAantalLijnen()
        {
            if (_lijnen != null)
            {
                return _lijnen.Count;
            }

            return 0;
        }
        public override string ToString()
        {
            int lijnen = GetAantalLijnen();
            string en = lijnen == 1 ? "" : "en";
            return $"{lijnen} lijn{en} op voorraad";
        }

    }
}
