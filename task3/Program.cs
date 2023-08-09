using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;



namespace task3
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Player pc = new Player();
            Player user = new Player();
            Random rnd = new Random();
            args.Select(iter => iter.Trim());
            if (isValid(args))  //program ends if args is not valid
            {
                return;
            }
            MoveGenerator.moves = args;
            KeyGenerator key = new KeyGenerator();
            int rounds = rnd.Next(2, args.Length), userMove, pcMove;
            rounds = rounds % 2 == 0 ? rounds += 1 : rounds;
            string userChr = " ";
            while (rounds-- > 0)
            {   
                pcMove = rnd.Next(1, MoveGenerator.moves.Length + 1);
                Console.WriteLine("HMAC: " + HMACGenerator.Hmac(key.SetRandomKey(), MoveGenerator.moves[pcMove - 1]));
                UserInterface.showActions();
                Console.Write("Enter your action: ");
                userChr = Console.ReadLine();
                userChr = userChr == null ? " " : userChr;
                if (int.TryParse(userChr.Trim(), out userMove))
                {
                    if (userMove == 0)
                    {
                        Rules.Winner(user.GetMoves(), pc.GetMoves());
                        Console.WriteLine();
                        UserInterface.showResults(user.GetMoves(), pc.GetMoves()); 

                        return;
                    }
                    else if (userMove < 0 || userMove > MoveGenerator.moves.Length)
                    {
                        Console.WriteLine($"Invalid input it must between 0 - {MoveGenerator.moves.Length} or symbol '?'");
                        rounds++;
                        continue;
                    }

                    pc.SetMove(pcMove);
                    user.SetMove(userMove);
                    Console.WriteLine("User move: " + MoveGenerator.moves[userMove - 1]);
                    Console.WriteLine("Computer move: " + MoveGenerator.moves[pcMove - 1] + "\nHMAC key: " + key.GetKey());
                    Console.WriteLine("Result of round: "+Rules.GetWinner(userMove,pcMove));
                    Console.WriteLine((rounds == 0) ? "" : "\n-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_");
                }
                else if (userChr.Trim() == "?")
                {
                    UserInterface.showHelp();
                    rounds++;
                }
                else
                {
                    Console.WriteLine($"Invalid input it must between 0 - {MoveGenerator.moves.Length} or symbol '?'");
                    rounds++;
                }
            }
            if (rounds == -1)
            {
                Rules.Winner(user.GetMoves(), pc.GetMoves());
                UserInterface.showResults(user.GetMoves(), pc.GetMoves());
            }

        }


        static bool isValid(string[] input)
        {
            if (input.Distinct().Count() != input.Length)
            {
                Console.WriteLine("The input moves must be unique values");
                return true;
            }
            if (input.Length < 3 || input.Length % 2 == 0)
            {
                Console.WriteLine("Error you should enter the strings  or amount of them must be odd");
                return true;
            }
            return false;
        }



    }
}