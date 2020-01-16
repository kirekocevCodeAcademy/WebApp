using Core.BeautyShop;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainData.BeautyShop
{
    public interface ICustomerData
    {
        Customer Create(Customer customer);
        Customer GetCustomerById(int id);
        Customer Update(Customer customer);
        int Commit();
        IEnumerable<Customer> GetCustomers(string searchTerm = null);
    }
}
