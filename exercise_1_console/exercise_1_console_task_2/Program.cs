using System;
using System.Text.RegularExpressions;

namespace exercise_1_console_task_2
{
    delegate bool Operation(bool parseRes);     // объявление делегата, возвращающего и принимающего тип bool

    class Program
    {
        static void Main(string[] args)
        {
            // делегат определённый лямбда функцией
            Operation opertaion = parsRes=>
              {
                  if (!parsRes)
                  { 
                    Console.WriteLine("Incorrect input");
                  }
                  return !parsRes;
              };

            int number=0;       // число введённое польщователем
            string input;       // строка введённая пользователем

            // валидация пользовательского ввода, до тех пор пока пользователь не введёт корректное для парсинга, число из 2-х цифр
            do
            {
                Console.Write("Enter number two digits number: ");
                input = Console.ReadLine();
            }
            while (opertaion(int.TryParse(input, out number)&& Regex.IsMatch(input, @"^\d{2}$")));

            // кэширование переменных первой и второй цифр числа
            int numberFirstPart = number / 10;
            int numberSecondPart = number % 10;

            // вывод представления сложения переменных
            Console.WriteLine($"{numberFirstPart} + {numberSecondPart} = {numberFirstPart+numberSecondPart}");

            // если сумма цифр числа при делении на 3 имеет остаток 0
            if ((numberFirstPart+ numberSecondPart) % 3 == 0)
            {
                // вывод собщения о том что сумма цифр числа кратна трём
                Console.WriteLine("Addition of number digits is multiple 3");
            }
            // иначе если сумма цифр числа при делении на 3 не имеет остаток 0
            else
            {
                // вывод сообщения о том что сумма цифр числа не кратна трём
                Console.WriteLine("Addition of number digits is multiple not 3");
            }
        }
    }
}
