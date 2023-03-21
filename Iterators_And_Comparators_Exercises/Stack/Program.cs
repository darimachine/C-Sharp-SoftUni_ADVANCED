using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    class MyStack<T> : IEnumerable<T>
    {
        private List<T> array  = new List<T>();
        private int count;
        public void Push( T element)
        {
            array.Add(element);
            count++;
        }
        public T Pop()
        {
           
            if (count <= 0)
            {
                
                Console.WriteLine("No elements");
                return default(T);
                
            }
            else
            {
                var currentelement = array[--count];
                array.Remove(currentelement);
                return currentelement;

            }
           

        }

        public IEnumerator<T> GetEnumerator()
        {
            array.Reverse();
            foreach (var item in array)
            {
                yield return item;
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
            MyStack<int> stack = new MyStack<int>();
            string command = Console.ReadLine();
            while (command != "END")
            {
                var token = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if( token[0] == "Push")
                {
                    foreach (var item in token.Skip(1))
                    {
                        stack.Push(int.Parse(item.Replace(",","")));
                    }
                   
                }
                if (token[0] == "Pop")
                {
                    stack.Pop();
                }

                command = Console.ReadLine();
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        
        }
    }
}
