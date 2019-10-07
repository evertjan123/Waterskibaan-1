using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Lijn
    {
        private int _positieOpDeKabel = 0;
        public int PositieOpDeKabel
        {
            get
            {
                return _positieOpDeKabel;
            }
            set
            {
                if (value < 0)
                {
                    if (Sporter != null)
                    {
                        Sporter.AantalRondenNogTeGaan -= value / 10 - 1;
                    }
                    while (value < 0)
                    {
                        value += 1000;
                    }
                }
                else if (Sporter != null && value > 9)
                {
                    Sporter.AantalRondenNogTeGaan -= value / 10;
                }

                _positieOpDeKabel = value % 10;
            }
        }

        public Sporter Sporter;
    }
}
