using System;

namespace exercise_12_console_task_1
{
    class CustomDate
    {
        public DateTime m_dateTime { get; set; }
        public bool IsLeap
        {
            get
            {
                return DateTime.IsLeapYear(m_dateTime.Year);
            }
        }
        // объявление индексатора
        public DateTime this[int index]
        {
            get
            {
                return m_dateTime.AddDays(index);
            }

        }

        // конструктор с параметром
        public CustomDate(DateTime date)
        {
            m_dateTime = date;
        }
        // конструктор по умлочнаию
        public CustomDate()
        {
            m_dateTime = new DateTime(2009, 1, 1);
        }

        // перегрузка унарного оператора
        public static bool operator !(CustomDate date)
        {
            return date.m_dateTime.Day != DateTime.DaysInMonth(date.m_dateTime.Year, date.m_dateTime.Month);
        }

        // перегрузка операторов true false
        public static bool operator true(CustomDate date)
        {
            return date.m_dateTime.Day == 1 && date.m_dateTime.Month == 1 ? true : false;
        }
        public static bool operator false(CustomDate date)
        {
            return date.m_dateTime.Day == 1 && date.m_dateTime.Month == 1 ? true : false;
        }
        // перегрузка опреации &
        public static bool operator &(CustomDate dateOne, CustomDate dateTwo)
        {
            return dateOne.m_dateTime.Equals(dateTwo.m_dateTime);
        }
        // перегрузка метода ToString()
        public override string ToString()
        {
            return m_dateTime.ToString();
        }
        public static explicit operator string(CustomDate date)
        {
            return date.ToString();
        }
        public static explicit operator CustomDate(string date)
        {
            return new CustomDate(DateTime.Parse(date));
        }
        // метод для получения даты предыдущего дня
        public DateTime GetPreviousDayDate()
        {
             return m_dateTime.AddDays(-1);
        }
        // метод для получения даты следующего дня
        public DateTime GetNextDayDate()
        {
            return m_dateTime.AddDays(1);
        }
        // метод для получения количества дней до конца месяца
        public int CountDaysToEndOfMonth()
        {
            return DateTime.DaysInMonth(m_dateTime.Year,m_dateTime.Month)-m_dateTime.Day;
        }

    }
}
