using System;
using Football_Fantasy.DataAccessLayer;
namespace Football_Fantasy.BuisnessLayer;

public class Admin
{
    public static bool removeUser(string userName)
    {
        List<User> users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
        foreach (var user in users)
        {
            if (user.userUserName == userName)
            {
                if (true)
                {
                    DataAccessLayer.Admin.removeUser(user.userKey);
                    DataAccessLayer.Admin.clearUserAllPlayers(user.userKey);
                    return true;
                }

                return false;
            }
        }

        return false;
    }
    public static bool clearUserAllPlayers(string userName)
    {
        List<User> users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
        foreach (var user in users)
        {
            if (user.userUserName == userName)
            {
                if (true)
                {
                    DataAccessLayer.Admin.clearUserAllPlayers(user.userKey);
                    return true;
                }

                return false;
            }
        }
        return false;
    }
    public static bool addMoneyToUser(string userName, int money)
    {
        if (true)
        {
            DataAccessLayer.Admin.addMoneyToUser(userName, money);
            return true;
        }
        return false;
    }
}