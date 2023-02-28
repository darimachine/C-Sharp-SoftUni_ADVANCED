using System;
using System.Collections.Generic;
using System.Linq;

namespace Class
{
    class Person
    {
        public string First_name;
        public int Age;
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> students = new List<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(", ");
                var person = new Person();
                person.First_name = line[0];
                person.Age = int.Parse(line[1]);
                students.Add(person);
            }
            var condition = Console.ReadLine();


            var age = int.Parse(Console.ReadLine());
            var columns = Console.ReadLine().Split(" ");
            Func<Person, bool> filter = p => true ;
            if (condition == "older")
            {
                filter = x => x.Age >= age;
                
            }
            else if (condition=="younger")
            {
                filter = x => x.Age <= age;
            }
            else if (condition == "exact")
            {
                filter = x => x.Age == age;
            }
            var formated_students = students.Where(filter);
            if (columns.Length > 1)
            {

                foreach (var student in formated_students)
                {
                    Console.WriteLine($"{student.First_name} - {student.Age}");
                }
            }
            else
            {
                if (columns[0] == "name")
                {
                    foreach (var student in formated_students)
                    {
                        Console.WriteLine($"{student.First_name}");
                    }
                }
                else if (columns[0] == "age")
                {
                    foreach (var student in formated_students)
                    {
                        Console.WriteLine($"{student.Age}");
                    }
                }


            }
        }

    }
}                                                                     
        
   

