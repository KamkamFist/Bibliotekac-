using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekac
{
    public class Library
    {

        public List<Book> BooksCollection { get; set; }

        public List<Users> UsersCollection { get; set; }

        public Library()
        {
            BooksCollection = new List<Book>();
            UsersCollection = new List<Users>();
        }

        public void AddBook(Book book)
        {
            Console.WriteLine("Podaj tytuł książki:");
            var title = Console.ReadLine();
            Console.WriteLine("Podaj autora książki:");
            var author = Console.ReadLine();
            book = new Book(title, author);
            BooksCollection.Add(book);
        }

        public void AddUser(Users user)
        {
            Console.WriteLine("Podaj imiei:");
            var name = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko:");
            var surname = Console.ReadLine();
            var newUser = new Users(name, surname);
            UsersCollection.Add(newUser);
        }

        public void ShowAllBooks()
        {
            Console.WriteLine("Lista wszystkich książek w bibliotece:");
            foreach (var book in BooksCollection)
            {
                Console.WriteLine($"ID: {book.Id}, Tytuł: {book.Title}, Autor: {book.Author}, Dostepna: {book.IsAvailable}");
            }
        }
        public void BorrowBook()
        {
            Console.WriteLine("Podaj tyttul książki do wypożyczenia:");
            var title = Console.ReadLine();

            Console.WriteLine("Podaj nazwisko czytelnika:");
            var surname = Console.ReadLine();

            var book = BooksCollection.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase) && b.IsAvailable);
            if (book != null)
            {
                book.MarkAsCheckedOut();
                Console.WriteLine($"Książka '{book.Title}' została wypożyczona.");
            }
            else
            {
                Console.WriteLine("Książka jest niedostępna.");
            }
        }
    }
}