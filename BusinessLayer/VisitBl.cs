using Core.BeautyShop;
using DomainData.BeautyShop;
using System.Linq;

namespace BusinessLayer
{
    public class VisitBl
    {
        private readonly IVisitData visitRepository;

        public VisitBl(IVisitData visitRepository)
        {
            this.visitRepository = visitRepository;
        }

        public ShopItem CreateService(double pay)
        {
            return new ShopItem
            {
                ShopItemType = ShopItemType.Service,
                Price = pay
            };
        }

        public ShopItem CreateProduct(double pay)
        {
            return new ShopItem
            {
                ShopItemType = ShopItemType.Product,
                Price = pay
            };
        }

        public double? TotalExpences(int visitId)
        {
            var visit = visitRepository.GetVisitFullObjById(visitId);
            if (visit == null)
                return null;

            return TotalExpences(visit);
        }

        public double TotalExpences(Visit visit)
        {
            var sum = 0.0;
            foreach (var item in visit.ShopItems.Where(i => i.ShopItemType == ShopItemType.Product).ToList())
            {
                if (visit.Customer.IsMember)
                {
                    sum += item.Price * (1 - visit.Customer.Membership.DiscountProducts);
                }
                else
                {
                    sum += item.Price;
                }
            }

            foreach (var item in visit.ShopItems.Where(i => i.ShopItemType == ShopItemType.Service).ToList())
            {
                if (visit.Customer.IsMember)
                {
                    sum += item.Price * (1 - visit.Customer.Membership.DiscountService);
                }
                else
                {
                    sum += item.Price;
                }
            }

            return sum;
        }
    }
}
