using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace GongChaWebSale.Models
{
    public class DateAttribute : ValidationAttribute
    {
        private readonly string _startDatePropertyName;
        public DateAttribute(string startDatePropertyName)
        {
            _startDatePropertyName = startDatePropertyName;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var endDate = (DateTime)value;
            var startDateProperty = validationContext.ObjectType.GetProperty(_startDatePropertyName);
            var startDate = (DateTime)startDateProperty.GetValue(validationContext.ObjectInstance);
            if (endDate <= startDate)
            {
                return new ValidationResult("Ngày kết thúc phải lớn hơn ngày bắt đầu.");
            }
            return ValidationResult.Success;
        }
    }
}