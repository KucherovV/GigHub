using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub1.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            bool isValid = DateTime.TryParse(Convert.ToString(value), out dateTime);
        
            return (isValid && dateTime > DateTime.Now);
        }
    }
}