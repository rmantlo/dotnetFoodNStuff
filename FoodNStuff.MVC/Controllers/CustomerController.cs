using FoodNStuff.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodNStuff.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Customer
        public ActionResult Index()
        {
            return View(_db.Customers.ToList());
        }

        //GET: Customer/Create
        public ActionResult Create()
        {

        }
        //POST: Customer/Create
        public ActionResult Create()
        {

        }
        //GET: Customer/Edit/{id}
        //POST: Customer/Edit/{id}
        //GET: Customer/Delete/{id}
        //POST: Customer/Delete/{id}
    }
}