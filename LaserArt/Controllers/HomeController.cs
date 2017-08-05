using LaserArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaserArt.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var products = LaserArt.Models.Product.GetProductsByCategoryId(1);
            
            return View(products);
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
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult CreateProduct()
        {
            ViewBag.Categories = LaserArt.Models.Category.GetCategories(null);
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult CreateProduct(Product newProduct)
        {
            try
            {
                newProduct.SaveProduct();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
               return RedirectToAction("CreateProduct");
            }
        }

        public ActionResult Product(int id)
        {
          var product=  LaserArt.Models.Product.GetProducts(id).FirstOrDefault();
            return View(product);
        }

        public ActionResult Category(int id)
        {
            var category = LaserArt.Models.Category.GetCategories(id).FirstOrDefault();
            ViewBag.CategoryName = category.CategoryName;
            var products = LaserArt.Models.Product.GetProductsByCategoryId(id);
            return View(products);
        }
    }
}