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
        private static Random _random = new Random();
        public LijnenVoorraad LijnenVoorraad { get; }
        public Kabel Kabel { get; }
        public Waterskibaan()
        {
            LijnenVoorraad = new LijnenVoorraad();
            Kabel = new Kabel();

            for (int i = 0; i < 15; i++)
            {
                LijnenVoorraad?.LijnToevoegenAanRij(new Lijn());
            }
        }
        public void VerplaatsKabel()
        {
            Kabel.VerschuifLijnen();
            LijnenVoorraad.LijnToevoegenAanRij(Kabel.VerwijderLijnVanKabel());
        }
        public void SporterStart(Sporter sp)
        {
            if (sp.Skies == null || sp.Zwemvest == null)
            {
                throw new Exception();
            }

            Lijn lijn = LijnenVoorraad.VerwijderEersteLijn();
            lijn.Sporter = sp;
            Kabel.NeemLijnInGebruik(lijn);
            sp.AantalRondenNogTeGaan = _random.Next(1, 3);

            Color c = new Color()
            {
                R = (byte)_random.Next(0, 256),
                G = (byte)_random.Next(0, 256),
                B = (byte)_random.Next(0, 256)
            };

            sp.KledingKleur = c;
        }
        public void Start()
        {
            throw new NotImplementedException();
        }
        public void Stop()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return $"{Kabel} {LijnenVoorraad}";
        }
    }
}
