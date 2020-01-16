using Core.BeautyShop;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainData.BeautyShop
{
    public interface IVisitData
    {
        Visit Create(Visit visit);
        Visit GetVisitById(int id);
        
        int Commit();
        IEnumerable<Visit> GetVisits(string searchTerm = null);
    }
}
