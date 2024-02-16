using ServiceStack;
using System;
using Football_Fantasy;
namespace Football_Fantasy.DataAccessLayer;
public class DataAccessLayer
{
    
    public static void clear()
    {
        using (var db = new Football_Fantasy.Program.Database())
        {
            foreach (var user in db.users)
            {
                db.users.Remove(user);
            }
            db.SaveChanges();
        }
    }

    public static List<User> getAllUsersOfDatabase()
    {
        List<User> response = new List<User>();
        using (var db = new Football_Fantasy.Program.Database())
        {
            foreach (var user in db.users)
            {
                response.Add(user);
            }
            return response;
        }
    }
    
}