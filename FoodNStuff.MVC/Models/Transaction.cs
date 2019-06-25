using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodNStuff.MVC.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; } //setting up so entity framework and look at this, take id and peek at customer table, wont store

        [ForeignKey(nameof(Product))] //better incase things need to be renamed
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        //public decimal TotalCost
        //{
        //    get
        //    {
        //        foreach (var product in Product)
        //        {

        //        }
        //    }
        //}
    }
}