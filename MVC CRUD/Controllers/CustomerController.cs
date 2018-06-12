using MVC_CRUD.Models;
using System;
using System.Data.Entity.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;

namespace MVC_CRUD.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        StoreEntities1 db = new StoreEntities1();
        // GET: Store
        public JsonResult GetAllCustomers()
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Customer> customerlist = db.Customers.ToList();
            return Json(customerlist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCustomer(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Customer customernew = db.Customers.Find(id);
            return Json(customernew, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
            return View(db.Customers.ToList());
        }

        public ActionResult Edit(/*int id*/)
        {
            return View();
        }



        [HttpPost]
        public ActionResult Edit(Customer customer)  // Update PartialView  
        {
                Customer customernew = db.Customers.Where(X => X.ID == customer.ID).FirstOrDefault();

            if (ModelState.IsValid)
            {
                if (customernew != null)
                {
                    customernew.ID = customer.ID;
                    customernew.Name = customer.Name;
                    customernew.Address = customer.Address;
                }
                db.SaveChanges();
            }
            return View(customernew);

        }


        public ActionResult Delete(int id)
        {
            Customer customernew = db.Customers.Where(X => X.ID == id).FirstOrDefault();
            if (customernew != null)
            {
                return View(customernew);
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
                Customer customer = db.Customers.Where(X => X.ID == id).FirstOrDefault();
                if (customer != null)
                {
                    db.Customers.Remove(customer);
                    db.SaveChanges();
                    // status = true;
                }
            }
            return RedirectToAction("Index");

        }

    }
}