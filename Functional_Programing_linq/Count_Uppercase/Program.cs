using System;
using System.Linq;
namespace Count_Uppercase
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split(new char[] {' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
            var newLine = line.Where(x => char.IsUpper(x[0]));
            Console.WriteLine(string.Join(" ",newLine));
        }
    }
}
