using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.BeautyShop;

namespace DomainData.BeautyShop.InMemoryData
{
    public class MembershipDataInMemory : IMembershipData
    {
        private List<Membership> memberships;

        public MembershipDataInMemory()
        {
            memberships = new List<Membership>
            {
                new Premium(),
                new Gold(),
                new Silver(),
                new Bronze()
            };
        }

        public Membership GetMebershipById(int? membershipId)
        {
            return memberships.SingleOrDefault(x => x.Id == membershipId);
        }

        public IEnumerable<Membership> GetMemberships()
        {
            return memberships;
        }
    }
}
