using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekac { 

    public class Book
    {
        public int Id { get; set; } = Guid.NewGuid().GetHashCode();
        public string Title { get; set; }
        public string Author { get; set; }

        public bool IsAvailable { get; set; } = true;

        public void MarkAsCheckedOut()
        {
            IsAvailable = false;
        }


        public void MarkAsAvailable()
        {
            IsAvailable = true;
        }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }
}
