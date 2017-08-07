using MvcOperationWithAjaxAndJson.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOperationWithAjaxAndJson.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _dbContext;

        public ProductController()
        {
            _dbContext = new ApplicationDbContext();
        }

        
        public ActionResult Index()
        {
            return View();
        }


        // GET: Product
        public ActionResult GetProducts()
        {
            var p = _dbContext.Products.ToList();

            return Json(p, JsonRequestBehavior.AllowGet);
        }

        // GET: Product by id
        public ActionResult Get(int id)
        {
            var p = _dbContext.Products.ToList().Find(x => x.Id == id);

            return Json(p,JsonRequestBehavior.AllowGet);
        }

        // Post: Create product
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]Product model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Add(model);
                _dbContext.SaveChanges();

            }
            return Json(model,JsonRequestBehavior.AllowGet);
        }

        // Post: Update product
        [HttpPost]
        public ActionResult Update(Product model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Entry(model).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // Post: Delete product by id
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var p = _dbContext.Products.ToList().Find(x => x.Id == id);
            if (p != null)
            {
                _dbContext.Products.Remove(p);
                _dbContext.SaveChanges();
            }
            return Json(p,JsonRequestBehavior.AllowGet);
        }

    }
}
