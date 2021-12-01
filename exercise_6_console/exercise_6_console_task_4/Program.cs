using System;
using System.Text;

namespace exercise_6_console_task_4
{
    class Program
    {
        // объект для генерации случайных чисел
        static Random randomValue = new Random();

        static void Main(string[] args)
        {
            int arraySize = UserInput("\n\tEnter array size: ");

            int[][] steppedArray=GetSteppedArray(arraySize);

            int[] evenNumbers = FindEvenNumbers(steppedArray);

            Console.WriteLine(CoutSteppedArray(steppedArray));

            evenNumbers= FindEvenNumbers(steppedArray);

            Console.WriteLine(CoutArr(evenNumbers));

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
        static string CoutSteppedArray(int[][] steppedArray)
        {
            StringBuilder outData = new StringBuilder();

            for (int i = 0; i < steppedArray.GetLength(0); i++)
            {
                for (int j = 0; j < steppedArray.GetLength(0); j++)
                {
                    outData.Append($"\t{steppedArray[i][j]}");
                }
                outData.Append("\n");
            }
            return outData.ToString();

        }
        static int[] FindEvenNumbers(int[][] steppedArray)
        {
            int[] evenNumbers = new int[steppedArray.GetLength(0)];

            for (int i = 0; i < steppedArray.GetLength(0); i++)
            {
                for (int j = 0; j < steppedArray.GetLength(0); j++)
                {
                    if (steppedArray[i][j] % 2 == 0)
                    {
                        evenNumbers[i] = steppedArray[i][j];
                    }
                }
            }

            return evenNumbers;

        }
        // получение ступенчатого массива по заданному размеру заполненного случайными числами
        static int[][] GetSteppedArray(int arraySize)
        {
            int[][] arr = new int[arraySize][];     // инициализация массвиа

            // инициализация строк ступенчатого массива
            for (int i = 0; i < arraySize; i++)
            {
                arr[i] = new int[arraySize];
                // заполнение строки ступенчатого массива случайными значениями
                for (int j = 0; j < arraySize; j++)
                {
                    arr[i][j] = randomValue.Next(-50, 50);
                }
            }
            return arr;
        }
        // обработка польззовательского ввода
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
