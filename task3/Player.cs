using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    internal class Player
    {
        int[] moveHistory = Array.Empty<int>();
        public void SetMove(int move) { moveHistory.Append(move-1); }

        public int[] GetMove() { return moveHistory; }

    }
}
