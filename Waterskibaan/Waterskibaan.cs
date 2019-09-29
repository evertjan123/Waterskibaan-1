using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Waterskibaan
    {
        public LijnenVoorraad LijnenVoorraad;
        public Kabel Kabel;
        public Waterskibaan()
        {
            for (int i = 0; i < 15; i++)
            {
                LijnenVoorraad.LijnToevoegenAanRij(new Lijn());
            }
        }
        public void VerplaatsKabel()
        {
            Kabel.VerschuifLijnen();
            LijnenVoorraad.LijnToevoegenAanRij(Kabel.VerwijderLijnVanKabel());
        }

    }
}
