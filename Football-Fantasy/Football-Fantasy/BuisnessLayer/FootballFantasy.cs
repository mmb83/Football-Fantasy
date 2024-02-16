using Football_Fantasy.DataAccessLayer;
using Football_Fantasy;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SignUp;

namespace Football_Fantasy.BuisnessLayer;
public class BuisnessLayer
{
    public static bool clear()
    {
        if (true)
        {
            DataAccessLayer.DataAccessLayer.clear();
            return true;
        }
        return false;
    }
    public static List<User> getAllUsersInfo()
    {
        List<User> users = new List<User>();
        users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
        return users;
    }
}