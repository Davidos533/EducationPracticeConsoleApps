using System;

namespace exercise_2_console_task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 7; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    Console.Write(String.Concat(" ",j));
                }
                Console.WriteLine();
            }
        }
    }
}
