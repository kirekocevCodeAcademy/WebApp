using System.Collections.Generic;
using Core.Library;
using DomainData.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MultipleAppSetup.Pages.Library.Author
{
    public class ListModel : PageModel
    {
        private readonly IPersonData personData;      

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IEnumerable<Person> Authors { get; set; }

        [TempData]
        public string Message { get; set; }
        public ListModel(IPersonData personData)
        {
            this.personData = personData;
        }

        public void OnGet()
        {
            Authors = personData.GetPersons(SearchTerm);
        }
    }
}