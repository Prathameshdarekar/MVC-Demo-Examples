using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD.Models
{
    public class Products
    {
        public int Id { get; set; } // Primary key for the product

        [Required] // Ensures the Name is required
        [StringLength(100)] // Limits the length of the Name
        public string Name { get; set; } // Product name

        [Required] // Ensures the Price is required
        [Range(0.01, double.MaxValue)] // Ensures the Price is a positive value
        public decimal Price { get; set; } // Product price

        [StringLength(500)] // Limits the length of the Description
        public string Description { get; set; } // Product description
    }
}