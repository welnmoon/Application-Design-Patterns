using System;
using System.Collections.Generic;

class Program
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public bool IsAvailable { get; set; } = true;
    }

    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }

    public class LibrarySystem
    {
        private List<Book> books = new List<Book>();
        private List<User> users = new List<User>();
        private List<string> activeReservations = new List<string>();

        public LibrarySystem()
        {
            books.Add(new Book { ID = 1, Title = "Война и мир", Author = "Толстой", Genre = "Роман" });
            books.Add(new Book { ID = 2, Title = "1984", Author = "Оруэлл", Genre = "Антиутопия" });
        }

        public void RegisterUser(string name, string role)
        {
            var newUser = new User { ID = users.Count + 1, Name = name, Role = role };
            users.Add(newUser);
            Console.WriteLine($"Пользователь '{name}' зарегистрирован как {role}.");
        }

        public void ViewAndSearchBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.ID}, Название: {book.Title}, Автор: {book.Author}, Жанр: {book.Genre}, Доступна: {book.IsAvailable}");
            }
        }

        public void ReserveBook(int bookId, string userName)
        {
            var book = books.Find(b => b.ID == bookId);
            if (book != null && book.IsAvailable)
            {
                book.IsAvailable = false;
                activeReservations.Add($"Книга '{book.Title}' забронирована пользователем {userName}.");
                Console.WriteLine($"Книга '{book.Title}' забронирована пользователем {userName}.");
            }
            else
            {
                Console.WriteLine("Книга недоступна для бронирования.");
            }
        }

        public void CancelReservation(int bookId, string userName)
        {
            var book = books.Find(b => b.ID == bookId);
            if (book != null && !book.IsAvailable)
            {
                book.IsAvailable = true;
                activeReservations.RemoveAll(r => r.Contains(book.Title) && r.Contains(userName));
                Console.WriteLine($"Бронирование книги '{book.Title}' пользователем {userName} отменено.");
            }
            else
            {
                Console.WriteLine("Бронирование не найдено или книга уже доступна.");
            }
        }

        public void AddBook(string title, string author, string genre)
        {
            books.Add(new Book { ID = books.Count + 1, Title = title, Author = author, Genre = genre });
            Console.WriteLine($"Книга '{title}' добавлена в каталог.");
        }

        public void RemoveBook(int bookId)
        {
            var book = books.Find(b => b.ID == bookId);
            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine($"Книга '{book.Title}' удалена из каталога.");
            }
            else
            {
                Console.WriteLine("Книга не найдена.");
            }
        }

        public void ViewActiveReservations()
        {
            Console.WriteLine("Активные бронирования:");
            foreach (var reservation in activeReservations)
            {
                Console.WriteLine(reservation);
            }
        }
    }

    static void Main(string[] args)
    {
        var librarySystem = new LibrarySystem();

        librarySystem.RegisterUser("Иван", "Reader");
        librarySystem.RegisterUser("Мария", "Librarian");

        librarySystem.ViewAndSearchBooks();
        librarySystem.ReserveBook(1, "Иван");
        librarySystem.ViewActiveReservations();

        librarySystem.CancelReservation(1, "Иван");
        librarySystem.AddBook("Мастер и Маргарита", "Булгаков", "Роман");
        librarySystem.ViewAndSearchBooks();

        librarySystem.RemoveBook(2);
        librarySystem.ViewAndSearchBooks();
    }
}
