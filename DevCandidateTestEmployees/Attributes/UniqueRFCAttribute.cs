using DevCandidateTestEmployees.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevCandidateTestEmployees.Attributes
{
    public class UniqueRFCAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = new DbModels();

            var rfc = value as string;

            var employeeId = (int)validationContext.ObjectType.GetProperty("ID").GetValue(validationContext.ObjectInstance, null);

            if (dbContext.Employees.Any(e => e.RFC == rfc && e.ID != employeeId))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}