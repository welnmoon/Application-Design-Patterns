using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; } = true;

        public void ChangeStatus() => IsAvailable = !IsAvailable;
    }

    public class Reader
    {
        public string Name { get; set; }
        public List<Book> BorrowedBooks { get; } = new List<Book>();

        public void BorrowBook(Book book)
        {
            if (book.IsAvailable)
            {
                book.ChangeStatus();
                BorrowedBooks.Add(book);
                Console.WriteLine($"{Name} borrowed {book.Title}");
            }
            else
            {
                Console.WriteLine($"{book.Title} is not available.");
            }
        }

        public void ReturnBook(Book book)
        {
            if (BorrowedBooks.Contains(book))
            {
                book.ChangeStatus();
                BorrowedBooks.Remove(book);
                Console.WriteLine($"{Name} returned {book.Title}");
            }
        }
    }

    public class Librarian
    {
        public string Name { get; set; }

        public void ManageBook(List<Book> libraryBooks, Book book, bool isAdding)
        {
            if (isAdding)
            {
                libraryBooks.Add(book);
                Console.WriteLine($"{Name} added {book.Title} to the library.");
            }
            else
            {
                libraryBooks.Remove(book);
                Console.WriteLine($"{Name} removed {book.Title} from the library.");
            }
        }
    }

    public class Library
    {
        public List<Book> Books { get; } = new List<Book>();

        public void DisplayBooks()
        {
            foreach (var book in Books)
            {
                var status = book.IsAvailable ? "Available" : "Borrowed";
                Console.WriteLine($"{book.Title} by {book.Author} - {status}");
            }
        }

        public List<Book> SearchBooks(string query)
        {
            return Books.Where(b => b.Title.Contains(query) || b.Author.Contains(query)).ToList();
        }
    }

    class Program
    {
        static void Main()
        {
            var library = new Library();
            var librarian = new Librarian { Name = "Alice" };
            var reader = new Reader { Name = "John Doe" };

            var book1 = new Book { Title = "C# Programming", Author = "Author A", ISBN = "123456" };
            var book2 = new Book { Title = "Design Patterns", Author = "Author B", ISBN = "654321" };

            librarian.ManageBook(library.Books, book1, true);
            librarian.ManageBook(library.Books, book2, true);

            library.DisplayBooks();

            reader.BorrowBook(book1);
            library.DisplayBooks();

            reader.ReturnBook(book1);
            library.DisplayBooks();
        }
    }
}
