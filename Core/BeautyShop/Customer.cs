using Core.Library;
using System.ComponentModel.DataAnnotations;

namespace Core.BeautyShop
{
    public class Customer : Person
    {
        public bool IsMember
        {
            get
            {
                return Membership != null;
            }
        }

        [Display(Name = "Memebrship")]
        public int? MembershipId { get; set; }

        public Membership Membership { get; set; }
    }
}
