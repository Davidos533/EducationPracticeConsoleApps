using System;

namespace exercise_5_console_task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double startValue;
            double stopValue;
            double stepValue;

            startValue = UserInput("\n\tEnter start value: ");
            stopValue = UserInput("\n\tEnter stop value: ");
            stepValue = UserInput("\n\tEnter step value: ");

            for (double i = startValue; i < stopValue; i += stepValue)
            {
                try
                {
                    Console.Write($"\n\tx={i:0.###}, y={Func(i):0.###}");
                }
                catch
                {
                    Console.Write($"\n\tno roots");
                }
            }

        }
        static double Func(double x)
        {
            if (x - 2 <= 0)
            {
                throw new Exception();
            }
            else
            {
                return Math.Log(x-2);
            }
        }
        static double UserInput(string message)
        {
            double result;
            do
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out result))
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
