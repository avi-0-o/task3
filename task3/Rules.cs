using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace task3
{
    internal class Rules { 

        static public string GetWinner(string userMove, string computerMove)
        {
            string[] moves = MoveGenerator.moves;
            int halfLength = moves.Length / 2;
            int userIndex = Array.IndexOf(moves, userMove);
            int computerIndex = Array.IndexOf(moves, computerMove);

            if (userIndex == computerIndex) 
                return "Draw";
            else if ((computerIndex - userIndex + moves.Length) % moves.Length <= halfLength)
                return "Computer Win";
            else
                return "User Win";
           
        }
        
        static public void Winner(int[] UserMoves, int[] ComputerMoves)
            {
            if (UserMoves is null)
            {
                Console.WriteLine("User has no moves");
                return;
            }
            string[] moves = MoveGenerator.moves;
            byte[] result = new byte[3];
            for (int i = 0; i < UserMoves.Length; i++) 
            {
                if (UserMoves[i] == ComputerMoves[i])
                    result[0]++;
                else if ((ComputerMoves[i] - UserMoves[i] + moves.Length) % moves.Length <= moves.Length / 2)
                    result[1]++;
                else
                    result[2]++;
            }
            Console.WriteLine("\t~~~~ Game Over ~~~~");
            if (Array.IndexOf(result,result.Max())==0)
            {
                Console.WriteLine("\tDraw");
            }
            else if(Array.IndexOf(result,result.Max())==1)
            {
                Console.WriteLine("\t Computer WIN :/");
            }
            else { Console.WriteLine("\t User WIN !!!!"); }
        }
    }
}
