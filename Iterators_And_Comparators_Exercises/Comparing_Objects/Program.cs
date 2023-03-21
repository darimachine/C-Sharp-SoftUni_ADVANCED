using System;
using System.Collections.Generic;

namespace Comparing_Objects
{
    class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;
        public int Count { get; private set; } = 1;
        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }
        public string Name => name;
        public int Age => age;
        public string Town => town;
        public int CompareTo(Person other)
        {
            var compare = name.CompareTo(other.name);
            if (compare == 0) 
            {
                Count++;
                compare = age.CompareTo(other.age);
                if (compare == 0)
                {
                    compare = town.CompareTo(other.town);
                }
            }
            return compare;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Person> persons = new List<Person>();
            while (command != "END")
            {

                var token = command.Split(" ");
                persons.Add(new Person(token[0], int.Parse(token[1]), token[2]));
                command = Console.ReadLine();
            }
            var index = int.Parse(Console.ReadLine())-1;
            var equal = 0;
            var notequal = 0;
            foreach (Person person in persons)
            {
                if (persons[index].CompareTo(person)==0)
                {
                    equal++;
                }
                else
                {
                    notequal++;
                }
            }
            if (equal <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.Write($"{equal} {notequal} {persons.Count}");
            }
        }
    }
}
