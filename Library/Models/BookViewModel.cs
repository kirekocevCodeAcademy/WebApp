using Core.Library;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class BookViewModel
    {
        public string SearchTerm { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<SelectListItem> Authors { get; set; }
        public string Message { get; set; }
        public Book Book { get; set; }
    }
}
