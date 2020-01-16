using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BeautyShop
{
    public abstract class Membership
    {
        public int Id { get; set; }
        public abstract string GetMembershipType();
        public abstract double DiscountService();
        public virtual double DiscountProducts()
        {
            return 15 / 100.0;
        }
    }
}
