using Core.Library;
using DomainData.Library;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IPersonData personData;

        public AuthorController(IPersonData personData)
        {
            this.personData = personData;
        }
        public IActionResult Index(string SearchTerm)
        {
            var model = new AuthorViewModel();
            model.Authors = personData.GetPersons(SearchTerm);
            if (TempData.Keys.Contains("Message"))
            {
                model.Message = (string)TempData["Message"];
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var model = new AuthorViewModel();
            if (id.HasValue)
            {
                model.Author = personData.GetPersonById(id.Value);
                if (model.Author == null)
                {
                    return RedirectToAction("NotFoundAuthor");
                }
            }
            else
            {
                model.Author = new Person();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(AuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Author.Id == 0)
                {
                    model.Author = personData.Create(model.Author);
                    TempData["Message"] = "The Object is created!";
                }
                else
                {
                    model.Author = personData.Update(model.Author);
                    TempData["Message"] = "The Object is updated!";
                }

                personData.Commit();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult NotFoundAuthor()
        {
            return View();
        }
    }
}