using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodNStuff.MVC.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }
        public Dictionary<Product, int> CartList { get; set; }
    }
}