using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.BeautyShop
{
    public class Visit
    {
        public List<double> Services { get; set; }
        public List<double> Products { get; set; }

        public int Id { get; set; }

        public Customer Customer { get; set; }

        [Required, Display(Name = "Customer")]
        public int? CustomerId { get; set; }

        public Visit()
        {
            Services = new List<double>();
            Products = new List<double>();
        }

        public void BuyService(double pay)
        {
            Services.Add(pay);
        }

        public void BuyProduct(double pay)
        {
            Products.Add(pay);
        }

        public double TotalExpences()
        {
            var sum = 0.0;
            foreach (var item in Products)
            {
                if (Customer.IsMember)
                {
                    sum += item * (1 - Customer.Membership.DiscountProducts());
                }
                else
                {
                    sum += item;
                }
            }

            foreach (var item in Services)
            {
                if (Customer.IsMember)
                {
                    sum += item * (1 - Customer.Membership.DiscountService());
                }
                else
                {
                    sum += item;
                }
            }

            return sum;
        }

        public string GetCustomerInfo()
        {
            string result;
            if (Customer.IsMember)
            {
                result = $"Customer {Customer.FirstName} {Customer.LastName} has a {Customer.Membership.GetMembershipType()} membership.";
            }
            else
            {
                result = $"Customer {Customer.FirstName} {Customer.LastName} does not have membership.";
            }
            return result;
        }
    }
}
