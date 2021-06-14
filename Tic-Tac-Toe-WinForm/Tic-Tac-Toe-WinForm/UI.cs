using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02_Shahar_311359566_Nadav_312173776
{
    public class UI
    {
        public static void BoardPrinter(Board i_Board)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            StringBuilder rowBuilder = new StringBuilder();

            for (int i = 1; i <= i_Board.BoardSize; i++)
            {
                rowBuilder.Append("   " + i);
            }

            Console.WriteLine(rowBuilder);

            for (int i = 0; i < i_Board.BoardSize; i++)
            {
                rowBuilder.Clear();
                rowBuilder.Append((i + 1) + "|");
                for (int j = 0; j < i_Board.BoardSize; j++)
                {
                    if (i_Board.BoardMatrix[i, j] == Move.eTurn.EMPTY)
                    {
                        rowBuilder.Append("   |");
                    }
                    else
                    {
                        rowBuilder.Append($" {i_Board.BoardMatrix[i, j]} |");
                    }
                }

                Console.WriteLine(rowBuilder);
                rowBuilder.Clear();
                rowBuilder.Append(" =").Append('=', 4 * i_Board.BoardSize);
                Console.WriteLine(rowBuilder);
            }
        }

       

     

      

     

      

      

       
    }
}