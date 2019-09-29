using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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
        public void SporterStart(Sporter sp)
        {
            Random rdn = new Random();
            Kabel.NeemLijnInGebruik(LijnenVoorraad.VerwijderEersteLijn());
            sp.AantalRondenNogTeGaan = rdn.Next(1, 3);

            Color c = new Color();
            c.R = (byte) rdn.Next(0, 256);
            c.G = (byte) rdn.Next(0, 256);
            c.B = (byte) rdn.Next(0, 256);

            sp.KledingKleur = c;
        }
    }
}
