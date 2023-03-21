using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    class Lake : IEnumerable<int>
    {
        private int[] masiv;
        public Lake(int[] array)
        {
            this.masiv = array;
        }
        public IEnumerator<int> GetEnumerator()
        {
            int k = 0;
            if (masiv.Length  % 2 == 0)
            {
                k = masiv.Length - 1;
            }
            else
            {
                k = masiv.Length - 2;
            }
            for (int i = 0; i < masiv.Length; i++)
            {
                if (i % 2 == 0)
                {
                    yield return masiv[i];
                }
                
                
            }
            for (int i = masiv.Length-1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return masiv[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Lake lake = new Lake(line);
            bool firsttime =true;
            foreach (var item in lake)
            {
                if (!firsttime)
                {
                    Console.Write(", ");
                }
                Console.Write(item);
                firsttime = false;
                
            }


        }
    }
}
