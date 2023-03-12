using System;

namespace ImplementingList
{
    class List<T>
    {
        private const int DefaultCapacity = 2;
        private int[] items;
        public int Count { get; private set; }
        public int this[int i]
        {
            get
            {
                IsInRange(i);
                return items[i];
            }
            set
            {
                IsInRange(i);
                items[i] = value;
            }
        }

     

        public List()
        {
            this.items = new int[DefaultCapacity];
        }
        public void Add(int element)
        {
            Resize();
            items[Count++] = element;
        }

       

        public void Print()
        {
            Console.WriteLine(string.Join(" ",items));
        }
        public int RemoveAt(int index)
        {
            if (index<0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Greshen indeks");
            }
            int element = items[index];
            items[index] = 0;
            //
            Count--;
            for (int i = index; i < Count; i++)
            {
                items[i] = items[i + 1];
            }
            
            //Shrink
            if (items.Length/4 >= Count)
            {
                int[] tempArray = new int[items.Length / 2];
                for (int i = 0; i < Count; i++)
                {
                    tempArray[i] = items[i];
                }
                items = tempArray;
            }
            return element;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == element)
                {
                    return true;
                }
            }
            return false;

        }
        public void Swap(int firstIndex,int secondIndex)
        {
            
            if(firstIndex<0 || firstIndex>=Count || secondIndex<0 || secondIndex >= Count)
            {
                throw new IndexOutOfRangeException("Greshen indeks");
            }
            int temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }
        private void IsInRange(int i)
        {
            if (i < 0 || i >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
        private void Resize()
        {
            if (Count == items.Length)
            {
                int[] tempArray = new int[items.Length * 2];
                for (int i = 0; i < items.Length; i++)
                {
                    tempArray[i] = items[i];
                }
                items = tempArray;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(20);
            list.Add(10);
            list.Add(30);
            list.Add(31);
            list.Add(32);
            list.Add(35);
            list.Add(50);
            Console.WriteLine(list[1]);
            list.Print();
            list.Swap(0, 6);
            Console.WriteLine(list.Contains(20));
            list.Print();
        }
    }
}
