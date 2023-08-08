using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

// input string and check 


// classes

// player 
// winner
// moveGenerator
// keyGen
// HMACGenerator

//секретный ключ
//делаем ход (pc) hmac(ключ+наш ход)
//меню
// help table

namespace task3
{
    internal class Program
    {

        static void Main()
        {
            string[] args = { "scissors", "paper", "rock", "hula", "mula" };
            Player pc = new Player();
            Player user = new Player();
            Random rnd = new Random();
            args.Select(iter)
            if (isValid(args))  //program ends if args is not valid
            {
                return;
            }
            MoveGenerator.moves = args;
            int rounds = rnd.Next(3, 5), userMove,pcMove;
            rounds = rounds % 2 == 0 ? rounds += 1 : rounds;
            string hashKey="", userChr=" ";
            while (rounds-- > 0)
            {
                hashKey = KeyGenerator.getRandom();
                pcMove =rnd.Next(1,MoveGenerator.moves.Length+1);
                pc.SetMove(pcMove);
                Console.WriteLine("HMAC: "+HMACGenerator.Hmac(hashKey + MoveGenerator.moves[pcMove-1]));
                UserInterface.showActions();
                Console.Write("Enter your action: ");
                userChr = Console.ReadLine();
                userChr = userChr == null ? " " : userChr;
                if (int.TryParse(userChr, out userMove))
                {
                    if (userMove == 0)
                    {
                        // end of game 
                        return;
                    }    
                    else if(userMove <0||userMove>MoveGenerator.moves.Length)
                    {
                        Console.WriteLine($"Invalid move it must within 0 - {MoveGenerator.moves.Length} or symbol '?'");
                    }
                    user.SetMove(userMove);
                    Console.WriteLine("User move: " + MoveGenerator.moves[userMove - 1]);
                    Console.WriteLine("Computer move: "+ MoveGenerator.moves[pcMove - 1] + "\nHMAC key: " + hashKey);
                }
                else if (userChr.Trim()=="?")
                {
                    UserInterface.showHelp();
                }
                else
                {
                    rounds++;
                }
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

        static bool isvalidInput(string[] input)
        {

            return false;
        }

    }
}