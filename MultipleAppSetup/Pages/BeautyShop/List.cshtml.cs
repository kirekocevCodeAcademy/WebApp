using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainData.BeautyShop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MultipleAppSetup.Pages.BeautyShop
{
    public class ListModel : PageModel
    {
        private readonly IVisitData visitData;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [TempData]
        public string Message { get; set; }
        public IEnumerable<Core.BeautyShop.Visit> Visits{ get; set; }

        public ListModel(IVisitData visitData)
        {
            this.visitData = visitData;
        }

        public void OnGet()
        {
            Visits = visitData.GetVisits(SearchTerm);
        }
    }
}