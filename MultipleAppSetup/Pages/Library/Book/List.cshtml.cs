using System.Collections.Generic;
using DomainData.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MultipleAppSetup.Pages.Library.Book
{
    public class ListModel : PageModel
    {
        private readonly IBookData bookData;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [TempData]
        public string Message { get; set; }
        public IEnumerable<Core.Library.Book> Books { get; set; }

        public ListModel(IBookData bookData)
        {
            this.bookData = bookData;
        }

        public void OnGet()
        {
            Books = bookData.GetBooksByTitle(SearchTerm);
        }
    }
}