using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce_Website.Models.Entity;

namespace Ecommerce_Website.Controllers
{
    public class ManagementController : Controller
    {

        // GET: Management
        
        productEntities db = new productEntities();
        public ActionResult Index()
        {
            var values = db.Tbl_Product.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Add_New_Product()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add_New_Product(Tbl_Product p1)
        {

            db.Tbl_Product.Add(p1);
            db.SaveChanges();
            ViewBag.Message = "Product added successfully";
            return View();
        }
        public ActionResult DELETE(int id)
        {
            var product = db.Tbl_Product.Find(id);
            db.Tbl_Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductGet(int id)
        {
            var product = db.Tbl_Product.Find(id);
            return View("ProductGet", product);
        }
        public ActionResult Update(Tbl_Product p1)
        {
            var product = db.Tbl_Product.Find(p1.ProductCode);
            product.ProductTitle = p1.ProductTitle;
            product.ProductDescription = p1.ProductDescription;
            product.Stock = p1.Stock;
            product.ProductPrice = p1.ProductPrice;
            product.ProductImage = p1.ProductImage;
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}