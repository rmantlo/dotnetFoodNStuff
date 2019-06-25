using FoodNStuff.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodNStuff.MVC.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(_db.Carts.ToList());
        }
    }
}