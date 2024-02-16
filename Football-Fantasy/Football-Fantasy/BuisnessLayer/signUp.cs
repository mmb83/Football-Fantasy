using SignUp;
namespace Football_Fantasy.BuisnessLayer;

public class signUpUser
{
    public static bool addUser(User newUser)
    {
        List<User> users = new List<User>(); 
        users=DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
        foreach (var user in users)
        {
            if (user.userUserName.ToUpper() == newUser.userUserName.ToUpper() || user.userEmail.ToUpper() == newUser.userEmail.ToUpper()) {
                    return false;
            }
            else
            {
                DataAccessLayer.signUp.addUser(newUser); 
                return true; 
            } 
        }

        if (users.Count == 0)
        {
            DataAccessLayer.signUp.addUser(newUser); 
        }
        return true;
    }
    public static bool isFirstNameValid(string firstName)
    {
        if (signUpValidation.firstNameValidation(firstName))
        {
            return true;
        }

        return false;
    }

    public static bool isLastNameValid(string lastName)
    {
        if (signUpValidation.lastNameValidation(lastName))
        {
            return true;
        }

        return false;
    }

    public static bool isEmailValid(string email)
    {
        if (signUpValidation.emailValidation(email))
        {
            return true;
        }

        return false;
    }

    public static bool isUserNameValid(string userName)
    {
        if (signUpValidation.userNameValidation(userName))
        {
            return true;
        }

        return false;
    }

    public static bool isPassWordValid(string password)
    {
        if (signUpValidation.passwordValidation(password))
        {
            return true;
        }

        return false;
    }
    public static void sendVerifyingEmail(string Otp,string name,string email)
    {
        OTP.OTP.sendEmail(Otp,name,email);
    }
}