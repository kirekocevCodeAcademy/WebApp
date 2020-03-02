using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.BeautyShop;
using DomainData.BeautyShop;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultipleAppSetup.ViewModels;

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

        [HttpGet("{id}", Name = "FetchCustomer")]
        public IActionResult GetById(int id)
        {
            return Ok(customerData.GetCustomerById(id));
        }

        [HttpPost]
        public IActionResult Create(CustomerDto customer)
        {
            var dbCustomer = new Customer();
            dbCustomer.FirstName = customer.FirstName;
            dbCustomer.LastName = customer.LastName;
            dbCustomer.MembershipId = customer.MembershipId;
            customerData.Create(dbCustomer);
            customerData.Commit();
            return CreatedAtRoute("FetchCustomer", new { id = dbCustomer.Id }, dbCustomer);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CustomerDto customer)
        {
            var dbCustomer = customerData.GetCustomerById(id);
            if(dbCustomer == null)
            {
                return BadRequest();
            }
            dbCustomer.FirstName = customer.FirstName;
            dbCustomer.LastName = customer.LastName;
            dbCustomer.MembershipId = customer.MembershipId;


            customerData.Update(dbCustomer);
            customerData.Commit();
            return NoContent();
        }
    }
}