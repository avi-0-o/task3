﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    internal class Player
    {
        public List<int> moveHistory = new List<int>() ;
        public void SetMove(int move) {
            this.moveHistory.Add(move-1);
        }

        public int[] GetMoves() { return moveHistory.ToArray(); }

    }
}
