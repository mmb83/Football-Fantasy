using System;
using System.Runtime.InteropServices.JavaScript;
using Football_Fantasy.BuisnessLayer;
namespace Football_Fantasy.PresentationLayer;

public class Admin
{
    public static List<Object> removeUser(string userName)
    {
        List<Object> response = new List<object>();
        if (BuisnessLayer.Admin.removeUser(userName))
        {
            response.Add(new
            {
                message="User removed successfully"
            });
            return response;
        }
        else
        {
            response.Add(new
            {
                message="Deleting user  process failed"
            });
            return response;
        }
    }
    public static List<Object> clearUserAllPlayers(string token)
    {
        string userName = JWT.decodeToken(token);
        List<Object> response = new List<object>();
        if (BuisnessLayer.Admin.clearUserAllPlayers(userName))
        {
            response.Add(new
            {
                message="Players of user cleared successfully"
            });
            return response;
        }
        else
        {
            response.Add(new
            {
                message="deleting user All players process failed"
            });
            return response;
        }
    }
    public static List<Object> addMoneyToUser(string token, int money)
    {
        string userName = JWT.decodeToken(token);
        List<Object> response = new List<object>();
        if (BuisnessLayer.Admin.addMoneyToUser(userName, money))
        {
            response.Add(new
            {
                message="money added successfully"
            });
            return response;
        }
        else
        {
            response.Add(new
            {
                message="adding money procces failed"
            });
            return response;
        }
    }
}