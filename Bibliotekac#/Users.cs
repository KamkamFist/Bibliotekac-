using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekac
{
    public class Users
    {
        public int Id { get; set; } = Guid.NewGuid().GetHashCode();
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Book> BooksCollection { get; set; }


        public Users(string name, string surname)
        {
            Name = name;
            Surname = surname;
            BooksCollection = new List<Book>();
        }

       
    }


}
