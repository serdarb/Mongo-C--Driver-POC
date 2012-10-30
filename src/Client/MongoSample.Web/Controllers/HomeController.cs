using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoSample.Contract;
using MongoSample.Web.Models;

namespace MongoSample.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBasketService _basketService;
        public HomeController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public ActionResult Index()
        {


            ViewBag.Message = "Sample ASP.NET MVC application POC with MongoDB.";

            return View();
        }

        [HttpGet]
        public ActionResult Basket()
        {
            _basketService.Add(new BasketItemDto
           {
               ProductId = "p1",
               ProductName = "Test Product",
               Price = 10,

               Quantity = 1,

               UserEmail = "test@test.com",
               AddedOn = DateTime.Now
           });

            var model = new BasketModel { Items = _basketService.Get("test@test.com") };

            return View(model);

        }

        [HttpPost]
        public ActionResult Basket(string id)
        {
            if (id == "clear")
            {
                _basketService.Clear("test@test.com");
            }           

            var model = new BasketModel { Items = _basketService.Get("test@test.com") };

            return View(model);

        }
    }
}
