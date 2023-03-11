using System;
using System.Linq;
using System.Collections.Generic;
namespace LinkedList_Workshop
{
    class DoublyLinkedList<T> 
    {
        private LinkedListItem<T> first;
        private LinkedListItem<T> last;
        public int Count { 
            get {
                var count = 0;
                var current = first;
                while (current != null)
                {
                    count++;
                    current = current.Next;
                }
                return count;
                } }
        public void AddFirst(T element)
        {
            var newItem = new LinkedListItem<T>(element);
            if (first == null)
            {
                first = newItem;
                last = newItem;
            }
            else{
                newItem.Next = first;
                first.Previous = newItem;
                first = newItem;
            }
            
            

        }
        public void AddLast(T element)
        {
            var newItem = new LinkedListItem<T>(element);
            if (last == null)
            {
                first = newItem;
                last = newItem;
            }
            else
            {
                newItem.Previous = last;
                last.Next = newItem;
                last = newItem;
            }
            
        }
        public T RemoveFirst()
        {
            var currentFirstValue = first.Value;
            if (first == null)
            {

                throw new InvalidOperationException("Linked List Empty!");
            }
            else if (first == last)
            {
                first = null;
                last = null;
            }
            else
            {
                var newFirst = first.Next;
                newFirst.Previous = null;
                first = newFirst;
            }
            

            return currentFirstValue;
        }
        public T RemoveLast()
        {
            var currentLast = last.Value;
            if (last == null)
            {
                //exception
                throw new InvalidOperationException("Linked List Empty!");
            }
            else if (last == first)
            {
                last = null;
                first = null;
            }
            else
            {
                var newLast = last.Previous;
                newLast.Next = null;
                last = newLast;
                
            }
            
            return currentLast;

        }
        public void ForEach( Action<T> action)
        {
            var current = first;
            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }
        public T[] ToArray()
        {
            var array = new T[Count];
            var current = first;
            for (int i = 0; i < Count; i++)
            {

                array[i] = current.Value;
                current = current.Next;
            }
            return array;
        }
    }

    class LinkedListItem<T>
    {
        public LinkedListItem<T> Previous { get; set; }
        public LinkedListItem<T> Next { get; set; }
        public T Value { get; set; }

        public LinkedListItem(T value)
        {
            this.Value = value;
        }
    }

    class StartUp
    {
        static void Main(string[] args)
        {
            var listOfStrings = new DoublyLinkedList<string>();
            listOfStrings.AddFirst("Niki");
            Console.WriteLine(string.Join(" ", listOfStrings.ToArray()));
            listOfStrings.AddFirst("Stoyan");
            Console.WriteLine(string.Join(" ", listOfStrings.ToArray()));
            listOfStrings.AddLast("Victor");
            Console.WriteLine(string.Join(" ", listOfStrings.ToArray()));


            var list = new DoublyLinkedList<int>();
            list.AddFirst(3);
            //3
            list.AddFirst(2);
            //2-3
            list.AddFirst(1);
            //1-2-3
            list.AddLast(4);
            //4-1-2-3
            list.AddFirst(0);
            // 0-4-1-2-3
            list.AddLast(100);
                              
            // 0-1-2-3-4-100
            list.RemoveFirst();
            
            // 1-2-3-4
            list.RemoveLast();
            // 1-2-3-4-5
            
            list.AddLast(5);
         
            Console.WriteLine(list.Count);
           
            Console.WriteLine(string.Join(" ",list.ToArray()));
            list.ForEach(x => Console.WriteLine("---" + x));
        }
        
    }
}
