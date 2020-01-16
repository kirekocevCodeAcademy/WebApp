using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainData.BeautyShop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MultipleAppSetup.Pages.BeautyShop.Customer
{
    public class ListModel : PageModel
    {
        private readonly ICustomerData customerData;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [TempData]
        public string Message { get; set; }
        public IEnumerable<Core.BeautyShop.Customer> Customers { get; set; }

        public ListModel(ICustomerData customerData)
        {
            this.customerData = customerData;
        }

        public void OnGet()
        {
            Customers = customerData.GetCustomers(SearchTerm);
        }
    }
}