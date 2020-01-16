using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainData.BeautyShop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MultipleAppSetup.Pages.BeautyShop.Membership
{
    public class ListModel : PageModel
    {
        private readonly IMembershipData membershipData;     
        public IEnumerable<Core.BeautyShop.Membership> Memberships { get; set; }

        public ListModel(IMembershipData membershipData)
        {
            this.membershipData = membershipData;
        }

        public void OnGet()
        {
            Memberships = membershipData.GetMemberships();
        }
    }
}