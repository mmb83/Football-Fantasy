namespace Football_Fantasy.DataAccessLayer;

public class Admin
{
    public static void removeUser(int userKey)
    {
        using (var db = new Football_Fantasy.Program.Database())
        {
            foreach (var record in db.users)
            {
                if (record.userKey == userKey)
                {
                    db.users.Remove(record);
                    db.SaveChanges();
                }
            }
        }
    }
    public static void clearUserAllPlayers(int userKey)
    {
        using (var db = new Football_Fantasy.Program.Database())
        {
            foreach (var record in db.userPlayers)
            {
                if (record.userKey == userKey)
                {
                    db.userPlayers.Remove(record);
                    db.SaveChanges();
                }
            }
        }
    }
    public static void addMoneyToUser(string userName, int money)
    {
        using (var db = new Football_Fantasy.Program.Database())
        {
            foreach (User? user in db.users?? Enumerable.Empty<User>())
            {
                if (user.userUserName == userName)
                {
                    user.money += money;
                    db.SaveChanges();
                    return;
                }
            }
        }
    }
}