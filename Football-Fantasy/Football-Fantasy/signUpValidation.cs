namespace SignUp;

public class signUpValidation
{
    public static bool isfirstNamevalid(string firstName)
        {
            string forbidden = "_-#$%&*+/=?@";
            for (int i = 0; i < firstName.Length; i++)
            {
                if (forbidden.Contains(firstName[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool islastNamevalid(string lastName)
        {
            string forbidden = "_-#$%&*+/=?@";
            for (int i = 0; i < lastName.Length; i++)
            {
                if (forbidden.Contains(lastName[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool isuserNameValid(string userName)
        {
            bool atoZand0To9 = userName.All(Char.IsLetterOrDigit);
            string number = "0123456789";
            bool firstchar = number.Contains(userName[0]);
            if (atoZand0To9 && !firstchar)
            {
                return true;
            }

            return false;
        }

        public static bool firstNameValidation(string firstName)
        {
            if (isfirstNamevalid(firstName))
            {
                return true;
            }

            return false;
        }

        public static bool lastNameValidation(string lastName)
        {
            if (islastNamevalid(lastName))
            {
                return true;
            }

            return false;
        }

        public static bool userNameValidation(string userName)
        {
            if (isuserNameValid(userName))
            {
                return true;
            }

            return false;
        }

        public static bool isLocalValid(string email)
        {
            if (!email.Contains("@"))
            {
                return false;
            }

            int whereIsAtSign = 0;
            string forbidden = "-#$%&*+/=?", localPart = "";
            if (!email.Contains("@") && !email.Contains("."))
            {
                return false;
            }

            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == '@')
                {
                    whereIsAtSign = i;
                    break;
                }
            }

            localPart += email.Substring(0, whereIsAtSign);
            if (localPart.Contains('@'))
            {
                return false;
            }

            for (int i = 0; i < localPart.Length; i++)
            {
                if (forbidden.Contains(localPart[i]))
                {
                    return false;
                }
            }

            if (localPart.Contains("..") || localPart.StartsWith('.') || localPart.StartsWith('-') ||
                localPart.StartsWith('_') || localPart.Contains("--") || localPart.Contains("__"))
            {
                return false;
            }

            if (localPart.EndsWith('.') || localPart.EndsWith('-') || localPart.EndsWith('_'))
            {
                return false;
            }

            return true;
        }

        public static bool isDomainValid(string email)
        {
            int whereIsAtsign = 0, whereIsDot = (email.Length) - 1;
            string forbidden = "_-#$%&*+/=?", tldPart = "", domainPart = "";
            for (int i = email.Length - 1; i > 0; i--)
            {
                if (email[i] == '.')
                {
                    whereIsDot = i;
                    break;
                }

            }

            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == '@')
                {
                    whereIsAtsign = i;
                    break;
                }
            }

            tldPart += email.Substring(whereIsDot);
            domainPart += email.Substring(whereIsAtsign + 1);
            for (int i = 0; i < domainPart.Length; i++)
            {
                if (forbidden.Contains(domainPart[i]))
                {
                    return false;
                }
            }

            if (domainPart.Contains('@') || tldPart.Contains('@'))
            {
                return false;
            }

            if (domainPart.StartsWith(".") || domainPart.EndsWith(".") || domainPart.StartsWith('-') ||
                domainPart.EndsWith('-'))
            {
                return false;
            }

            if (domainPart.Contains("..") || domainPart.Contains("__") || domainPart.Contains("--"))
            {
                return false;
            }

            if (tldPart.Length < 3)
            {
                return false;
            }

            return true;
        }

        public static bool isPassWordValid(string password)
        {
            string forbidden = "{}[]' !#$%&*+=?";
            bool isHaveRagham = false, isHaveLowerCase = false, isHaveUpperCase = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (forbidden.Contains(password[i]))
                {
                    return false;
                }
            }

            if (password.Length < 5 || password.Length > 15)
            {
                return false;
            }

            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 48 && password[i] <= 57)
                {
                    isHaveRagham = true;
                }

                if (password[i] >= 65 && password[i] <= 90)
                {
                    isHaveUpperCase = true;
                }

                if (password[i] >= 97 && password[i] <= 122)
                {
                    isHaveLowerCase = true;
                }
            }

            if (isHaveRagham && isHaveLowerCase && isHaveUpperCase)
            {
                return true;
            }

            return false;
        }

        public static bool emailValidation(string email)
        {
            if (isLocalValid(email) && isDomainValid(email))
            {
                return true;
            }

            return false;
        }

        public static bool passwordValidation(string password)
        {
            if (isPassWordValid(password))
            {
                return true;
            }

            return false;
        }
    }