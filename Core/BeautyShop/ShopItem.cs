using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BeautyShop
{
    public class ShopItem
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public ShopItemType ShopItemType { get; set; }

        public int VisitId { get; set; }
        
        public Visit Visit { get; set; }

    }
}
