using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShippingApp.DAL;
using OnlineShippingApp.Models;
using PagedList;

namespace OnlineShippingApp.Controllers
{
    public class OrderController : Controller
    {
        private AppContext db = new AppContext();


        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var orders = from s in db.Orders
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(s => s.clientName.Contains(searchString)
                                       || s.SpeicialCode.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    orders = orders.OrderByDescending(s => s.clientName);
                    break;
                case "Date":
                    orders = orders.OrderBy(s => s.OrderDate);
                    break;
                case "date_desc":
                    orders = orders.OrderByDescending(s => s.OrderDate);
                    break;
                default:  // Name ascending 
                    orders = orders.OrderBy(s => s.clientName);
                    break;
            }

            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(orders.ToPagedList(pageNumber, pageSize));
        }

         public ViewResult Tracking(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var orders = from s in db.Orders
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(s => s.clientName.Contains(searchString)
                                       || s.SpeicialCode.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    orders = orders.OrderByDescending(s => s.clientName);
                    break;
                case "Date":
                    orders = orders.OrderBy(s => s.OrderDate);
                    break;
                case "date_desc":
                    orders = orders.OrderByDescending(s => s.OrderDate);
                    break;
                default:  // Name ascending 
                    orders = orders.OrderBy(s => s.clientName);
                    break;
            }

            int pageSize = 1;
            int pageNumber = (page ?? 1);
            return View(orders.ToPagedList(pageNumber, pageSize));
        }


        // GET: Order
        //public ActionResult Index()
        //{
        //    return View(db.Orders.ToList());
        //}

        // GET: Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,SpeicialCode,clientName,ClientAddress,Source,Destination,OrderDate,TrackingBy,OrderStatus")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,SpeicialCode,clientName,ClientAddress,Source,Destination,OrderDate,TrackingBy,OrderStatus")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
