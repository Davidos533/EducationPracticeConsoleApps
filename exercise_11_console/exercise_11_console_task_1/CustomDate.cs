using System;

namespace exercise_11_console_task_1
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
        // конструктор с параметром
        public CustomDate(DateTime date)
        {
            m_dateTime = date;
        }
        // конструктор по умлочнаию
        public CustomDate()
        {
            m_dateTime = new DateTime(2009,1,1);
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
