using System.Collections.Generic;
using DomainData.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MultipleAppSetup.Pages.Library
{
    public class ListModel : PageModel
    {
        private readonly IBookData bookData;

        [BindProperty(SupportsGet = true)]
        public string Author { get; set; }
        [BindProperty(SupportsGet = true)]
        public string BookTitle { get; set; }

        public IEnumerable<Core.Library.Book> Books { get; set; }

        public ListModel(IBookData bookData)
        {
            this.bookData = bookData;
        }

        public void OnGet()
        {
            Books = bookData.GetBooks(Author, BookTitle);
        }
    }
}