using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    internal class MoveGenerator
    {
        public static string[] moves= Array.Empty<string>();

        public static string GetMove(int index)
        {
            if (index < 0 || index > moves.Length)
                return "";
            return moves[index];
        }
    }
}
