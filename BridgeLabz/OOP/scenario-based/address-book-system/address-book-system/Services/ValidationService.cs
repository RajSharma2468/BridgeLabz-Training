using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AddressBookSystem.Services
{
    public class ValidationService
    {
        public static bool ValidateObject(object obj)
        {
            var context = new ValidationContext(obj);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(
                obj,
                context,
                results,
                true
            );

            if (!isValid)
            {
                foreach (var validationResult in results)
                {
                    Console.WriteLine("Validation Error: " + validationResult.ErrorMessage);
                }
            }

            return isValid;
        }
    }
}
