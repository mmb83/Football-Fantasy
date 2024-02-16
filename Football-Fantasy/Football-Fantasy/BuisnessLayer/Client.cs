namespace Football_Fantasy.BuisnessLayer;

public class Client
{
    public class client
    {
        public static int numberOfAllPlayers(string userName)
        {
            int numberOfPlayers = 0;
            List<User> users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
            foreach (var user in users)
            {
                if (user.userUserName == userName)
                {
                    List<Player> allPlayers = DataAccessLayer.player.getAllPlayerOfUser(user.userKey);
                    numberOfPlayers = allPlayers.Count;
                    return numberOfPlayers;
                }
            }
            return numberOfPlayers;
        }
        public static User getProfileOfUser(string userName)
        {
            List<User> users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
            foreach (var user in users)
            {
                if (user.userUserName == userName)
                {
                    return user;
                }
            }
            return new User();
        }
        public static double getUserMoney(string userName)
        {
            List<User> users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
            foreach (var user in users)
            {
                if (user.userUserName == userName)
                {
                    return user.money;
                }
            }
            return -1;
        }
        public static int calculateScore(string userName)
        {
            int mainPlayersScor=0 , backUpPlayersScore=0 , userScore=0 ;
            List<User> users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
            foreach (var user in users)
            {
                if (user.userUserName == userName)
                {
                    List<Player> mainPlayers = DataAccessLayer.player.getMainPlayersOfUser(user.userKey);
                    List<Player> backUpPlayers = DataAccessLayer.player.getBackUpPlayersOfUser(user.userKey);
                    foreach (var player in mainPlayers )
                    {
                        mainPlayersScor += player.event_points;
                    }

                    foreach (var player in backUpPlayers)
                    {
                        backUpPlayersScore += player.event_points;
                    }
                    userScore = (mainPlayersScor * 2) + backUpPlayersScore;
                    return userScore;
                }
            }

            return userScore;
        }

        public static List<User> usersScoreTable(int page)
        {
            List<User> users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
            List<User> sortedUsers = users.OrderBy(o => o.score).ToList();
            sortedUsers.Reverse();
            List<User> response = new List<User>();
            int start = 0, end = 20;
            if (page != 1)
            {
                start = (page - 1) * 20 ;
                end += start ;
                
            }
                if (end > sortedUsers.Count)
                {
                    end = sortedUsers.Count;
                }
            
            for (int i = start; i < end; i++)
            {
                response.Add(sortedUsers.ElementAt(i));
            }
            return response;
        }
    }
    
}