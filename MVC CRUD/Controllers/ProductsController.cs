﻿using MVC_CRUD.Models;
using System;
using System.Data.Entity.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;

namespace MVC_CRUD.Controllers
{
    public class ProductsController : Controller
    {
        StoreEntities1 db = new StoreEntities1();

        public JsonResult GetAllProducts()
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Product> productlist = db.Products.ToList();
            return Json(productlist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProduct(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Product productnew = db.Products.Find(id);

            return Json(productnew, JsonRequestBehavior.AllowGet);
            //return View(productnew); 

        }


        public ActionResult Index()
        {
            return View();
           
        }
    
        
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();

                
            }

            return View(product);
        }



        public ActionResult Edit(/*int id*/)
        {
            return View();
        }



        [HttpPost]
        public ActionResult Edit(Product product)  // Update PartialView  
        {

            if (ModelState.IsValid)
            {
                Product productnew = db.Products.Where(X => X.ID == product.ID).FirstOrDefault();
                if (productnew != null)
                {
                    productnew.ID = product.ID;
                    productnew.Name = product.Name;
                    productnew.Price = product.Price;
                }

                db.SaveChanges();
            }
            return View(product);


        }


        public ActionResult Delete(int id)
        {
            Product productnew = db.Products.Where(X => X.ID == id).FirstOrDefault();
            if (productnew != null)
            {
                return View(productnew);
            }
            else
                return HttpNotFound();
        }



        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteEmployee(int id)  // Update PartialView  
        {
            // bool status = false;

            if (ModelState.IsValid)
            {
                Product productnew = db.Products.Where(X => X.ID == id).FirstOrDefault();
                if (productnew != null)
                {
                    db.Products.Remove(productnew);
                    db.SaveChanges();
                    // status = true;
                }
            }
            return RedirectToAction("Index");
        }

    }
}