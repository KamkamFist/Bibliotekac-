using System;

namespace Biblioteka
{
    [Serializable]
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public bool IsBorrowed { get; set; } = false;
        public string BorrowedBy { get; set; } = "";
        public DateTime? BorrowDate { get; set; }

        public Book() { }

        public Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        public override string ToString()
        {
            string status = IsBorrowed
                ? $"Wypożyczona przez {BorrowedBy} dnia {BorrowDate?.ToShortDateString()}"
                : "Dostępna";
            return $"{Title} - {Author} ({Year}) [{status}]";
        }
    }
}
