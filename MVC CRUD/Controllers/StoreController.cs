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
    public class StoreController : Controller
    {
        // GET: Store
        StoreEntities1 db = new StoreEntities1();

        public JsonResult GetAllStores()
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Store> storelist = db.Stores.ToList();
            return Json(storelist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetStore(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Store storenew = db.Stores.Find(id);
            return Json(storenew, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Store store)
        {

            if (ModelState.IsValid)
            {
                db.Stores.Add(store);
                db.SaveChanges();
            }
            return View(db.Stores.ToList());

        }

        public ActionResult Edit(/*int id*/)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Edit(Store store)  // Update PartialView  
        {
            // bool status = false;

            if (ModelState.IsValid)
            {
                Store storenew = db.Stores.Where(X => X.ID == store.ID).FirstOrDefault();
                if (storenew != null)
                {
                    storenew.ID = store.ID;
                    storenew.Name = store.Name;
                    storenew.Address = store.Address;
                }


                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            Store storenew = db.Stores.Where(X => X.ID == id).FirstOrDefault();
            if (storenew != null)
            {
                return View(storenew);
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
                Store storenew = db.Stores.Where(X => X.ID == id).FirstOrDefault();
                if (storenew != null)
                {
                    db.Stores.Remove(storenew);
                    db.SaveChanges();
                    // status = true;
                }
            }
            return RedirectToAction("Index");
        }
    }

}
