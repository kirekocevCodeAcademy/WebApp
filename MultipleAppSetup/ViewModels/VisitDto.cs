using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MultipleAppSetup.ViewModels
{
    public class VisitDto
    {
        public VisitDto()
        {
            ShopItems = new List<ShopItemDto>();
        }

        [Required]
        public int? CustomerId { get; set; }

        public List<ShopItemDto> ShopItems { get; set; }
    }
}
