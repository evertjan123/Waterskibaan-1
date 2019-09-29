using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.Moves;

namespace Waterskibaan
{
    static class MoveCollection
    {
        private static List<IMove> Moves = new List<IMove>() {
            new Jump(),
            new Slalom(),
            new Trick(),
            new Turn()
        };
        public static List<IMove> GetWillekeurigeMoves()
        {
            List<IMove> moves = new List<IMove>();
            Random rnd = new Random();
            
            foreach (var move in Moves)
            {
                if (rnd.Next(0, 2) == 1) {
                    moves.Add(move);
                }
            }

            return moves;
        }
    }
}
