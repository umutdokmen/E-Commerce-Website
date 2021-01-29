using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce_Website.Models.Entity;
namespace Ecommerce_Website.Controllers


{
    public class CustomerController : Controller
    {

        // GET: Customer
        productEntities db = new productEntities();
        
        public ActionResult Index(string p)
        {
            var values = from v in db.Tbl_Product select v;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(m => m.ProductTitle.Contains(p) || m.ProductDescription.Contains(p));
            }
            return View(values.ToList());
            
        }
    }
}