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
        private LijnenVoorraad _lijnenVoorraad;
        private Kabel _kabel;
        public Waterskibaan()
        {
            _lijnenVoorraad = new LijnenVoorraad();
            _kabel = new Kabel();

            for (int i = 0; i < 15; i++)
            {
                _lijnenVoorraad?.LijnToevoegenAanRij(new Lijn());
            }
        }
        public void VerplaatsKabel()
        {
            _kabel.VerschuifLijnen();
            _lijnenVoorraad.LijnToevoegenAanRij(_kabel.VerwijderLijnVanKabel());
        }
        public void SporterStart(Sporter sp)
        {
            if (sp.Skies == null || sp.Zwemvest == null)
            {
                throw new Exception();
            }

            Random rdn = new Random();
            _kabel.NeemLijnInGebruik(_lijnenVoorraad.VerwijderEersteLijn());
            sp.AantalRondenNogTeGaan = rdn.Next(1, 3);

            Color c = new Color()
            {
                R = (byte)rdn.Next(0, 256),
                G = (byte)rdn.Next(0, 256),
                B = (byte)rdn.Next(0, 256)
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
            return $"{_kabel} {_lijnenVoorraad}";
        }
    }
}
