using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomStack
{
    class Stack<T> : IEnumerable<T>
    {
        private T[] items;
        public int Count { get; private set; }
        private const int InitialCapacity = 4;
        public Stack()
        {
            items = new T[InitialCapacity];
        }
        public void Push(T element)
        {
            if (Count == items.Length)
            {
                T[] temparray = new T[items.Length * 2];
                for (int i = 0; i < Count; i++)
                {
                    temparray[i] = items[i];
                }
                items = temparray;
            }
            
            items[Count++] = element;
        }
        public T Pop()
        {
            if (Count <= 0)
            {
                throw new InvalidOperationException();
            }
            var element = items[Count-1];
            items[Count--] = (T)Convert.ChangeType(0, typeof(T));
            if (Count <= items.Length / 4)
            {
                T[] temparray = new T[items.Length / 2];
                for (int i = 0; i < Count; i++)
                {
                    temparray[i] = items[i];
                }
                items = temparray;
            }
            return element;
        }
        public T Peek()
        {
            if (Count <= 0)
            {
                throw new InvalidOperationException();
            }
            return items[Count - 1];
        }
        public void Foreach(Action<T> action) 
        {
            for (int i = 0; i < Count; i++)
            {
                action(items[i]);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            stack.Push("mori");
            stack.Push("cheski");
            stack.Push("dopichivole");
            stack.Push("taktivole");
            stack.Push("aaaa");
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Count);
            stack.Foreach(x => Console.Write(x+" "));
            foreach (var item in stack)
            {

            }
        }
    }
}
