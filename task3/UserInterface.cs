using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using ConsoleTables;
using System.Threading.Tasks;
using System.Reflection;

namespace task3
{
    internal class UserInterface
    {
        static public void showHelp()
        {
            string[] ColNames1 = { "PC\\User" };
            string[] ColNames = ColNames1.Concat(MoveGenerator.moves).ToArray();

            var table = new ConsoleTable(ColNames);

            for (int i = 1; i < ColNames.Length; i++)
            {
                string[] Row = new String[ColNames.Length];
                for (int j = 0; j < ColNames.Length; j++)
                {
                    if (j == 0)
                    {
                        Row[j] = ColNames[i];
                    }
                    else
                        Row[j] = Rules.GetWinner(i - 1, j - 1);
                }
                table.AddRow(Row);
            }
            Console.WriteLine(table);
        }
        static public void showResults(int[] userMoves, int[] ComputerMoves) //on going
        {
            if (userMoves is null || ComputerMoves is null)
            {
                Console.WriteLine("User/computer has no moves");
                return;
            }
            string[] Columns = new string[userMoves.Length];
            Columns[0] = "Pc\\User";

            /*Columns = Columns.Concat();*/
            var table = new ConsoleTable(Columns);
            Console.WriteLine(table);
            /*            for (int i = 1; i < Columns.Length; i++)
                        {
                            string[] Row = new String[Columns.Length];
                            for (int j = 0; j < Columns.Length; j++)
                            {

                            }
                        }*/
        }
        static public void showActions()
        {
            Console.WriteLine("Available moves:");
            for (int i = 0; i < MoveGenerator.moves.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {MoveGenerator.moves[i]}");
            }
            Console.WriteLine("0 - Exit\n? - Help me please");
        }
    }
}
