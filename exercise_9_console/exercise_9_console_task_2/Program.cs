using System;

namespace exercise_9_console_task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("\n\tEnter file path: ");

                TxtReader reader = new TxtReader();

                reader.filePath = Console.ReadLine();

                reader.GetAllSpacedContainsLines();
                Console.WriteLine(reader.result);
            }
            catch
            {
                Console.Write("\n\tIncorrect input");
            }
        }
    }
}
