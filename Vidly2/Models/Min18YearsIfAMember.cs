using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly2.Models
{
    public class Min18YearsIfAMember : ValidationAttribute

    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
            {
                //Static field 'Success' is used to return a successfull validation result
                return ValidationResult.Success;
            }

            if (customer.BirthDate == null)
            {
                //to return an error instantiate a new ValidationResult with a error msg as a parameter
                return new ValidationResult("Birthdate is required");
            }

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old to be a member");

        }
    }
}