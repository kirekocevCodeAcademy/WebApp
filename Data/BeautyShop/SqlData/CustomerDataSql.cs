using Core.BeautyShop;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainData.BeautyShop.SqlData
{
    public class CustomerDataSql : ICustomerData
    {
        private readonly BeautyShopDbContext beautyShopDbContext;

        public CustomerDataSql(BeautyShopDbContext beautyShopDbContext)
        {
            this.beautyShopDbContext = beautyShopDbContext;
        }
        public int Commit()
        {
            return beautyShopDbContext.SaveChanges();
        }

        public Customer Create(Customer customer)
        {
            beautyShopDbContext.Customer.Add(customer);
            return customer;
        }

        public Customer GetCustomerById(int id)
        {
            return beautyShopDbContext.Customer
                .Include(c => c.Membership)
                .SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Customer> GetCustomers(string searchTerm = null)
        {
            return beautyShopDbContext.Customer
                .Include(c => c.Membership)
                .Where(r => string.IsNullOrEmpty(searchTerm)
                   || r.FirstName.ToLower().StartsWith(searchTerm.ToLower())
                   || r.LastName.ToLower().StartsWith(searchTerm.ToLower()))
                .OrderBy(r => r.FirstName)
                .ToList();
        }

        public Customer Update(Customer customer)
        {
            beautyShopDbContext.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return customer;
        }
    }
}
