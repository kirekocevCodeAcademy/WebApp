using System.ComponentModel.DataAnnotations;

namespace Core.Library
{
    public class Person
    {
        public int Id { get; set; }
        [Required, MaxLength(50), Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, MaxLength(50), Display(Name = "Last Name")]
        public string LastName { get; set; }        
    }
}
