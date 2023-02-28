using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional_Programing_linq
{
    class Program
    {
        static long Multiply(int a, int b)
        {
            return a * b;
        }
        static long Subtract(int a,int b)
        {
            return a - b;
        }
        static void Main(string[] args)
        {

            
            var list = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
          
            var numbers = new int[2] {1,2};
            Console.WriteLine( list.Sum());
            
           
            var newList = list.OrderBy(x => x).Where(x => x % 2 == 0);
           
            Console.WriteLine(string.Join(" ",string.Join(" ",newList)));
        }
        
        static IEnumerable<int> Where2(List<int> list , Func<int, bool> condition)
        {
            List<int> newList = new List<int>();
            foreach (var item in list)
            {
                if (condition(item))
                {
                    newList.Add(item);
                }
            }
            return newList;
        }
        static void PrintResult(int a ,int b,Func<int,int,long> func)
        {
            var result = func(a, b);
            Console.WriteLine(result);
        }
    }
}
