using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Core.BeautyShop;
using DomainData.BeautyShop;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultipleAppSetup.ViewModels;

namespace MultipleAppSetup.Api
{
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly IVisitData visitData;
        private readonly ICustomerData customerData;
        private readonly IShopItemRepository shopItemRepository;
        private readonly VisitBl visitBl;

        public VisitController(IVisitData visitData, ICustomerData customerData, IShopItemRepository shopItemRepository, VisitBl visitBl)
        {
            this.visitData = visitData;
            this.customerData = customerData;
            this.shopItemRepository = shopItemRepository;
            this.visitBl = visitBl;
        }

        [HttpGet("api/[controller]")]
        public IActionResult GetAll(string customer)
        {
            return Ok(visitData.GetVisits(customer));
        }

        [HttpGet("api/[controller]/TotalExpences")]
        public IActionResult GetAllTotalExpences(string customer)
        {
            var totalPrice = 0.0;
            var visits = visitData.GetVisits(customer);
            if(!visits.Any())
            {
                return NotFound();
            }

            foreach (var visit in visits)
            {
                totalPrice += visitBl.TotalExpences(visit);
            }
            return Ok(new
            {
                Customer = customer,
                TotalPrice = totalPrice
            });
        }

        [HttpGet("api/[controller]/TotalExpences/{visitId}")]
        public IActionResult GetAllTotalExpencesByVisitId(int visitId)
        {
            var totalPrice = visitBl.TotalExpences(visitId);
            if (!totalPrice.HasValue)
            {
                return NotFound();
            }
                       
            return Ok(new
            {
                VisitId = visitId,
                TotalPrice = totalPrice
            });
        }

        [HttpGet("api/[controller]/{id}", Name = "FetchVisit")]
        public IActionResult Get(int id)
        {
            return Ok(visitData.GetVisitFullObjById(id));
        }

        [HttpGet("api/[controller]/ShopItemType")]
        public IActionResult GetShopItes(int id)
        {
            var enums = Enum.GetValues(typeof(ShopItemType)).Cast<ShopItemType>().Select(x => new { Id = (int)x, Name = x.ToString() });
            return Ok(enums);
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

        [HttpPost("api/[controller]")]
        public IActionResult Create(VisitDto visitDto)
        {
            var customer = customerData.GetCustomerById(visitDto.CustomerId.GetValueOrDefault());
            if(customer == null)
            {
                return BadRequest();
            }

            var visit = new Visit();
            visit.CustomerId = visitDto.CustomerId;
            
            var shopItemsValues = (IEnumerable<int>)Enum.GetValues(typeof(ShopItemType));
            foreach (var shopItem in visitDto.ShopItems)
            {
                if (!shopItemsValues.Any(x => x == shopItem.ShopItemType))
                {
                    ModelState.AddModelError("ShopItemType", $"ShopItemType[{visitDto.ShopItems.IndexOf(shopItem)}] {shopItem.ShopItemType} does not exists.");
                }

                if (ModelState.IsValid)
                {
                    visit.ShopItems.Add(new ShopItem
                    {
                        Price = Math.Abs(shopItem.Price.GetValueOrDefault()),
                        ShopItemType = (ShopItemType)shopItem.ShopItemType
                    });
                }
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(new ValidationProblemDetails(ModelState));
                //return BadRequest(ModelState);
            }


            visitData.Create(visit);
            visitData.Commit();
            return CreatedAtRoute("FetchVisit", new { id = visit.Id }, visit);
        }

        [HttpPost("api/[controller]/{VisitId}/Service/{price}")]
        public IActionResult AddService(int visitId, double price)
        {
            return CreateShopItem(visitId, price, ShopItemType.Service);
        }

        [HttpPost("api/[controller]/{VisitId}/Product/{price}")]
        public IActionResult AddProduct(int visitId, double price)
        {
            return CreateShopItem(visitId, price, ShopItemType.Product);
        }

        private IActionResult CreateShopItem(int visitId, double price, ShopItemType shopItemType)
        {
            var visit = visitData.GetVisitById(visitId);
            if (visit == null)
            {
                return BadRequest();
            }

            var shopItem = new ShopItem();
            shopItem.Price = price;
            shopItem.ShopItemType = shopItemType;
            shopItem.VisitId = visitId;

            shopItemRepository.Insert(shopItem);
            shopItemRepository.Commit();

            return CreatedAtRoute("FetchVisit", new { id = visit.Id }, shopItem);
        }
    }
}