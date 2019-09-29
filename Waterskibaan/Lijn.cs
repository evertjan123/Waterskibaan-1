using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Lijn
    {
        private int _positieOpDeKabel;
        public int PositieOpDeKabel {
            get
            {
                return _positieOpDeKabel;
            }
            set
            {
                if (value > 9 || value < 0)
                {
                    while (value < 0)
                    {
                        value += 1000;
                    }
                    _positieOpDeKabel = value % 10;
                }
                else
                {
                    _positieOpDeKabel = value;
                }
            }
        }

        public Sporter Sporter;
    }
}
