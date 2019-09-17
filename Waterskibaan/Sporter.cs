using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Sporter : IMoves
    {
        public int AantalRondenNogTeGaan { get; set; } = 1;
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public Color KledingKleur { get; set; }
        public List<IMoves> Moves { get; set; }

        public Sporter(List<IMoves> moves)
        {

        }

        public int Move()
        {
            throw new NotImplementedException();
        }
    }
}
