using System;
using System.Text;
using System.Text.RegularExpressions;

namespace exercise_8_console_task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("\n\tEnter string with values: ");
                double summ;
                string outVal = GetSumm(Console.ReadLine(), out summ).Replace(" ", " + ");
                outVal = outVal.Substring(0, outVal.Length - 3);
                Console.Write($"\n\tResult: {outVal} = {summ}");
            }
            catch
            {
                Console.Write("\n\tError");
            }
        }
        static string GetSumm(string data, out double summ)
        {
            StringBuilder summValues = new StringBuilder();

            summ = 0;
            foreach (var number in Regex.Matches(data, @"-?\d+((,\d+[eE][+-]?\d+)|(,\d+))?"))
            {
                // если число экспоненциальное
                if (Regex.IsMatch(number.ToString(), @"-?\d+,\d+[eE][+-]?\d+"))
                {
                    // замена маленькой e на большую E
                    string val = number.ToString().Replace('e', 'E');
                    // если в числе остутствует + или - замена пустоты на +
                    if (val[val.IndexOf('E') + 1] != '+' && val[val.IndexOf('E') + 1] != '-')
                    {
                        val = val.Insert(val.IndexOf('E') + 1, "+");
                    }
                    summ += (double)decimal.Parse(val, System.Globalization.NumberStyles.Float);
                    summValues.Append($"{val} ");
                }
                else
                {
                    summ += double.Parse(number.ToString());
                    summValues.Append($"{number.ToString()} ");
                }
            }

            return summValues.ToString();

        }
    }
}
