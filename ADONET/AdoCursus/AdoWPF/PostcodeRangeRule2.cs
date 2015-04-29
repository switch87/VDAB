using System;
using System.Globalization;
using System.Windows.Controls;

namespace AdoWPF
{
    public class PostcodeRangeRule2 : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var postcode = 0;
            try
            {
                if (((string) value).Length > 0)
                    postcode = short.Parse((string) value);
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "Illegal characters or " + e.Message);
            }
            if ((postcode < 1000) || (postcode > 9999))
            {
                return new ValidationResult(false, "de postcode moet > 999 en < 1000 zijn");
            }
            return new ValidationResult(true, null);
        }
    }
}