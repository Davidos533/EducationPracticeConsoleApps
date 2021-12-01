using System;
using System.Text;

namespace exercise_7_console_task_1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("\n\tEnter string: ");
            StringBuilder inputString = new StringBuilder(Console.ReadLine());

            Console.Write("\n\tEnter editable substring: ");
            string editgSybstring =Console.ReadLine();

            Console.Write("\n\tEnter new substring: ");
            string newSubstring = Console.ReadLine();

            if (inputString.Length > 0&&editgSybstring.Length>0&&newSubstring.Length>0)
            { 
                inputString.Replace(editgSybstring, newSubstring);
            }

            Console.Write($"\n\t{inputString.ToString()}\n");
        }
    }
}
