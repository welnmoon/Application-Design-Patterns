using System;
using System.Collections.Generic;

namespace LibraryManagement
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; } = true;

        public void ChangeAvailabilityStatus() => IsAvailable = !IsAvailable;
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual void BorrowBook(Book book) { }
    }

    public class Reader : User
    {
        public void BorrowBook(Book book)
        {
            if (book.IsAvailable)
            {
                book.ChangeAvailabilityStatus();
                Console.WriteLine($"{Name} borrowed {book.Title}");
            }
            else
            {
                Console.WriteLine($"{book.Title} is not available.");
            }
        }
    }

    public class Librarian : User
    {
        public void IssueBook(Book book, Reader reader)
        {
            reader.BorrowBook(book);
        }

        public void ReturnBook(Book book)
        {
            book.ChangeAvailabilityStatus();
            Console.WriteLine($"{book.Title} returned to the library.");
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
            Console.WriteLine($"Loan issued for {book.Title} to {reader.Name} on {LoanDate}");
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
            var book1 = new Book { Title = "C# Programming", Author = "Author A", Genre = "Programming", ISBN = "123456" };
            var book2 = new Book { Title = "Design Patterns", Author = "Author B", Genre = "Software Design", ISBN = "654321" };

            var reader = new Reader { Id = 1, Name = "John Doe", Email = "john@example.com" };
            var librarian = new Librarian { Id = 1, Name = "Alice Smith" };

            librarian.IssueBook(book1, reader);
            librarian.ReturnBook(book1);

            var loan = new Loan();
            loan.IssueLoan(book2, reader);
            loan.CompleteLoan();
        }
    }
}
