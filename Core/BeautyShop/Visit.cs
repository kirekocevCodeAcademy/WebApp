using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Core.BeautyShop
{
    public class Visit
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }

        [Required, Display(Name = "Customer")]
        public int? CustomerId { get; set; }

        public List<ShopItem> ShopItems { get; set; }

        public Visit()
        {
            ShopItems = new List<ShopItem>();
        }        
    }
}
