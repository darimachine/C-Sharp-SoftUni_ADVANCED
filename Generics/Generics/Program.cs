using System;

namespace Generics
{
    partial class Program
    {
        class EqualityScale<T> //where T: class
        {
            private T left;
            private T right;
            public EqualityScale(T left,T right)             {
                this.left = left;
                this.right = right;
            }
            public bool AreEqual<T>() 
            {
                
                return left.Equals(right);
            }
        }
        class Pair<T>
        {
            public Pair()
            {

            }
            public T First { get; set; }
        }
        static void Main(string[] args)
        {
            Box<int> a = new Box<int>();
            a.Add(3);
            a.Add(5);
            a.Remove();
            Console.WriteLine(a.Count);
        }
        static public T[] CreateArray<T>(int count,T element)
        {
            T[] result = new T[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = element;
            }
            return result;
        }
    }
}
