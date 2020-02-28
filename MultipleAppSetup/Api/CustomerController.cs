using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainData.BeautyShop;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultipleAppSetup.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerData customerData;

        public CustomerController(ICustomerData customerData)
        {
            this.customerData = customerData;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(customerData.GetCustomers());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(customerData.GetCustomerById(id));
        }
    }
}