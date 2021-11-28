using System;

namespace exercise_1_console
{
    // класс точки, для описания точки в программе
    class Point
    {
        // свойства класса, координаты точки
        public float X{ get; set; }
        public float Y{ get; set; }

        // конструктор с параметрами
        public Point(float x,float y)
        {
            X = x;
            Y = y;
        }
        // конструктор по умолчанию
        public Point()
        {
            X = 0;
            Y = 0;
        }
        public static float GetLengthBetweenPoints(Point pointOne,Point pointTwo)
        {
            return MathF.Sqrt(SquareNumber(pointTwo.X-pointOne.X)+SquareNumber(pointTwo.Y-pointOne.Y));
        }
        private static float SquareNumber(float number)
        {
            return number * number;
        }
    }
}
