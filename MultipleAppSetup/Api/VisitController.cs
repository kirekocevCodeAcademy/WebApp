using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainData.BeautyShop;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultipleAppSetup.Api
{
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly IVisitData visitData;

        public VisitController(IVisitData visitData)
        {
            this.visitData = visitData;
        }

        [HttpGet("api/[controller]")]
        public IActionResult GetAll(string customer)
        {
            return Ok(visitData.GetVisits(customer));
        }

        [HttpGet("api/customer/{customenrId}/visit")]
        public IActionResult GetVisitByCustoemrId(int customenrId)
        {
            var tempVisits = visitData.GetVisitsByCustomer(customenrId);
            if(tempVisits == null)
            {
                return NotFound();
            }

            return Ok(tempVisits);
        }
    }
}