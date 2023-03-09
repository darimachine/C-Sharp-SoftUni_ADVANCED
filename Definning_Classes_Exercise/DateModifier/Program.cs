using System;

namespace DateModifier
{
    public class DateModifier
    {
        private int differenceInDays;

        public int DifferenceInDays
        {
            get { return differenceInDays; }
        }

        public void CalculateDifference(string date1, string date2)
        {
            DateTime dt1 = DateTime.Parse(date1);
            DateTime dt2 = DateTime.Parse(date2);

            differenceInDays = (int)(dt2 - dt1).TotalDays;
            Console.WriteLine(Math.Abs(DifferenceInDays));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DateModifier date = new DateModifier();
            var date1 = Console.ReadLine().Split(" ");
            var date2 = Console.ReadLine().Split(" ");
            string formated_date1 = string.Join("-", date1);
            string formated_date2 = string.Join("-", date2);
            date.CalculateDifference(formated_date1, formated_date2);

        }
    }
}
