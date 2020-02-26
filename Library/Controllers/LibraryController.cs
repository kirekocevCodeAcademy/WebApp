using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainData.Library;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        private readonly IBookData bookData;

        public LibraryController(IBookData bookData)
        {
            this.bookData = bookData;
        }
        public IActionResult Index(string author, string bookTitle)
        {
            var model = new LibraryViewModel();
            model.Books = bookData.GetBooks(author, bookTitle);
            return View(model);
        }
    }
}