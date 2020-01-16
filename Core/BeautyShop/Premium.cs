namespace Core.BeautyShop
{
    public class Premium : Membership
    {
        public Premium()
        {
            Id = 1;
        }
        public override double DiscountService()
        {
            return 25 / 100.0;
        }

        public override string GetMembershipType()
        {
            return "Premium";
        }
    }
}
