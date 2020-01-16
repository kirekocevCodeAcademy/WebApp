using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.BeautyShop;

namespace DomainData.BeautyShop.InMemoryData
{
    public class CustomerDataInMemory : ICustomerData
    {
        private List<Customer> customers;
        public CustomerDataInMemory()
        {
            customers = new List<Customer>();
        }
        public int Commit()
        {
            return 0;
        }

        public Customer Create(Customer customer)
        {
            customer.Id = customers.Any() ? customers.Max(p => p.Id) + 1 : 1;
            customers.Add(customer);

            return customer;
        }

        public Customer GetCustomerById(int id)
        {
            return customers.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Customer> GetCustomers(string searchTerm = null)
        {
            return customers
               .Where(r => string.IsNullOrEmpty(searchTerm)
                   || r.FirstName.ToLower().StartsWith(searchTerm.ToLower())
                   || r.LastName.ToLower().StartsWith(searchTerm.ToLower()))
               .OrderBy(r => r.FirstName);
        }

        public Customer Update(Customer customer)
        {
            var tempCustomer = customers.SingleOrDefault(p => p.Id == customer.Id);
            if (tempCustomer != null)
            {
                tempCustomer.FirstName = customer.FirstName;
                tempCustomer.LastName = customer.LastName;
                tempCustomer.Membership = customer.Membership;
                tempCustomer.MembershipId = customer.MembershipId;
            }

            return tempCustomer;
        }
    }
}
