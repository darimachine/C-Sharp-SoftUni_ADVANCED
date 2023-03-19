using System;
using System.Collections;
using System.Collections.Generic;

namespace IteratorsandComparators
{
    class Student : IEnumerable<double>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<double> Grades { get; set; } = new List<double>();
        public void PrintGrades()
        {
            Console.WriteLine(string.Join(" ",Grades));
        }

        public IEnumerator<double> GetEnumerator()
        {
            return Grades.GetEnumerator();
            return new UniversityStudent(Grades);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
    class UniversityStudent : IEnumerator<double>
    {
        private List<double> items = new List<double>();
        private int index;
        public double Current => items[index];

        object IEnumerator.Current => Current;
        public UniversityStudent(List<double> items)
        {
            this.items = items;
            index = items.Count;
        }

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            index--;
            if(index>=0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
