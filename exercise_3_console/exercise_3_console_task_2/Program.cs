using System;

namespace exercise_3_console_task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double startValue=GetInput("\n\tEnter start   value   (a): ");
            double stopValue=GetInput("\n\tEnter end     value   (b): ");
            double stepValue=GetInput("\n\tEnter step    value   (h): ");

            Console.WriteLine("\nFunc calculations:");

            for (double i = startValue; i < stopValue; i += stepValue)
            {
                Console.WriteLine($"\nvalue\tx = {i:0.##}\n\ty = {CalculateFuncValue(i):0.##}");
            }

        }
        static double CalculateFuncValue(double x)
        {
            if (x + 2 <= 1)
            {
                return x * x;
            }
            else if ((x + 2) < 10)
            {
                return 1 / (x + 2);
            }
            else
            {
                return x + 2;
            }
        }
        static double GetInput(string message)
        {
            string input=String.Empty;
            double outData=0;
            do
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out outData))
                {
                    break;
                }
                else
                {
                    Console.Write("\n\tIncorrect input");
                }
            } 
            while (true);

            return outData;
        }
    }
}
