using System;

namespace Biblioteka
{
    class Program
    {
        static void Main()
        {
            Library library = new Library();
            bool run = true;

            while (run)
            {
                Console.WriteLine("\n=== MENU BIBLIOTEKI ===");
                Console.WriteLine("1. Dodaj książkę");
                Console.WriteLine("2. Dodaj czytelnika");
                Console.WriteLine("3. Wypożycz książkę");
                Console.WriteLine("4. Zwróć książkę");
                Console.WriteLine("5. Pokaż wszystkie książki");
                Console.WriteLine("6. Pokaż dostępne książki");
                Console.WriteLine("7. Pokaż czytelników");
                Console.WriteLine("8. Pokaż wypożyczone książki");
                Console.WriteLine("9. Szukaj książki");
                Console.WriteLine("0. Zakończ");
                Console.Write("Wybierz opcję: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Tytuł: "); string title = Console.ReadLine();
                        Console.Write("Autor: "); string author = Console.ReadLine();
                        Console.Write("Rok wydania: "); int year = int.Parse(Console.ReadLine());
                        library.AddBook(title, author, year);
                        break;

                    case "2":
                        Console.Write("Imię: "); string name = Console.ReadLine();
                        Console.Write("Nazwisko: "); string surname = Console.ReadLine();
                        library.AddUser(name, surname);
                        break;

                    case "3":
                        Console.Write("Tytuł książki: "); string borrowTitle = Console.ReadLine();
                        Console.Write("Nazwisko czytelnika: "); string borrowSurname = Console.ReadLine();
                        library.BorrowBook(borrowTitle, borrowSurname);
                        break;

                    case "4":
                        Console.Write("Tytuł książki: "); string returnTitle = Console.ReadLine();
                        library.ReturnBook(returnTitle);
                        break;

                    case "5":
                        library.ShowAllBooks();
                        break;

                    case "6":
                        library.ShowAvailableBooks();
                        break;

                    case "7":
                        library.ShowUsers();
                        break;

                    case "8":
                        library.ShowBorrowedBooks();
                        break;

                    case "9":
                        Console.Write("Podaj tytuł lub autora: ");
                        string search = Console.ReadLine();
                        library.SearchBook(search);
                        break;

                    case "0":
                        run = false;
                        Console.WriteLine("Zamykanie programu...");
                        break;

                    default:
                        Console.WriteLine("Niepoprawny wybór.");
                        break;
                }
            }
        }
    }
}
