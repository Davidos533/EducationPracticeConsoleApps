using System;

namespace exercise_12_console_task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomDate customDate;
            CustomDate customDateForCompare;

            customDate= UserInput("\n\tEnter date: ");

            // демонстрация работы индексатора
            Console.WriteLine($"The date above three day by now date: {customDate[3].ToString("dd/MM/yy")} \nThe date down five day by now date: {customDate[-5].ToString("dd/MM/yy")}");

            // демонстрация унарного опреатора !
            Console.WriteLine($"Is this day not the last day of month: {(!customDate?"yes":"no")}");

            // демонстрация операторов true false
            Console.WriteLine($"Is this date is year start: {(customDate?"yes":"no")}");

            customDateForCompare = UserInput("\n\tEnter date for compare: ");

            // демонстрация оператора &
            Console.WriteLine($"Is dates equals: {(customDate&customDateForCompare?"yes":"no")}");

            string strDate = (string)customDate;

            // демонстрация опреаторов преобразования типов
            Console.WriteLine($"Explicit date from customDate to string: {strDate}");

            Console.WriteLine($"Explicit date from string to CustomDate: {(CustomDate)strDate}");


        }
        static CustomDate UserInput(string message)
        {
            do
            {
                try
                {
                    Console.Write(message);
                    return new CustomDate(DateTime.Parse(Console.ReadLine()));
                }
                catch
                {
                    Console.Write("\tIncorrect input\n");
                }
            }
            while (true);
         }
    }
}