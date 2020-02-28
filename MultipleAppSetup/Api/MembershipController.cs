using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainData.BeautyShop;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultipleAppSetup.Api
{
    [ApiController]
    public class MembershipController : ControllerBase
    {
        private readonly IMembershipData membershipData;
        private readonly ICustomerData customerData;

        public MembershipController(IMembershipData membershipData, ICustomerData customerData)
        {
            this.membershipData = membershipData;
            this.customerData = customerData;
        }

        [HttpGet("api/[controller]")]
        public IActionResult GetAll()
        {
            return Ok(membershipData.GetMemberships());
        }

        [HttpGet("api/customer/{customerId}/membership")]
        public IActionResult GetMemebrshipByCustomerId(int customerId)
        {
            var custoemr = customerData.GetCustomerById(customerId);
            if (custoemr == null)
                return NotFound();

            return Ok(custoemr.Membership);
        }
    }
}