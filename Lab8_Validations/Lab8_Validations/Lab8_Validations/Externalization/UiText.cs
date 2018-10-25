using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8_Validations.Externalization
{
    public static class UiText
    {
        public const string UsernameRequired = "A username is required.";
        public const string PasswordRequired = "A password is required.";
        public const string EmailInvalid = "Please enter a valid email adress.";
        public const string TooShortPassword = "Your password must contain 10 characters.";
        public const string NoLowerCasePassword = "Your password must contain one lowercase letter.";
        public const string NoUpperCasePassword = "Your password must contain one uppercase letter.";
        public const string NoNumberPassword = "Your password must contain one number.";
    }
}
