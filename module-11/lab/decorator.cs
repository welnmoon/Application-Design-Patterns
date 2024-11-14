using System;
using System.Collections.Generic;

namespace LibraryManagement
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; } = true;

        public void MarkAsLoaned() => IsAvailable = false;
        public void MarkAsAvailable() => IsAvailable = true;
    }

    public class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public void BorrowBook(Book book)
        {
            if (book.IsAvailable)
            {
                book.MarkAsLoaned();
                Console.WriteLine($"{Name} borrowed {book.Title}");
            }
            else
            {
                Console.WriteLine($"{book.Title} is not available.");
            }
        }

        public void ReturnBook(Book book)
        {
            book.MarkAsAvailable();
            Console.WriteLine($"{Name} returned {book.Title}");
        }
    }

    public class Librarian
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }

        public void AddBook(List<Book> books, Book book)
        {
            books.Add(book);
            Console.WriteLine($"{Name} added {book.Title} to the library.");
        }

        public void RemoveBook(List<Book> books, Book book)
        {
            books.Remove(book);
            Console.WriteLine($"{Name} removed {book.Title} from the library.");
        }
    }

    public class Loan
    {
        public Book Book { get; set; }
        public Reader Reader { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public void IssueLoan(Book book, Reader reader)
        {
            Book = book;
            Reader = reader;
            LoanDate = DateTime.Now;
            Console.WriteLine($"{reader.Name} issued a loan for {book.Title} on {LoanDate}");
        }

        public void CompleteLoan()
        {
            ReturnDate = DateTime.Now;
            Console.WriteLine($"Loan for {Book.Title} completed on {ReturnDate}");
        }
    }

    class Program
    {
        static void Main()
        {
            var libraryBooks = new List<Book>();
            var librarian = new Librarian { Id = 1, Name = "Alice", Position = "Chief Librarian" };
            var reader = new Reader { Id = 1, Name = "John Doe", Email = "john@example.com" };

            var book1 = new Book { Title = "C# Programming", Author = "Author A", ISBN = "123456" };
            var book2 = new Book { Title = "Design Patterns", Author = "Author B", ISBN = "654321" };

            librarian.AddBook(libraryBooks, book1);
            librarian.AddBook(libraryBooks, book2);

            reader.BorrowBook(book1);
            reader.ReturnBook(book1);

            var loan = new Loan();
            loan.IssueLoan(book2, reader);
            loan.CompleteLoan();
        }
    }
}
