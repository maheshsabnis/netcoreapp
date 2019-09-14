using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace netcoreapp.Models
{
    public class Category
    {
        [Key] // Primary Identity Key
        public int CategoryRowId { get; set; }
        [Required(ErrorMessage ="CategoryId is Required")]
        public string CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name is Required")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Base Price is Required")]
     //   [NUmericNonNegative(ErrorMessage ="Cannot accept -Ve Price")]
        public int BasePrice { get; set; }
        // one to many relationship
        public ICollection<Product> Products { get; set; }
    }
}
