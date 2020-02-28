using Core.BeautyShop;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainData.BeautyShop.SqlData
{
    public class VisitDataSql : IVisitData
    {
        private readonly BeautyShopDbContext beautyShopDbContext;

        public VisitDataSql(BeautyShopDbContext beautyShopDbContext)
        {
            this.beautyShopDbContext = beautyShopDbContext;
        }
        public int Commit()
        {
            return beautyShopDbContext.SaveChanges();
        }

        public Visit Create(Visit visit)
        {
            beautyShopDbContext.Visits.Add(visit);
            return visit;
        }

        public Visit GetVisitById(int id)
        {
            return beautyShopDbContext.Visits.SingleOrDefault(p => p.Id == id);
        }

        public Visit GetVisitFullObjById(int id)
        {
            return beautyShopDbContext
                .Visits
                .Include(v => v.Customer)
                .ThenInclude(c => c.Membership)
                .Include(v => v.ShopItems)
                .SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Visit> GetVisits(string searchTerm = null)
        {
            return beautyShopDbContext.Visits
                .Include(v => v.Customer)
                .ThenInclude(c => c.Membership)
                .Include(v => v.ShopItems)
                .Where(r => string.IsNullOrEmpty(searchTerm)
                   || r.Customer.FirstName.ToLower().StartsWith(searchTerm.ToLower())
                   || r.Customer.LastName.ToLower().StartsWith(searchTerm.ToLower()))
                .OrderBy(r => r.Customer.FirstName)
                .ToList();
        }

        public IEnumerable<Visit> GetVisitsByCustomer(int customerId)
        {
            return beautyShopDbContext
                .Visits
                .Include(v => v.Customer)
                .ThenInclude(c => c.Membership)
                .Include(v => v.ShopItems)
                .Where(v=>v.CustomerId == customerId)
                .ToList();
        }
    }
}
