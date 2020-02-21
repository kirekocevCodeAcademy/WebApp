using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Core.BeautyShop;
using DomainData.BeautyShop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MultipleAppSetup.Pages.BeautyShop
{
    public class ListModel : PageModel
    {
        private readonly IVisitData visitData;
        private readonly VisitBl visitBl;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [TempData]
        public string Message { get; set; }
        public IEnumerable<Core.BeautyShop.Visit> Visits{ get; set; }

        public ListModel(IVisitData visitData, VisitBl visitBl)
        {
            this.visitData = visitData;
            this.visitBl = visitBl;
        }

        public double GetTotalExpenses(Visit visit)
        {
            return visitBl.TotalExpences(visit);
        }

        public void OnGet()
        {
            Visits = visitData.GetVisits(SearchTerm);
        }
    }
}