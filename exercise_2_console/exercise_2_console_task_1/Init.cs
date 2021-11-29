using System;
using System.ComponentModel;

namespace exercise_2_console_task_1
{
    // класс для запуска кода задачи
    class Init
    {
        // поля класса
        Vector2 inputPoint;
        Vector2 squareSizes;
        Vector2 squarePosition;
        
        // конструктор по умолчанию
        public Init()
        {
            
        }
        // меод для запуска кода программы
        public void StartProgram()
        {
            GetData();              // получение входных данных

            Console.Write("\n\tPoint collide with square: ");

            // определение колизии точки и площади
            switch (CheckToCollidePointToSquare(inputPoint, squarePosition, squareSizes))
            {
                case 1:
                    {
                        Console.WriteLine("YES");
                    }break;
                case 0:
                    {
                        Console.WriteLine("On border");
                    }
                    break;
                case -1:
                    {
                        Console.WriteLine("NO");
                    }
                    break;
            }

        }
        // метод для проверки нахождения точки в определённой площади
        private int CheckToCollidePointToSquare(Vector2 checkingPoint,Vector2 squarePosition,Vector2 squareSize)
        {
            Vector2 xSquareBorders=new Vector2((squarePosition.X-(squareSize.X/2)), (squarePosition.X + (squareSize.X / 2)));
            Vector2 ySquareBorders= new Vector2((squarePosition.Y - (squareSize.Y / 2)), (squarePosition.Y + (squareSize.Y / 2)));

            // если точка лежит в диапозоне x и y площади
            if (
                checkingPoint.X > xSquareBorders.X && checkingPoint.X < xSquareBorders.Y &&
                checkingPoint.Y > ySquareBorders.X && checkingPoint.Y < ySquareBorders.Y)
            {
                return 1;
            }
            else if ((
                (checkingPoint.X == xSquareBorders.X || checkingPoint.X == xSquareBorders.Y) &&
                (checkingPoint.Y > ySquareBorders.X && checkingPoint.Y < ySquareBorders.Y)) ||
                (checkingPoint.X > xSquareBorders.X && checkingPoint.X < xSquareBorders.Y) &&
                (checkingPoint.Y == ySquareBorders.X || checkingPoint.Y == ySquareBorders.Y))
            {
                return 0;
            }
            else
            {
                return -1;
            }

        }
        // метод для получения данных точек
        private void GetData()
        {
            EnterPoint();
            squareSizes= EnterVector2("Size");
            squarePosition= EnterVector2("Position of square");
        }

        // метод для получения координаты точеки
        private void EnterPoint()
        {
            // кэшированные переменные координат точек
            float xCoord;
            float yCoord;

            ConsoleDataInput<float>($"\n\tPoint, enter X coord value: ", out xCoord);
            ConsoleDataInput<float>($"\tPoint, enter Y coord value: ", out yCoord);

            inputPoint = new Vector2(xCoord, yCoord);
        }
        private Vector2 EnterVector2(string message)
        {
            // кэшированные переменные координат точек
            float xCoord;
            float yCoord;

            ConsoleDataInput<float>($"\n\t{message}, enter X value: ", out xCoord);
            ConsoleDataInput<float>($"\t{message}, enter Y value: ", out yCoord);

            return new Vector2(xCoord, yCoord);
        }

        // метод для организации консольного ввода
        private void ConsoleDataInput<T>(string repitableMessage,out T data)
        {
            do
            {
                Console.Write(repitableMessage);
            } while (!TypeParser<T>(Console.ReadLine(),out data));
        }
        // метод для конвертации строки в определённый тип дпнных
        private static bool TypeParser<T>(string input,out T data)
        {
            // обработка исключения
            try
            {
                // получение преобразователя типов для определённого типа
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

                // преобразование в шаблонный тип из строки
                data=(T)converter.ConvertFromString(input);
                return true;
            }
            // вылавливание исключения
            catch
            {
                Console.WriteLine("\t\t\tIncorrect input");
                data = default(T);

                return false;
            }
        }
    }
}
