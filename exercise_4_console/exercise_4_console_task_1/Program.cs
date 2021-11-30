using System;

namespace exercise_4_console_task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            int x;

            n = UserInput("\n\tEnter n:");
            x= UserInput("\n\tEnter x:");

            Console.WriteLine($"\n\tResult:{foo(x, n)}");
        }
        static double foo(double x,int n,int counter=1)
        {
            if (counter != n)
            {
                return x / (counter + foo(x, n, counter + 1));
            }
            else
            {
                 return counter + x;
            }
        }
        static int UserInput(string message)
        {
            int input=0;
            do
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    break;
                }
                else
                {
                    Console.Write("\n\tIncorrect input");
                }
            }
            while (true);

            return input;
        }
        
    }
}
