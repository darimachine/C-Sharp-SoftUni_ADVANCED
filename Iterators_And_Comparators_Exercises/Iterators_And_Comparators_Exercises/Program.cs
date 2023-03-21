using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Iterators_And_Comparators_Exercises
{
    class ListyIterator<T> : IEnumerable<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        private int index=0;
        public ListyIterator(List<T> items)
        {
            this.Items = items;
        }
        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }
            return false;
            
        }
        public bool HasNext()
        {
            if (index >= Items.Count-1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Print()
        {
            CheckList();
            Console.WriteLine(Items[index]);
        }
        public void CheckList()
        {
            if (Items.Count == 0)
            {
                throw new NullReferenceException("Invalid Operation!");
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            CheckList();
            for (int i = 0; i < Items.Count; i++)
            {
                yield return Items[i];
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
            string command = Console.ReadLine();
            ListyIterator<string> listy = null;
            while (command != "END")
            {
                var token = command.Split(" ");
                if (token[0] == "Create")
                {
                    listy = new ListyIterator<string>(token.Skip(1).ToList());
                }
                else if (token[0] == "Move")
                {
                    Console.WriteLine(listy.Move());
                }
                else if (token[0] == "Print")
                {
                    listy.Print();
                }
                else if (token[0] == "HasNext")
                {
                    Console.WriteLine(listy.HasNext());
                }
                else if (token[0] == "PrintAll")
                {
                    foreach (var item in listy)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                }
                command = Console.ReadLine();
                
            }
           
        }
    }
}
