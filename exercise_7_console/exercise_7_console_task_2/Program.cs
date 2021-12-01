using System;

namespace exercise_7_console_task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n\tEnter string: ");
            string inputString = Console.ReadLine();

            string[] words = inputString.Split(' ');

            int longestWordId=0;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[longestWordId].Length < words[i].Length)
                {
                    longestWordId = i;
                }
            }

            Console.WriteLine($"\n\tLongest word: {words[longestWordId]}");
        }
    }
}
