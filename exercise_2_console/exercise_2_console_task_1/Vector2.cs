using System;

namespace exercise_2_console_task_1
{
    // класс точки, для описания точки в программе
    class Vector2
    {
        // свойства класса, координаты точки
        public float X{ get; set; }
        public float Y{ get; set; }

        // конструктор с параметрами
        public Vector2(float x,float y)
        {
            X = x;
            Y = y;
        }
        // конструктор по умолчанию
        public Vector2()
        {
            X = 0;
            Y = 0;
        }
        public static float GetLengthBetweenPoints(Vector2 pointOne,Vector2 pointTwo)
        {
            return MathF.Sqrt(SquareNumber(pointTwo.X-pointOne.X)+SquareNumber(pointTwo.Y-pointOne.Y));
        }
        private static float SquareNumber(float number)
        {
            return number * number;
        }
    }
}
