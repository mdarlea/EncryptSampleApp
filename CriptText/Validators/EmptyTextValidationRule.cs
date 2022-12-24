using System.Globalization;
using System.Windows.Controls;

namespace CriptText.Validators
{
	public class EmptyTextValidationRule : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			string? valueToValidate = value as string;

			if (string.IsNullOrWhiteSpace(valueToValidate))
			{
				return new ValidationResult(false, "Text is required");
			}

			return new ValidationResult(true, null);
		}
	}
}
