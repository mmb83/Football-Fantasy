namespace Football_Fantasy.DataAccessLayer;

public class Client
{
    public class client
    {
        public static void addScoreToUsers()
        {
            using (var db = new Football_Fantasy.Program.Database())
            {
                foreach (var user in db.users)
                {
                    user.score = BuisnessLayer.Client.client.calculateScore(user.userUserName);
                    db.SaveChanges();
                }
                return;
            }
        }
    }
}