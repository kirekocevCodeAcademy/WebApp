using Core.BeautyShop;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainData.BeautyShop
{
    public interface IShopItemRepository
    {
        void Insert(ShopItem shopItem);
        void Commit();
    }
}
