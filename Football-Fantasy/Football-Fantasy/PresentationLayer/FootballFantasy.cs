using System.Runtime.InteropServices.JavaScript;
using SignUp;
using System;
using Football_Fantasy;

namespace Football_Fantasy.PresentationLayer;
using Football_Fantasy.BuisnessLayer;

public class PresentationLayer
{
    public static List<Object> getAllUsersInfo()
    {
        List<Object> response = new List<object>();
        List<User> users = new List<User>();
        users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
        if (users.Count==0)
        {
            response.Add(new
            {
                message="Database is empty"
            });
            return response; 
        }
        else
        {
            foreach (var user in users) 
            {
                response.Add(new
                {
                    id = user.userKey,
                    name = user.userFirstName,
                    lastName = user.userLastName,
                    email = user.userEmail,
                    username = user.userUserName,
                    password = user.userPassword
                });
            }
            return response;
        }
    }
    public static List<Object> clear()
    {
        List<Object> response = new List<object>();
        if (BuisnessLayer.clear())
        {
            response.Add(new
            {
                message="All users deleted"
            });
            return response;
        }
        response.Add(new
        {
            message="We don't have any user in our database"
        });
        return response;
    } 
    
}