using System;

namespace exercise_3_console_task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number=0;
            do
            {
                Console.Write("\n\tEnter number: ");
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    Console.WriteLine(String.Concat("\n\tResult: ",func(number)));
                }
                else
                {
                    break;
                }
            }
            while (true);
            Console.WriteLine("Finished");
        }
        static int func(int number)
        {
            if (number % 5 == 0)
            {
                return number / 5;
            }
            else
            {
                return number + 1;
            }
        }
    }
}
