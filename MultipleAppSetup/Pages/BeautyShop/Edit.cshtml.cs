using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BusinessLayer;
using DomainData.BeautyShop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MultipleAppSetup.Pages.BeautyShop
{
    public class EditModel : PageModel
    {
        private readonly IVisitData visitData;
        private readonly ICustomerData customerData;
        private readonly VisitBl visitBl;

        [BindProperty]
        public Core.BeautyShop.Visit Visit{ get; set; }
       
        public string Message { get; set; }
       
        public IEnumerable<SelectListItem> Customers { get; set; }

        public EditModel(IVisitData visitData, ICustomerData customerData, VisitBl visitBl)
        {
            this.visitData = visitData;
            this.customerData = customerData;
            this.visitBl = visitBl;
        }

        public IActionResult OnGet()
        {
            Visit = new Core.BeautyShop.Visit();

            var customers = customerData.GetCustomers().ToList().Select(p => new { Id = p.Id, Display = $"{p.FirstName} {p.LastName}" });
            Customers = new SelectList(customers, "Id", "Display");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var customer = customerData.GetCustomerById(Visit.CustomerId.Value);
                Visit.Customer = customer;

                Visit = visitData.Create(Visit);
                TempData["Message"] = "The Object is created!";

                visitData.Commit();
                return RedirectToPage("./List");
            }

            var customers = customerData.GetCustomers().ToList().Select(p => new { Id = p.Id, Display = $"{p.FirstName} {p.LastName}" });
            Customers = new SelectList(customers, "Id", "Display");
            return Page();
        }

        public IActionResult OnPostBuy(double? ServicePrice, double? ProductPrice)
        {
            if (ModelState.IsValid)
            {
                var customer = customerData.GetCustomerById(Visit.CustomerId.Value);
                Visit.Customer = customer;

                if (ProductPrice.HasValue && ProductPrice.Value > 0)
                {
                    Visit.ShopItems.Add(visitBl.CreateProduct(ProductPrice.Value));
                }
                if (ServicePrice.HasValue && ServicePrice.Value > 0)
                {
                    Visit.ShopItems.Add(visitBl.CreateService(ServicePrice.Value));
                }
            }

            Message = Visit.CustomerId == null ? "No customer selected." : $"Total expences: {visitBl.TotalExpences(Visit)}";
            var customers = customerData.GetCustomers().ToList().Select(p => new { Id = p.Id, Display = $"{p.FirstName} {p.LastName}" });
            Customers = new SelectList(customers, "Id", "Display");
            return Page();
        }
    }
}