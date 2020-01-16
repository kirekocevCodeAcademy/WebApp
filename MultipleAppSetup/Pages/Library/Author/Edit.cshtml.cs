using Core.Library;
using DomainData.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MultipleAppSetup.Pages.Library.Author
{
    public class EditModel : PageModel
    {
        private readonly IPersonData personData;
        
        [BindProperty]
        public Person Author { get; set; }      

        public EditModel(IPersonData personData)
        {
            this.personData = personData;
        }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Author = personData.GetPersonById(id.Value);
                if (Author == null)
                {
                    return RedirectToPage("./NotFound");
                }
            }
            else
            {
                Author = new Person();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Author.Id == 0)
                {
                    Author = personData.Create(Author);
                    TempData["Message"] = "The Object is created!";
                }
                else
                {
                    Author = personData.Update(Author);
                    TempData["Message"] = "The Object is updated!";
                }

                personData.Commit();
                return RedirectToPage("./List");
            }

            return Page();
        }
    }
}