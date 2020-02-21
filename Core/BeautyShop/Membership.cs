using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BeautyShop
{
    public class Membership
    {
        public Membership()
        {
            DiscountProducts = 15 / 100.0;
        }
        public int Id { get; set; }
        public string MembershipType { get; set; }
        public double DiscountService { get; set; }
        public double DiscountProducts { get; set; }
    }
}
