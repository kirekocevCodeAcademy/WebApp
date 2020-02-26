using Core.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class LibraryViewModel
    {
        public string Author { get; set; }
        public string BookTitle { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
