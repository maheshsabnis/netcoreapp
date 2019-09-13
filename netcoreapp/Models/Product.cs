using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace netcoreapp.Models
{
    public class Product
    {
        [Key] // Primary Identity Key
        public int ProductRowId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Manufacturer { get; set; }
        public int Price { get; set; }
        public int CategoryRowId { get; set; } // Foreign Key
        public Category Category { get; set; } // Reference for Parent

    }
}
