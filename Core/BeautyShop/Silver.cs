using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BeautyShop
{
    public class Silver : Membership
    {
        public Silver()
        {
            Id = 3;
        }
        public override double DiscountService()
        {
            return 10 / 100.0;
        }

        public override string GetMembershipType()
        {
            return "Silver";
        }
    }
}
