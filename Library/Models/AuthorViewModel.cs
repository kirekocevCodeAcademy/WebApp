using Core.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class AuthorViewModel
    {
        public string SearchTerm { get; set; }
        public IEnumerable<Person> Authors { get; set; }
        public string Message { get; set; }
        public Person Author { get; set; }
    }
}
