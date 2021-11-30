using System;

namespace exercise_4_console_task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int summ=0;
            int binaryDigit = UserInput("\n\tEnter binary number: ");
            
            foo(binaryDigit,ref summ);
        }
        static void foo(int binaryNumber,ref int summ, int iter = 0)
        {
            if (binaryNumber / 10 != 0||binaryNumber==1)
            {
                summ += (binaryNumber % 10 * (int)Math.Pow(2, iter));
                foo(binaryNumber / 10,ref summ,iter+1);
            }
            if(iter==0)
            {
                Console.WriteLine(summ);
            }
        }
        static int UserInput(string message)
        {
            int input = 0;
            string userInp=String.Empty;
            do
            {
                Console.Write(message);
                userInp = Console.ReadLine();
                if (int.TryParse(userInp, out input)&&ChekValToBinary(userInp))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\tIncorrect input");
                }
            }
            while (true);

            return input;
        }
        static bool ChekValToBinary(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if ((value[i] != '0') && (value[i] != '1'))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
