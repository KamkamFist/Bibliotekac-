using Bibliotekac;

class Program

{
    static void Main(string[] args)
    {

        var library = new Library();
        while (true)
        {
            ShowMenu(library);
        }

        void ShowMenu(Library library)
        {
            Console.WriteLine();
            Console.WriteLine("=== System biblioteczny ===");
            Console.WriteLine("1. Dodaj książkę");
            Console.WriteLine("2. Dodaj czytelnika");
            Console.WriteLine("3. Wypożycz książkę");
            Console.WriteLine("4. Zwróć książkę");
            Console.WriteLine("5. Pokaż wszystkie książki");
            Console.WriteLine("6. Pokaż dostępne książki");
            Console.WriteLine("7. Pokaż czytelników");
            Console.WriteLine("8. Pokaż wypożyczenia");
            Console.WriteLine("9. Wyszukaj książki (tytuł/autor)");
            Console.WriteLine("10. Pokaż przetrzymywane po terminie");
            Console.WriteLine("11. Zapisz dane");
            Console.WriteLine("12. Zakończ program");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    library.AddBook(new Book("", ""));
                    return;
                case "2":
                    library.AddUser(new Users("", ""));
                    Console.WriteLine("Czytelnik został dodany.");
                    return;
                case "3":
                    library.BorrowBook();
                    Console.WriteLine("Wypożycz książkę:");
        
                    return;
                case "4":
                    return;
                case "5":
                    library.ShowAllBooks();
                    return;
                case "6":
                    Console.WriteLine("Pokazywanie dostępnych książek...");
                    return;
                case "7":
                    Console.WriteLine("Pokazywanie czytelników...");
                    return;
                case "8":
                    return;
                case "9":
                    return;
                case "10":
                    return;
                case "11":
                    return;
                case "12":
                    Console.WriteLine("Koniec programu.");
                    return;
                default:
                    Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                    break;
            }
        }
    }
}