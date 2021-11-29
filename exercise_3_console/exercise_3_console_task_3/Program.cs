using System;

namespace exercise_3_console_task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double startValue = GetInput("\n\tEnter start   value   (a): ");
            double stopValue = GetInput("\n\tEnter end     value   (b): ");
            double stepValue = GetInput("\n\tEnter step    value   (h): ");

            Console.WriteLine("\nFunc calculations:");

            for (double i = startValue,bufY=0; i < stopValue; i += stepValue)
            {
                CalculateFuncValue(i,out bufY);
                Console.WriteLine($"\nvalue\tx = {i:0.##}\n\ty = {bufY:0.##}");
            }

        }
        static void CalculateFuncValue(double x,out double y)
        {
            if (x + 2 <= 1)
            {
                y = x * x;
            }
            else if ((x + 2) < 10)
            {
                y = 1 / (x + 2);
            }
            else
            {
                y= x + 2;
            }
        }
        static double GetInput(string message)
        {
            string input = String.Empty;
            double outData = 0;
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
