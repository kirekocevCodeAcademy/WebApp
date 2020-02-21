using Core.BeautyShop;
using System.Collections.Generic;
using System.Linq;

namespace DomainData.BeautyShop.SqlData
{
    public class MembershipDataSql : IMembershipData
    {
        private readonly BeautyShopDbContext beautyShopDbContext;

        public MembershipDataSql(BeautyShopDbContext beautyShopDbContext)
        {
            this.beautyShopDbContext = beautyShopDbContext;
        }

        public Membership GetMebershipById(int? membershipId)
        {
            return beautyShopDbContext.Membership.SingleOrDefault(x => x.Id == membershipId);
        }

        public IEnumerable<Membership> GetMemberships()
        {
            return beautyShopDbContext.Membership.ToList();
        }
    }
}
