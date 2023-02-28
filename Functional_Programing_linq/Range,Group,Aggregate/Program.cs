using System;
using System.Linq;
namespace Range_Group_Aggregate
{
    class Program
    {
        static void Main(string[] args)
        {
           var numbers = Enumerable.Range(1, 10);
            // GROUP
            //var n = numbers.GroupBy(x => x.ToString().Length);
            // foreach (var item in n)
            // {
            //     Console.WriteLine(item.Key+" " + item.Average());
            // }

            int num = numbers.Aggregate(0, (sum, x) => sum + x);
            Console.WriteLine(num);
        }
    }
}
