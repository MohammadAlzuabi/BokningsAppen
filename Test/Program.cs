using System.Globalization;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime date = DateTime.Today.AddDays(7);
            Console.WriteLine(date);
            DateTime dt = new DateTime(2020, 1, 21);
            Calendar cal = new CultureInfo("en-SE").Calendar;
            int week = cal.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            Console.WriteLine($"Vecka {week} {Calendar.ReadOnly}");


        }
    
    }
}