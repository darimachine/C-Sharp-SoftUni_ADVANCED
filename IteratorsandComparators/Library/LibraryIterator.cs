using System.Collections;
using System.Collections.Generic;

namespace Library
{
    class LibraryIterator : IEnumerator<Book>
    {
        private int currentindex;
        private List<Book> books = new List<Book>();
        public LibraryIterator(List<Book> books)
        {
            
            this.books = books;
            this.currentindex = -1;
        }
        public Book Current => this.books[currentindex];

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            currentindex++;
            if (currentindex == books.Count)
            {
                return false;
            }
            else
            {
               
                return true;
            }
        }

        public void Reset()
        {

        }
    }
}
