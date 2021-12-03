using System;

namespace exercise_11_console_task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomDate custonDate;
            DateTime buf;
            do
            {
                try
                {
                    Console.Write("\n\tEnter date: ");
                    buf = DateTime.Parse(Console.ReadLine());
                    
                    custonDate = new CustomDate(buf);
                    
                    break;
                }
                catch
                {
                    Console.Write("\tIncorrect input\n");
                }
            }
            while (true);

            Console.WriteLine($"Date: {custonDate.m_dateTime.ToString().Substring(0, 10)}");
            Console.WriteLine($"This year {(custonDate.IsLeap?"":"not")} leap");

            custonDate.m_dateTime = DateTime.Today;

            Console.WriteLine($"\nDate: {custonDate.m_dateTime.ToString().Substring(0, 10)}");
            Console.WriteLine($"This year {(custonDate.IsLeap?"":"not")} leap");

            Console.WriteLine($"Previous day: {custonDate.GetPreviousDayDate().ToString().Substring(0,10)}");

            Console.WriteLine($"Next day: {custonDate.GetNextDayDate().ToString().Substring(0, 10)}");
            
            Console.WriteLine($"Days to end of month: {custonDate.CountDaysToEndOfMonth()}");
            
        }
        
    }
}
