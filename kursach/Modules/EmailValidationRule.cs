using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace kursach.Modules
{
    public class EmailValidationRule : ValidationRule
    {
        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return new ValidationResult(false, ErrorMessage);

            string email = value.ToString();

            // Проверка формата email с помощью регулярного выражения
            Regex regex = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");
            if (!regex.IsMatch(email))
                return new ValidationResult(false, ErrorMessage);

            return ValidationResult.ValidResult;
        }
    }

    public class MaxLengthValidationRule : ValidationRule
    {
        public int MaxLength { get; set; }
        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return ValidationResult.ValidResult;

            string input = value.ToString();
            if (input.Length > MaxLength)
                return new ValidationResult(false, ErrorMessage);

            return ValidationResult.ValidResult;
        }
    }
}
