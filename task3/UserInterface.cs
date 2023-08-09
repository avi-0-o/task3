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
            string[] ColNames1 = { "User\\Computer" };
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
        static public void showResults(int[] userMoves, int[] computerMoves) // show result of rounds
        {
            if (userMoves is null || computerMoves is null)
            {
                Console.WriteLine("User or computer has no moves");
                return;
            }
            string[] Columns = { "User moves" }, Row = { "Computer moves" };
            Columns = Columns.Concat(MoveGenerator.ExtractMoves(userMoves)).ToArray();
            Row = Row.Concat(MoveGenerator.ExtractMoves(computerMoves)).ToArray();
            var table = new ConsoleTable(Columns);
            table.AddRow(Row);
            Row = new string[Row.Length];
            Row[0] = "Results";
            for (int i = 1; i < Row.Length; i++)
                Row[i] = Rules.GetWinner(userMoves[i - 1], computerMoves[i-1]);
            table.AddRow(Row);
            Console.WriteLine(table);
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
