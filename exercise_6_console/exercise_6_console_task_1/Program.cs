using System;
using System.Text;

namespace exercise_6_console_task_1
{
    class Program
    {
        static Random randomValue = new Random();
        static void Main(string[] args)
        {

            int topRangeValue = UserInput("\n\tEnter top range value: ");
            int bottomRangeValue = UserInput("\n\tEnter bottom range value: ");

            int arraySize = UserInput("\n\tEnter array size: ");
            int[] arr = GetArray(arraySize);

            Console.WriteLine();
            Console.WriteLine(CoutArr(arr));

            Console.WriteLine($"\n\n\tNumber of avoid range values in array: {CountNumberOfAvoidRangeArr(arr, topRangeValue, bottomRangeValue)}");

            int n = UserInput("\n\tEnter matrix size n: ");
            int m = UserInput("\n\tEnter matrix size m: ");

            int[,] matrix = GetMatrix(n, m);

            Console.WriteLine();
            Console.WriteLine(CoutMatr(matrix));

            Console.WriteLine($"\n\tNumber of avoid range values in matrix: {CountNumberOfAvoidRangeMatrix(matrix, topRangeValue, bottomRangeValue)}");
        }
        static string CoutArr(int[]arr)
        {
            StringBuilder outData = new StringBuilder();

            for (int i = 0; i < arr.Length; i++)
            {
                outData.Append($" {arr[i]}");
            }

            return outData.ToString();
        }
        static string CoutMatr(int[,]matr)
        {
            StringBuilder outData = new StringBuilder();

            for (int i = 0; i < matr.GetLength(0); i++)
            {
                outData.Append("\n");
                for (int j = 0; j < matr.GetLength(1); j++)
                { 
                    outData.Append($"\t{matr[i,j]}");
                }
            }

            return outData.ToString();
        }
        static int CountNumberOfAvoidRangeArr(int[] arr,int aRange,int bRange)
        {
            int count=0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < aRange || arr[i] > bRange)
                {
                    ++count;
                }
            }
            return count;
        }
        static int CountNumberOfAvoidRangeMatrix(int[,] matr, int aRange, int bRange)
        {
            int count = 0;

            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    if (matr[i,j] < aRange || matr[i,j] > bRange)
                    {
                        ++count;
                    }
                }
            }

            return count;
        }
        static int[,] GetMatrix(int n, int m)
        {
            int[,] matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for(int j=0;j<m;j++)
                {
                    matrix[i, j] = randomValue.Next(-50, 50);
                }
            }

            return matrix;
        }
        static int[] GetArray(int arraySize)
        {
            int[] arr=new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                arr[i] = randomValue.Next(-50,50);
            }
            return arr;
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
