using System;
using System.Text;

namespace exercise_6_console_task_2
{
    class Program
    {
        static Random randomValue = new Random();
        static void Main(string[] args)
        {
            int arraySize = UserInput("\n\tEnter array size: ");
            int[] arr = GetArray(arraySize);

            Console.WriteLine(CoutArr(arr));

            Console.WriteLine($"\n\n\tLast minimum number: {GetNumberOfTheLastMinimumElemet(arr)}");
        }
        static int GetNumberOfTheLastMinimumElemet(int[] arr)
        {
            int bufIndex = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < bufIndex)
                {
                    bufIndex = arr[i];
                }
            }
            return bufIndex;
        }
        static string CoutArr(int[] arr)
        {
            StringBuilder outData = new StringBuilder();

            for (int i = 0; i < arr.Length; i++)
            {
                outData.Append($" {arr[i]}");
            }

            return outData.ToString();
        }
        static int[] GetArray(int arraySize)
        {
            int[] arr = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                arr[i] = randomValue.Next(-50, 50);
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
