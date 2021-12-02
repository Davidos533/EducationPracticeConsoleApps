using System;

namespace exercise_9_console_task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr = UserInputDoubleArr("\n\tEnter doubles: ");
            double border = UserInputDouble("\n\tEnter border: ");

            FileOperator fileOperator=new FileOperator("myFile.bin");

            fileOperator.MakeFileWith(arr);
            fileOperator.ReadFile(border);

        }
        static double[] UserInputDoubleArr(string message)
        {
            double[] arr;
            string input = String.Empty;
            do
            {
                Console.Write(message);
                input= Console.ReadLine();
                if (ConvertStrToArr(input,out arr))
                {
                    break;
                }
                else 
                {
                    Console.WriteLine("\n\tIncorrect input");
                }
            }
            while (true);

            return arr;
        }
        static double UserInputDouble(string message)
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
        static bool ConvertStrToArr(string input,out double[] arr)
        {
            try
            {
                string[] vals = input.Split(' ');
                arr =new double[vals.Length];
                for (int i=0;i<arr.Length ;i++)
                {
                    arr[i] = double.Parse(vals[i]);
                }
                return true;
            }
            catch
            {
                arr = new double[0];
                return false;
            }
        }
    }
}
