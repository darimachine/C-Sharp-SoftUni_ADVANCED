using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    class Library : IEnumerable<Book>
    {
        public List<Book> Books { get; set; }
        public Library()
        {
            Books = new List<Book>();
        }
        public void Add(Book book)
        {
            this.Books.Add(book);
        }
        public void Remove(Book book)
        {
            this.Books.Remove(book);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < Books.Count; i++)
            {
                yield return Books[i];
            }
           
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
       
    }
    class Book : IComparable<Book>
    {
        public Book(string title, int year, List<string> authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors;
        }
        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Authors { get; set; }

        public int CompareTo(Book other)
        {
            int compare = this.Year.CompareTo(other.Year);
            if (compare == 0)
            {
               compare = this.Title.CompareTo(other.Title);
            }
            // this == other 0
            // this > other 1
            // this < other - 1
            return compare;
        }
        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
    class BookComparator : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            int compare = x.Title.CompareTo(y.Title);
            if (compare == 0)
            {
                compare =y.Year.CompareTo(x.Year);
            }
            return compare;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var library = new Library();
         
            
           
            library.Add(new Book("Kon Qioxote", 1605, new List<string>() { "Miguel" }));
            library.Add(new Book("Lord of Rings", 1954, new List<string>() { "Tolkin" }));
            library.Add(new Book("Harry Potter", 1605, new List<string>() { "harry poter author" }));
            library.Add(new Book("And Then There Were None", 1939, new List<string>() { "Agatha" }));
            library.Add(new Book("Alice Wonderland", 1865, new List<string>() { "Lewis Carrol" }));
            library.Books.Sort((x,y) => x.Title.CompareTo(y.Title) !=0 ? x.Title.CompareTo(y.Title) : y.Year.CompareTo(x.Year));
            
            
           
            foreach (var book in library)
            {
                Console.WriteLine(book);
            }
        }
    }
        
            
        
}

