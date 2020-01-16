using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BeautyShop
{
    public class Bronze : Membership
    {
        public Bronze()
        {
            Id = 4;
        }
        public override double DiscountService()
        {
            return 0.05;
        }

        public override string GetMembershipType()
        {
            return "Bronze";
        }
    }
}
