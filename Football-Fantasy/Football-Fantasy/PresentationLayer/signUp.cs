using System.Runtime.InteropServices.JavaScript;
using SignUp;
using System;
using Football_Fantasy;
using Football_Fantasy.BuisnessLayer;
namespace Football_Fantasy.PresentationLayer;

public class signUpUser
{
    public static List<Object> addUser(User newUser)
    {
        string res = "Invalid";
        List<Object> response = new List<object>();
        if (!BuisnessLayer.signUpUser.isFirstNameValid(newUser.userFirstName))
        {
            res += " firstName ,";
        }
        if (!BuisnessLayer.signUpUser.isLastNameValid(newUser.userLastName))
        {
            res += " lastName ,";
        }

        if (!BuisnessLayer.signUpUser.isEmailValid(newUser.userEmail))
        {
            res += " email ,";
        }

        if (!BuisnessLayer.signUpUser.isUserNameValid(newUser.userUserName))
        {
            res += " userName ,";
        }

        if (!BuisnessLayer.signUpUser.isPassWordValid(newUser.userPassword))
        {
            res += " password ";
        }
        if (res.Length <= 10 )
        {
            if (BuisnessLayer.signUpUser.addUser(newUser))
            {
                response.Add(new
                {
                    message = "Verify your email"
                });
                return response;
            }
            response.Add(new
            {
                message = "Username or email is taken by another user"
            });
            return response;
        }
        response.Add(new
        {
            message = res.Substring(0,res.Length-1)
        });
        return response;
    }
}