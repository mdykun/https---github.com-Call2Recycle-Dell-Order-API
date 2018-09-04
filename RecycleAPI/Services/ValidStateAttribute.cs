using System;
using System.ComponentModel.DataAnnotations;

namespace RecycleAPI.Services
{
    public class ValidStateAttribute : ValidationAttribute
    {
        public string Message { get; set; }

        public ValidStateAttribute(string validationMessage) : base()
        {
            Message = validationMessage;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && ValidationService.IsValidState(value.ToString()))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(Message);
        }
    }
}
