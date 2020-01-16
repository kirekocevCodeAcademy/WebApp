namespace Core.BeautyShop
{
    public class Gold : Membership
    {
        public Gold()
        {
            Id = 2;
        }
        public override double DiscountService()
        {
            return 15 / 100.0;
        }

        public override string GetMembershipType()
        {
            return "Gold";
        }
    }
}
