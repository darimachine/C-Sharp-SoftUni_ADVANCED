using System.Collections.Generic;

namespace Generics
{
    partial class Program
    {
        class Box<T>
        {
            public int Count { get; private set; }
            private List<T> array = new List<T>();
            public void Add(T element)
            {
                array.Add(element);

                Count++;
            }
            public T Remove()
            {
                T element = array[--Count];
                array.Remove(element);
                return element;
            }
        }
    }
}
