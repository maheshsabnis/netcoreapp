using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcoreapp.Models
{
    /// <summary>
    /// ValidationAttribute: The class used for checking
    /// Model validations using IsValid(value) method
    /// value is the Model Property value to be tested and 
    /// The method returns boolean 
    /// </summary>
    public class NUmericNonNegativeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (Convert.ToInt32(value) < 0)
            {
                return false;
            }
            return true;
        }
    }
}
