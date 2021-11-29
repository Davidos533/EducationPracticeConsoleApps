using System;
using System.Text.RegularExpressions;

namespace exercise_2_console_task_2
{
    class Program
    {
        delegate bool Validate(bool result);
        static void Main(string[] args)
        {
            int[] monthsDays = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            Validate validate = (result) =>
              {
                  if (!result)
                  {
                      Console.WriteLine("\tIncorrect input");
                  }
                  return !result;
              };
            string input = String.Empty;
            // пользователский ввод
            do
            {
                Console.Write("\n\tEnter today date in forman DD.MM.YYYY: ");
                input = Console.ReadLine();
            } while (validate(Regex.IsMatch(input, @"^(\d{2}\.){2}\d{4}$")));

            // получение дат
            string[] dateElemets = input.Split('.');
            int day = int.Parse(dateElemets[0]);
            int month = int.Parse(dateElemets[1]);
            int year = int.Parse(dateElemets[2]);

            do
            {
                Console.Write("\n\tEnter number of days: ");
                input = Console.ReadLine();
            } while (validate(Regex.IsMatch(input, @"^\d+$")));

            int days = int.Parse(input);

            // если год не високосный и количество дней больше или равно года
            while (true)
            {
                if (year % 4 != 0 && days >= Summ(monthsDays))
                {
                    days -= Summ(monthsDays);
                }
                else if (year % 4 == 0 && days >= Summ(monthsDays) + 1)
                {

                    days -= Summ(monthsDays) + 1;
                }
                else
                {
                    break;
                }
                --year;
            }

            // если дней >= чем минимальная длина месяца при учёти вескосности года
            while((days >=28&&year%4!=0)||(days>=29&&year%4==0))
            {
                switch (month)
                {
                    case 1:
                        {
                            if (days >= monthsDays[month])
                            {
                                month = 12;
                                days -= monthsDays[month];
                            }
                            else
                            {
                                day -= days;
                                days = 0;
                            }
                        } break;
                    case 2: 
                        {
                            if (days >= monthsDays[month])
                            {
                                month = 1;
                                if (year % 4 != 0)
                                {
                                    days -= monthsDays[month];
                                }
                                else
                                { 
                                    days -= monthsDays[month]+1;
                                }
                            }
                            else
                            {
                                day -= days;
                                days = 0;
                            }
                        }
                        break;
                    case 3: 
                        {
                            if (days >= monthsDays[month])
                            {
                                month = 2;
                                days -= monthsDays[month];
                            }
                            else
                            {
                                day -= days;
                                days = 0;
                            }
                        } 
                        break;
                    case 4:
                        {
                            if (days >= monthsDays[month])
                            {
                                month = 3;
                                days -= monthsDays[month];
                            }
                            else
                            {
                                day -= days;
                                days = 0;
                            }
                        }
                        break;
                    case 5:
                        {
                            if (days >= monthsDays[month])
                            {
                                month = 4;
                                days -= monthsDays[month];
                            }
                            else
                            {
                                day -= days;
                                days = 0;
                            }
                        }
                        break;
                    case 6:
                        {
                            if (days >= monthsDays[month])
                            {
                                month = 5;
                                days -= monthsDays[month];
                            }
                            else
                            {
                                day -= days;
                                days = 0;
                            }
                        }
                        break;
                    case 7:
                        {
                            if (days >= monthsDays[month])
                            {
                                month = 6;
                                days -= monthsDays[month];
                            }
                            else
                            {
                                day -= days;
                                days = 0;
                            }
                        }
                        break;
                    case 8:
                        {
                            if (days >= monthsDays[month])
                            {
                                month = 7;
                                days -= monthsDays[month];
                            }
                            else
                            {
                                day -= days;
                                days = 0;
                            }
                        }
                        break;
                    case 9:
                        {
                            if (days >= monthsDays[month])
                            {
                                month = 8;
                                days -= monthsDays[month];
                            }
                            else
                            {
                                day -= days;
                                days = 0;
                            }
                        }
                        break;
                    case 10:
                        {
                            if (days >= monthsDays[month])
                            {
                                month = 9;
                                days -= monthsDays[month];
                            }
                            else
                            {
                                day -= days;
                                days = 0;
                            }
                        }
                        break;
                    case 11:
                        {
                            if (days >= monthsDays[month])
                            {
                                month = 10;
                                days -= monthsDays[month];
                            }
                            else
                            {
                                day -= days;
                                days = 0;
                            }
                        }
                        break;
                    case 12:
                        {
                            if (days >= monthsDays[month])
                            {
                                month = 11;
                                days -= monthsDays[month];
                            }
                            else
                            {
                                day -= days;
                                days = 0;
                            }
                        }
                        break;
                }
            }

            if (days > 0)
            {
                day -= days;
            }
            Console.WriteLine($"\n\tDate: {day}.{month}.{year}");

        }
        static int Summ(int[] arr)
        {
            int summ=0;
            for (int i = 0; i < arr.Length; i++)
            {
                summ += arr[i];
            }
            return summ;
        }
    }
}
