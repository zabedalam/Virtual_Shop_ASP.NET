using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;
using System.Web.Helpers;

namespace WebShop.Controllers
{
    //[Authorize(Users = "admin@ourshop.com")]
    //public class ProductsController : Controller { }
    
        
    
    public class HomeController : Controller
    {
        
        public ActionResult Index(string searchCriteria)
        {
            var factory = new ShopFactory();

            IQueryable<Product> prods = factory.Products.OrderBy(p => p.Name);
            if (searchCriteria != null)
            {
                prods = prods.Where(p => p.Name.Contains(searchCriteria));
            }
            var products = prods.Take(10).ToList();


            //var products = factory.Products.ToList();
            return View(products);
        }
        public ActionResult Details(int id)
        {
            var factory = new ShopFactory();
            var found = factory.Products.Where(p => p.ID == id).FirstOrDefault();
            return View(found);
        }
        public ActionResult Picture(int id)
        {
            var factory = new ShopFactory();
            var product = factory.Products.Where(p => p.ID == id).FirstOrDefault();
            if (product == null)
            {
                return HttpNotFound();
            }
            var img = new WebImage(string.Format("~/Content/Images/{0}.jpg", product.ImageName));
            img.Resize(50, 50);
            return File(img.GetBytes(), "image/jpeg");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}