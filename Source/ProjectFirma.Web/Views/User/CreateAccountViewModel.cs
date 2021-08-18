using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.User
{
    public class CreateAccountViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [PasswordPropertyText]
        [ValidatePassword]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required]
        [PasswordPropertyText]
        [ValidatePassword]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("Organization")]
        public int OrganizationID { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (Password != ConfirmPassword)
            {
                errors.Add(new SitkaValidationResult<CreateAccountViewModel, string>("Passwords must match.", z => z.Password));
            }

            if (!VerifyPasswordComplexity(Password))
            {
                errors.Add(new ValidationResult(GetPasswordComplexityErrorMessage(Password)));
            }

            return errors;
        }

        public static bool VerifyPasswordComplexity(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;

            if (password.Length < ValidatePasswordAttribute.MinPasswordCharacters) return false;

            var uppercaseCount = password.Where((t, i) => char.IsUpper(password, i)).Count() >= ValidatePasswordAttribute.MinRequiredUpperCaseCharacters;
            var specialCount = password.Where((t, i) => char.IsPunctuation(password, i) || char.IsSeparator(password, i) || char.IsSymbol(password, i)).Count() >= ValidatePasswordAttribute.MinRequiredSymbolCharacters;
            var digitCount = password.Where((t, i) => char.IsDigit(password, i) || char.IsNumber(password, i)).Count() >= ValidatePasswordAttribute.MinRequiredNumericCharacters;

            bool minRequirementMet = true;
            switch (ValidatePasswordAttribute.RequirementGroup)
            {
                case ValidatePasswordAttributeRequirement.SpecialNumeric:
                    minRequirementMet = specialCount && digitCount;
                    break;
                case ValidatePasswordAttributeRequirement.UppercaseSpecialNumeric:
                    minRequirementMet = uppercaseCount && specialCount && digitCount;
                    break;
                case ValidatePasswordAttributeRequirement.UppercaseSpecial:
                    minRequirementMet = uppercaseCount && specialCount;
                    break;
                case ValidatePasswordAttributeRequirement.UppercaseNumeric:
                    minRequirementMet = uppercaseCount && digitCount;
                    break;
                //default is any....
                case ValidatePasswordAttributeRequirement.Any:
                    minRequirementMet = specialCount || digitCount || uppercaseCount;
                    break;
            }

            if (!minRequirementMet)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(ValidatePasswordAttribute.PasswordStrengthRegularExpression)
                && !Regex.IsMatch(password, ValidatePasswordAttribute.PasswordStrengthRegularExpression))
            {
                return false;
            }

            return true;
        }

        private static string GetPasswordComplexityErrorMessage(string newPassword)
        {
            var retVal = "Password does not meet minimum complexity requirements: ";
            if (newPassword.Length < ValidatePasswordAttribute.MinPasswordCharacters)
            {
                retVal += String.Format("Password length of {0}. ", ValidatePasswordAttribute.MinPasswordCharacters);
            }
            if (newPassword.Where((t, i) => Char.IsUpper(newPassword, i)).Count() < ValidatePasswordAttribute.MinRequiredUpperCaseCharacters)
            {
                retVal += String.Format("{0} required uppercase character. ", ValidatePasswordAttribute.MinRequiredUpperCaseCharacters);
            }
            if (newPassword.Where((t, i) => Char.IsPunctuation(newPassword, i) || Char.IsSeparator(newPassword, i) || Char.IsSymbol(newPassword, i)).Count() < ValidatePasswordAttribute.MinRequiredSymbolCharacters)
            {
                retVal += String.Format("{0} required Symbol. ", ValidatePasswordAttribute.MinRequiredSymbolCharacters);
            }
            if (newPassword.Where((t, i) => Char.IsDigit(newPassword, i) || Char.IsNumber(newPassword, i)).Count() < ValidatePasswordAttribute.MinRequiredNumericCharacters)
            {
                retVal += String.Format("{0} required number. ", ValidatePasswordAttribute.MinRequiredNumericCharacters);
            }
            return retVal;
        }

    }
}