using System.ComponentModel.DataAnnotations;

namespace MultipleAppSetup.ViewModels
{
    public class CustomerDto
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        public int? MembershipId { get; set; }
    }
}
