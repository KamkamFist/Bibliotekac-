using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;

namespace Biblioteka
{
    public class Library
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<User> Users { get; set; } = new List<User>();

        private const string BooksFile = "books.json";
        private const string UsersFile = "users.json";

        public Library()
        {
            LoadData();

            if (Books.Count == 0 && Users.Count == 0)
            {
                Console.WriteLine("Dodawanie przykładowych danych...");

                // Przykładowe książki
                Books.Add(new Book("Pan Tadeusz", "Adam Mickiewicz", 1834));
                Books.Add(new Book("Lalka", "Bolesław Prus", 1890));
                Books.Add(new Book("Zbrodnia i kara", "Fiodor Dostojewski", 1866));
                Books.Add(new Book("Wiedźmin: Ostatnie życzenie", "Andrzej Sapkowski", 1993));
                Books.Add(new Book("Mały Książę", "Antoine de Saint-Exupéry", 1943));

                // Przykładowi użytkownicy
                Users.Add(new User("Jan", "Kowalski"));
                Users.Add(new User("Anna", "Nowak"));
                Users.Add(new User("Piotr", "Wiśniewski"));

                SaveData();
                Console.WriteLine("Przykładowe dane zostały dodane.\n");
            }
        }

        
        public void AddBook(string title, string author, int year)
        {
            Books.Add(new Book(title, author, year));
            SaveData();
            Console.WriteLine("Dodano książkę!");
        }

        public void AddUser(string name, string surname)
        {
            Users.Add(new User(name, surname));
            SaveData();
            Console.WriteLine("Dodano czytelnika!");
        }

       
        public void BorrowBook(string title, string surname)
        {
            var book = Books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            var user = Users.FirstOrDefault(u => u.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase));

            if (book == null)
            {
                Console.WriteLine("Nie znaleziono książki o takim tytule.");
                return;
            }
            if (user == null)
            {
                Console.WriteLine("Nie znaleziono czytelnika o takim nazwisku.");
                return;
            }
            if (book.IsBorrowed)
            {
                Console.WriteLine("Ta książka jest już wypożyczona.");
                return;
            }

            book.IsBorrowed = true;
            book.BorrowedBy = $"{user.Name} {user.Surname}";
            book.BorrowDate = DateTime.Now;

            SaveData();
            Console.WriteLine($"{user.Name} {user.Surname} wypożyczył książkę \"{book.Title}\"");
        }

        
        public void ReturnBook(string title)
        {
            var book = Books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (book == null)
            {
                Console.WriteLine("Nie znaleziono książki o takim tytule.");
                return;
            }

            if (!book.IsBorrowed)
            {
                Console.WriteLine("Ta książka nie jest wypożyczona.");
                return;
            }

            book.IsBorrowed = false;
            book.BorrowedBy = "";
            book.BorrowDate = null;

            SaveData();
            Console.WriteLine($"Książka \"{book.Title}\" została zwrócona.");
        }

        
        public void ShowAllBooks()
        {
            if (Books.Count == 0)
            {
                Console.WriteLine("Brak książek w bibliotece.");
                return;
            }

            foreach (var b in Books)
                Console.WriteLine(b);
        }

        public void ShowAvailableBooks()
        {
            var available = Books.Where(b => !b.IsBorrowed).ToList();
            if (available.Count == 0)
                Console.WriteLine("Brak dostępnych książek.");
            else
                available.ForEach(b => Console.WriteLine(b));
        }

        public void ShowUsers()
        {
            if (Users.Count == 0)
            {
                Console.WriteLine("Brak czytelników.");
                return;
            }

            foreach (var u in Users)
                Console.WriteLine(u);
        }

        public void ShowBorrowedBooks()
        {
            var borrowed = Books.Where(b => b.IsBorrowed).ToList();
            if (borrowed.Count == 0)
                Console.WriteLine("Brak wypożyczonych książek.");
            else
                borrowed.ForEach(b => Console.WriteLine(b));
        }

        
        public void SearchBook(string text)
        {
            var found = Books.Where(b => b.Title.Contains(text, StringComparison.OrdinalIgnoreCase)
                                      || b.Author.Contains(text, StringComparison.OrdinalIgnoreCase)).ToList();
            if (found.Count == 0)
                Console.WriteLine("Nie znaleziono książek.");
            else
                found.ForEach(b => Console.WriteLine(b));
        }

        
        private void SaveData()
        {
            File.WriteAllText(BooksFile, JsonSerializer.Serialize(Books));
            File.WriteAllText(UsersFile, JsonSerializer.Serialize(Users));
        }

        private void LoadData()
        {
            if (File.Exists(BooksFile))
            {
                string booksJson = File.ReadAllText(BooksFile);
                if (!string.IsNullOrWhiteSpace(booksJson))
                    Books = JsonSerializer.Deserialize<List<Book>>(booksJson);
            }

            if (File.Exists(UsersFile))
            {
                string usersJson = File.ReadAllText(UsersFile);
                if (!string.IsNullOrWhiteSpace(usersJson))
                    Users = JsonSerializer.Deserialize<List<User>>(usersJson);
            }
        }
    }
}
