namespace Football_Fantasy.DataAccessLayer;

public class Otp
{
    public static void addUserFromHelperDataBaseToMainDatabase(string userName)
    {
        using (var db = new Football_Fantasy.Program.Database())
        {
            foreach (var clientUser in db.clientIsVerifying)
            {
                if (clientUser.helperUserName == userName)
                {
                    var user = new User();
                    user.userFirstName = clientUser.helperName;
                    user.userLastName = clientUser.helperLastName;
                    user.userUserName = clientUser.helperUserName;
                    user.userPassword = clientUser.helperPassword;
                    user.userEmail = clientUser.helperEmail;
                    user.money = 100;
                    db.users.Add(user);
                    db.clientIsVerifying.Remove(clientUser);
                    db.SaveChanges();
                }
            }    
        }
    }
    public static void removeUserFromHelperDatabase(string  userName)
    {
        using (var db = new Football_Fantasy.Program.Database())
        {
            foreach (var user in db.clientIsVerifying)
            {
                if (user.helperUserName == userName)
                {
                    db.clientIsVerifying.Remove(user);
                    db.SaveChanges();
                }
            }
        }
    }

    public static List<ClientIsVerifying> getHelperDatabase()
    {
        List<ClientIsVerifying> response = new List<ClientIsVerifying>();
        using (var db=new Football_Fantasy.Program.Database())
        {
            foreach (var user in db.clientIsVerifying)
            {
                response.Add(user);
            }
            return response;
        }
    }
}