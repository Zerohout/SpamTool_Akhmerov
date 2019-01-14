using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SpamTool_Akhmerov.ValidationRules
{
    class RegExValidationRule : ValidationRule
    {
        private Regex _Regex;

        public string Expression
        {
            get => _Regex?.ToString();
            set => _Regex = string.IsNullOrEmpty(value) ? null : new Regex(value);
        }

        public string ErrorMeessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (_Regex is null) return ValidationResult.ValidResult;
            if (!(value is string str)) return new ValidationResult(false, "Объект не является строкой");
            if (_Regex.IsMatch(str)) return ValidationResult.ValidResult;

            return new ValidationResult(false, ErrorMeessage ?? $"Строка {str} не удовлетворяет регулярному выражению");
        }
    }
}
