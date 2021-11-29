using System;
using System.Text.RegularExpressions;

namespace exercise_2_console_task_3
{
    class Program
    {
        delegate bool Validate(bool result);
        static void Main(string[] args)
        {
            string input;
            ValidateUserInput(@"^\d\s\d$", out input, "\nEnter last checkable didgits in format(X Y): ");
            string[] digits =input.Split(' ');
            

            int X = int.Parse(digits[0]);
            int Y= int.Parse(digits[1]);

            ValidateUserInput(@"^\d+\s\d+$", out input, "\nEnter range in format (A B): ");

            digits = input.Split(' ');

            int A = int.Parse(digits[0]);
            int B= int.Parse(digits[1]);
            
            int iter = A;

            Console.WriteLine("\n\twhile: ");
            iter = A;
            while (iter<B)
            {
                if (iter % 10 == X || iter % 10 == Y)
                {
                    Console.WriteLine(String.Concat("\t", iter));
                }
                ++iter;
            }
            Console.WriteLine("\n\tdo while: ");
            iter = A;
            do
            {
                if (iter % 10 == X || iter % 10 == Y)
                {
                    Console.WriteLine(String.Concat("\t", iter));
                }
                ++iter;
            }
            while (iter<B);
            Console.WriteLine("\n\tfor: ");
            for (iter = A; iter < B; iter++)
            {
                if (iter % 10 == X || iter % 10 == Y)
                {
                    Console.WriteLine(String.Concat("\t", iter));
                }
            }
        }
        static void ValidateUserInput(string regex,out string input,string message)
        {

            Validate validate = (result) =>
            {
                if (!result)
                {
                    Console.WriteLine("\tIncorrect input");
                }
                return !result;
            };
            // пользователский ввод
            do
            {
                Console.Write(message);
                input = Console.ReadLine();
            } while (validate(Regex.IsMatch(input,regex)));

        }
    }
}
