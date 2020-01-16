using System.Collections.Generic;
using System.Linq;
using DomainData.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MultipleAppSetup.Pages.Library.Book
{
    public class EditModel : PageModel
    {
        private readonly IBookData bookData;
        private readonly IPersonData personData;

        [BindProperty]
        public Core.Library.Book Book { get; set; }

        public IEnumerable<SelectListItem> Authors { get; set; }

        public EditModel(IBookData bookData, IPersonData personData)
        {
            this.bookData = bookData;
            this.personData = personData;
        }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Book = bookData.GetBookById(id.Value);
                if (Book == null)
                {
                    return RedirectToPage("./NotFound");
                }
            }
            else
            {
                Book = new Core.Library.Book();
            }

            var authors = personData.GetPersons().ToList().Select(p => new { Id = p.Id, Display = $"{p.FirstName} {p.LastName}" });
            Authors = new SelectList(authors, "Id", "Display");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var author = personData.GetPersonById(Book.PersonId.Value);
                Book.Author = author;

                if (Book.Id == 0)
                {
                    Book = bookData.Create(Book);
                    TempData["Message"] = "The Object is created!";
                }
                else
                {
                    Book = bookData.Update(Book);
                    TempData["Message"] = "The Object is updated!";
                }

                bookData.Commit();
                return RedirectToPage("./List");
            }

            var authors = personData.GetPersons().ToList().Select(p => new { Id = p.Id, Display = $"{p.FirstName} {p.LastName}" });
            Authors = new SelectList(authors, "Id", "Display");
            return Page();
        }
    }
}