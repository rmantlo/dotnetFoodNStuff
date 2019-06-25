using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodNStuff.MVC.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        //public string FullName => $"{FirstName} {LastName}"; //this does same thing as below, works only with get only statements
        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }
}