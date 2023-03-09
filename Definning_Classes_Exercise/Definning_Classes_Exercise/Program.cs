using System;
using System.Collections.Generic;
using System.Linq;
namespace DefiningClasses
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person()
        {
            this.Name = "No name";
            this.Age = 1;
        }
        public Person(int age) : this()
        {
            this.Age = age;
        }
        public Person(string name,int age) : this(age)
        {
            this.Name = name;
        }

    }
    class Family
    {
        public List<Person> Persons { get; set; }
        public Family()
        {
            this.Persons = new List<Person>();
        }
        public void AddMember(Person person)
        {
           this.Persons.Add(person);
        }
        
        public Person GetOldestMember()
        {
            int highest_age = 0;
            if (Persons.Count == 0)
            {
                return null;
            }
            Person oldest = Persons[0];
            foreach (var person in Persons)
            {
                if (person.Age > highest_age)
                {
                    highest_age = person.Age;
                    oldest = person;
                }
            }
            return oldest;
        }
    }
    class StartUp
    {
        static void Main(string[] args)
        {
            
            int people_count = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < people_count; i++)
            {
                var line = Console.ReadLine().Split(" ");
                var person =new Person(line[0], int.Parse(line[1]));
                family.AddMember(person);
                
            }
            Person[] sorted_family = family.Persons.OrderBy(x => x.Name).ToArray();
            for (int i = 0; i < people_count; i++)
            {
                if (sorted_family[i].Age > 30)
                {
                    Console.WriteLine($"{sorted_family[i].Name} - {sorted_family[i].Age}");
                }
                
            }
        }
    }
}
