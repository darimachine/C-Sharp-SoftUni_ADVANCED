using System;
using System.Collections.Generic;

namespace Equiality_Logic
{
    class Person : IComparable<Person>
    {
        private string name;
        private int age;
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public string Name => name;
        public int Age => age;
        public int CompareTo(Person other)
        {
            var compare = name.CompareTo(other.name);
            if (compare == 0)
            {
                compare = age.CompareTo(other.age);
            }
            return compare;
        }
        public override bool Equals(object obj)
        {
            var other = obj as Person;
            if (other == null) return false;
            return Age == other.Age && Name == other.Name;
            
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Age.GetHashCode();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            SortedSet<Person> persons = new SortedSet<Person>();
            HashSet<Person> persons2 = new HashSet<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var person = Console.ReadLine().Split(" ");
                string name = person[0];
                int age = int.Parse(person[1]);
                var individual = new Person(name, age);
                persons.Add(individual);
                persons2.Add(individual);
            }
            
            Console.WriteLine(persons.Count);
            Console.WriteLine(persons2.Count);
        }
    }
}
