using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.BeautyShop;

namespace DomainData.BeautyShop.InMemoryData
{
   public class VisitDataInMemory : IVisitData
    {
        private List<Visit> visits;
        public VisitDataInMemory()
        {
            visits = new List<Visit>();
        }
        public int Commit()
        {
            return 0;
        }

        public Visit Create(Visit visit)
        {
            visit.Id = visits.Any() ? visits.Max(p => p.Id) + 1 : 1;
            visits.Add(visit);

            return visit;
        }

        public Visit GetVisitById(int id)
        {
            return visits.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Visit> GetVisits(string searchTerm = null)
        {
            return visits
               .Where(r => string.IsNullOrEmpty(searchTerm)
                   || r.Customer.FirstName.ToLower().StartsWith(searchTerm.ToLower())
                   || r.Customer.LastName.ToLower().StartsWith(searchTerm.ToLower()))
               .OrderBy(r => r.Customer.FirstName);
        }
    }
}
