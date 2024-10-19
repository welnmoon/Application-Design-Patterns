using System;
using System.Collections.Generic;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int Copies { get; set; }

    public Book(string title, string author, string isbn, int copies)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        Copies = copies;
    }

    public override string ToString()
    {
        return $"{Title} by {Author} (ISBN: {ISBN}) - Copies: {Copies}";
    }
}

public class Reader
{
    public string Name { get; set; }
    public int ReaderId { get; set; }
    public List<Book> BorrowedBooks { get; set; }

    public Reader(string name, int readerId)
    {
        Name = name;
        ReaderId = readerId;
        BorrowedBooks = new List<Book>();
    }

    public override string ToString()
    {
        return $"Reader: {Name}, ID: {ReaderId}";
    }
}

public class Library
{
    public List<Book> Books { get; set; }
    public List<Reader> Readers { get; set; }

    public Library()
    {
        Books = new List<Book>();
        Readers = new List<Reader>();
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
        Console.WriteLine($"Book '{book.Title}' added to the library.");
    }

    public void RemoveBook(string isbn)
    {
        Book book = Books.Find(b => b.ISBN == isbn);
        if (book != null)
        {
            Books.Remove(book);
            Console.WriteLine($"Book '{book.Title}' removed from the library.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    public void RegisterReader(Reader reader)
    {
        Readers.Add(reader);
        Console.WriteLine($"Reader '{reader.Name}' registered.");
    }

    public void RemoveReader(int readerId)
    {
        Reader reader = Readers.Find(r => r.ReaderId == readerId);
        if (reader != null)
        {
            Readers.Remove(reader);
            Console.WriteLine($"Reader '{reader.Name}' removed.");
        }
        else
        {
            Console.WriteLine("Reader not found.");
        }
    }

    public void BorrowBook(string isbn, int readerId)
    {
        Book book = Books.Find(b => b.ISBN == isbn);
        Reader reader = Readers.Find(r => r.ReaderId == readerId);
        if (book != null && reader != null)
        {
            if (book.Copies > 0)
            {
                reader.BorrowedBooks.Add(book);
                book.Copies--;
                Console.WriteLine($"Book '{book.Title}' borrowed by {reader.Name}.");
            }
            else
            {
                Console.WriteLine($"No copies of '{book.Title}' available.");
            }
        }
        else
        {
            if (book == null) Console.WriteLine("Book not found.");
            if (reader == null) Console.WriteLine("Reader not found.");
        }
    }

    public void ReturnBook(string isbn, int readerId)
    {
        Reader reader = Readers.Find(r => r.ReaderId == readerId);
        if (reader != null)
        {
            Book book = reader.BorrowedBooks.Find(b => b.ISBN == isbn);
            if (book != null)
            {
                reader.BorrowedBooks.Remove(book);
                book.Copies++;
                Console.WriteLine($"Book '{book.Title}' returned by {reader.Name}.");
            }
            else
            {
                Console.WriteLine("Reader doesn't have this book.");
            }
        }
        else
        {
            Console.WriteLine("Reader not found.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Library library = new Library();

        Book book1 = new Book("C# Programming", "John Doe", "123456", 3);
        Book book2 = new Book("Design Patterns", "Jane Smith", "654321", 2);

        library.AddBook(book1);
        library.AddBook(book2);

        Reader reader1 = new Reader("Alice", 1);
        library.RegisterReader(reader1);

        library.BorrowBook("123456", 1);

        library.ReturnBook("123456", 1);

        library.RemoveBook("654321");

        library.RemoveReader(1);
    }
}
