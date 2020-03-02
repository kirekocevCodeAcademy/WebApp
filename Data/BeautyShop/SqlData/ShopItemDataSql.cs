using Core.BeautyShop;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainData.BeautyShop.SqlData
{
    public class ShopItemDataSql : IShopItemRepository
    {
        private readonly BeautyShopDbContext beautyShopDbContext;

        public ShopItemDataSql(BeautyShopDbContext beautyShopDbContext) 
        {
            this.beautyShopDbContext = beautyShopDbContext;
        }
        public void Insert(ShopItem shopItem)
        {
            beautyShopDbContext.ShopItem.Add(shopItem);
        }

        public void Commit()
        {
            beautyShopDbContext.SaveChanges();
        }
    }
}
