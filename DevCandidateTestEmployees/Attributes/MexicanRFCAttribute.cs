using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevCandidateTestEmployees.Attributes
{
    public class MexicanRFCAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string rfc = value.ToString();

                // Check if RFC follows the RFC format.
                if (!IsValidMexicanRFC(rfc))
                {
                    return new ValidationResult("RFC format is not valid.");
                }
            }

            // RFC is valid or not provided, so return success. There is another validation if its not provided.
            return ValidationResult.Success;
        }

        // Validate the format of a RFC.
        private bool IsValidMexicanRFC(string rfc)
        {

            // RFC format: 4 letters (name), 6 numbers (birth date), 2 letters (homoclave), 1 digit (checksum)
            string regexPattern = @"^[A-Z]{4}\d{6}[A-Z0-9]{3}$";

            return System.Text.RegularExpressions.Regex.IsMatch(rfc, regexPattern);
        }
    }
}