using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Waterskibaan
{
    class Sporter
    {
        public int AantalRondenNogTeGaan { get; set; } = 1;
        public int BehaaldePunten { get; set; }
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public Color KledingKleur { get; set; }
        public List<IMove> Moves { get; set; }
        public IMove HuidigeMove { get; set; }

        public Sporter(List<IMove> moves)
        {
            BehaaldePunten = 0;
            Moves = moves;

            foreach (IMove move in Moves)
            {
                BehaaldePunten += move.Move();
            }
        }

        public void OnLijnenVerplaatst()
        {
            Random random = new Random();
            if (Moves.Count > 0 && random.Next(0, 4) == 0)
            {
                HuidigeMove = Moves[random.Next(0, Moves.Count)];
            }
            else
            {
               HuidigeMove = null;
            }
        }
    }
}
