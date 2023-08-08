using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using ConsoleTables;
using System.Threading.Tasks;

namespace task3
{
    internal class UserInterface
    {
        static public void showHelp()
        { 
            ConsoleTable table = new ConsoleTable();
            
            Console.WriteLine();
        }
        static public void showActions()
        {
            Console.WriteLine("Available moves:");
            for(int i = 0; i < MoveGenerator.moves.Length; i++) {
                Console.WriteLine($"{i + 1} - {MoveGenerator.moves[i]}");
            }
            Console.WriteLine("0 - Exit\n? - Help me please");
        }
    }
}
