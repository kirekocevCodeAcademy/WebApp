using DomainData.Library;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookData bookData;
        private readonly IPersonData personData;

        public BookController(IBookData bookData, IPersonData personData)
        {
            this.bookData = bookData;
            this.personData = personData;
        }
        public IActionResult Index(string SearchTerm)
        {
            var model = new BookViewModel();
            model.Books = bookData.GetBooksByTitle(SearchTerm);
            if(TempData.Keys.Contains("Message"))
            {
                model.Message = (string)TempData["Message"];
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var model = new BookViewModel();
            if (id.HasValue)
            {
                model.Book = bookData.GetBookById(id.Value);
                if (model.Book == null)
                {
                    return RedirectToAction("NotFoundBook");
                }
            }
            else
            {
                model.Book = new Core.Library.Book();
            }

            var authors = personData.GetPersons().ToList().Select(p => new { Id = p.Id, Display = $"{p.FirstName} {p.LastName}" });
            model.Authors = new SelectList(authors, "Id", "Display");
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var author = personData.GetPersonById(model.Book.PersonId.Value);
                model.Book.Author = author;

                if (model.Book.Id == 0)
                {
                    model.Book = bookData.Create(model.Book);
                    TempData["Message"] = "The Object is created!";
                }
                else
                {
                    model.Book = bookData.Update(model.Book);
                    TempData["Message"] = "The Object is updated!";
                }

                bookData.Commit();
                return RedirectToAction("Index");
            }

            var authors = personData.GetPersons().ToList().Select(p => new { Id = p.Id, Display = $"{p.FirstName} {p.LastName}" });
            model.Authors = new SelectList(authors, "Id", "Display");
            return View(model);
        }

        public IActionResult NotFoundBook()
        {
            return View();
        }
    }
}