using System;
using System.ComponentModel;

namespace exercise_1_console
{
    // класс для запуска кода задачи
    class Init
    {
        // поля класса
        private int m_numberOfFigurePoints;
        private Point[] m_figurePoints;
        private float m_perimetr;

        // конструктор по умолчанию
        public Init()
        {
            m_numberOfFigurePoints = 0;
            m_perimetr = 0;
        }
        // меод для запуска кода программы
        public void StartProgram()
        {
            GetData();              // получение входных данных
            
            CalculatePerimeter();   // вычислеие периметра фигуры

            Console.WriteLine($"\n\tFigure perimetr equal: {m_perimetr}");
        }
        // метод для получения данных точек
        private void GetData()
        {
            ConsoleDataInput<int>("\n\tEnter number of points for figure: ", out m_numberOfFigurePoints);
            m_numberOfFigurePoints = Math.Abs(m_numberOfFigurePoints);
            Console.WriteLine($"\tNumber of figure points {m_numberOfFigurePoints}");
                        
            EnterPoints();          // инициализация точек массива
        }
        private void CalculatePerimeter()
        {
            // вычисление периметра фигруы, итераций на 1 меьше чем точек
            for (int i = 0; i < m_numberOfFigurePoints-1; i++)
            {
                 m_perimetr+=Point.GetLengthBetweenPoints(m_figurePoints[i],m_figurePoints[i+1]);
            }
            // + замыкающая длина, между начальной и конечной точками
            m_perimetr += Point.GetLengthBetweenPoints(m_figurePoints[0], m_figurePoints[m_numberOfFigurePoints - 1]);
        }
        // метод для получения координат точек
        private void EnterPoints()
        {
            // иициализация массива точек
            m_figurePoints = new Point[m_numberOfFigurePoints];

            // кэшированные переменные координат точек
            float xCoord;
            float yCoord;

            // цикл заполнения массива точек
            for (int i = 0; i < m_numberOfFigurePoints; i++)
            {
                // получение координат точки
                ConsoleDataInput<float>($"\n\tPoint {i+1}, enter X coord value: ",out xCoord);
                ConsoleDataInput<float>($"\tPoint {i+1}, enter Y coord value: ",out yCoord);

                // инициализация точки
                m_figurePoints[i] = new Point(xCoord,yCoord);
            }
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
