using System;
using System.Text;

namespace exercise_6_console_task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrSize = UserInput("\n\tEnter matr size: ");
            int n = UserInput("\n\tEnter degree: ");
            Matrix matr1 = new Matrix(matrSize);
            
            Console.WriteLine();
            Console.WriteLine(CoutMatr(matr1));

            for (int i = 1; i < n; i++)
            {
                matr1= matr1 * matr1;
                
            }

            Console.WriteLine();
            Console.WriteLine(CoutMatr(matr1));
        }
        static string CoutMatr(Matrix matr)
        {
            StringBuilder outData = new StringBuilder();

            for (int i = 0; i < matr.GetLength; i++)
            {
                outData.Append("\n");
                for (int j = 0; j < matr.GetLength; j++)
                {
                    outData.Append($"\t{matr[i, j]}");
                }
            }

            return outData.ToString();
        }
        static int UserInput(string message)
        {
            int result;
            do
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\tIncorrect input");
                }
            }
            while (true);
            return result;
        }
    }
}
