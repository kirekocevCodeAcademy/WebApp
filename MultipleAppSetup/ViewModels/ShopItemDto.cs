using System.ComponentModel.DataAnnotations;

namespace MultipleAppSetup.ViewModels
{
    public class ShopItemDto
    {
        [Required]
        public double? Price { get; set; }
        [Required]
        public int? ShopItemType { get; set; }
    }
}
