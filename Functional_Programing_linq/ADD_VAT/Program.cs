using System;
using System.Linq;

namespace ADD_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(", ").Select(x => double.Parse(x) * 1.20);
            foreach (var item in list)
            {
                Console.WriteLine($"{item:f2}");
            }
        }
    }
}
