using FoodNStuff.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FoodNStuff.MVC.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Transaction
        public ActionResult Index()
        {
            List<Transaction> transactions = _db.Transactions.OrderBy(o => o.Customer.LastName).ThenBy(o => o.Customer.FirstName).ToList();
            return View(transactions);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Transaction transaction = _db.Transactions.Find(id);
            if (transaction == null)
                HttpNotFound();
            return View(transaction);
        }

        //Get: create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(_db.Customers.ToList(), "CustomerID", "FullName");
            ViewBag.ProductID = new SelectList(_db.Products.ToList(), "ProductID", "ProductName");

            return View();
        }
        //Post: create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid && transaction.CustomerID != 0 && transaction.ProductID != 0)
            {
                _db.Transactions.Add(transaction);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(_db.Customers.ToList(), "CustomerID", "FullName");
            ViewBag.ProductID = new SelectList(_db.Products.ToList(), "ProductID", "ProductName");

            return View(transaction);
        }


        //get: edit/{id}
        public ActionResult Edit(int? id)
        {
            ViewBag.CustomerID = new SelectList(_db.Customers.ToList(), "CustomerID", "FullName");
            ViewBag.ProductID = new SelectList(_db.Products.ToList(), "ProductID", "ProductName");

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Transaction transaction = _db.Transactions.Find(id);
            if (transaction == null)
                HttpNotFound();
            return View(transaction);
        }
        //Post: edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(transaction).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(_db.Customers.ToList(), "CustomerID", "FullName");
            ViewBag.ProductID = new SelectList(_db.Products.ToList(), "ProductID", "ProductName");

            return View(transaction);
        }


        //get: delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Transaction transaction = _db.Transactions.Find(id);
            if (transaction == null)
                HttpNotFound();
            return View(transaction);
        }
        //Post: delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaction transaction = _db.Transactions.Find(id);
            _db.Transactions.Remove(transaction);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}