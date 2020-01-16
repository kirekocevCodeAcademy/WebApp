using Core.BeautyShop;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainData.BeautyShop
{
    public interface IMembershipData
    {
        IEnumerable<Membership> GetMemberships();
        Membership GetMebershipById(int? membershipId);
    }
}
