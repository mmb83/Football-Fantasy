using System.Diagnostics.CodeAnalysis;
using ServiceStack;
namespace Football_Fantasy.DataAccessLayer;

public class player
{
    public static void addPlayerToMainOfUser(int userKey, Player player,string place)
    {
        using (var db = new Football_Fantasy.Program.Database())
        {
            foreach (var record in db.userPlayers)
            {
                if (record.userKey == userKey)
                {
                    if (record.playerId == player.playerKey)
                    {
                        record.status = 1;
                        record.place = place;
                        db.SaveChanges();
                    }
                }
            }
        }
    }
    public static void addPlayerToBackUpOfUser(int userKey, Player player)
    {
        using (var db = new Football_Fantasy.Program.Database())
        {
            foreach (var record in db.userPlayers)
            {
                if (record.userKey == userKey)
                {
                    if (record.playerId == player.playerKey)
                    {
                        record.status = 2;
                        record.place = "";
                        db.SaveChanges();
                    }
                }
            }
        }
    }
    public static string getPlaceOfPlayerByUserKeyAndPlayerId(int userKey , int playerKey)
    {
        using (var db = new Football_Fantasy.Program.Database())
        {
            foreach (var record in db.userPlayers)
            {
                if (record.userKey == userKey)
                {
                    if (record.playerId == playerKey)
                    {
                        return record.place;
                    }
                }
            }
        }
        return "";
    }
    public static void substitutionMainPlayers(int userKey, int firstId, int secondId)
    {
        string firstPlace = getPlaceOfPlayerByUserKeyAndPlayerId(userKey, firstId);
        string secondPlace = getPlaceOfPlayerByUserKeyAndPlayerId(userKey, secondId);
        using (var db = new Football_Fantasy.Program.Database())
        {
            foreach (var record in db.userPlayers)
            {
                if (record.userKey == userKey)
                {
                    if (record.playerId == firstId)
                    {
                        record.place = secondPlace;
                        db.SaveChanges();
                    }
                    if (record.playerId == secondId)
                    {
                        record.place = firstPlace;
                        db.SaveChanges();
                    }
                }
            }
        }
    }
    public static List<string> getPlaceOfUserPlayers(int userKey)
    {
        List<string> places = new List<string>();
        using (var db = new Football_Fantasy.Program.Database())
        {
            foreach (var record in db.userPlayers)
            {
                if (record.userKey == userKey)
                {
                    if (record.status == 1)
                    {
                        places.Add(record.place);
                    }
                    
                }
            }
            return places;
        }
    }
    public static List<Player> getSortPlayersOfUserByPosition(int userKey , int position)
    {
        List<Player> allPlayers = getAllPlayerOfUser(userKey);
        List<Player> filteredPlayers = new List<Player>();
        List<Player> sortedAndfilteredPlayers = new List<Player>();
        foreach (var player in allPlayers)
        {
            if (player.element_type == position)
            {
                filteredPlayers.Add(player);
            } 
        }
        sortedAndfilteredPlayers = filteredPlayers.OrderBy(o => o.event_points).ToList();
        sortedAndfilteredPlayers.Reverse();
        return sortedAndfilteredPlayers;
    }
   
    public static Player getPlayerByFirstNameAndLastName(string firstName, string lastName)
    {
        using (var db = new Football_Fantasy.Program.Database())
        {
            foreach (var player in db.players )
            {
                if (player.first_name == firstName && player.second_name == lastName)
                {
                    return player;
                }
            }
            return new Player();
        }
    }
    public static Player getPlayerByPlayerKey(int playerKey)
    {
        using (var db = new Football_Fantasy.Program.Database())
        {
            foreach (var player in db.players )
            {
               if (player.playerKey == playerKey)
               {
                    return player;
               }
            }

            return new Player();
        }
    }
    public static List<Player> getAllPlayerOfUser(int userKey)
    {
        List<Player> players = new List<Player>();
        using (var db = new Football_Fantasy.Program.Database())
        {
            foreach (var record in db.userPlayers)
            {
                if (record.userKey == userKey)
                {
                    players.Add(getPlayerByPlayerKey(record.playerId));
                }
            }
            return players;
        }
    }

    public static List<Player> getMainPlayersOfUser(int userKey)
    {
        List<Player> players = new List<Player>();
        using (var db = new Football_Fantasy.Program.Database())
        {
            foreach (var record in db.userPlayers)
            {
                if (record.userKey == userKey)
                {
                    if (record.status == 1)
                    {
                        players.Add(getPlayerByPlayerKey(record.playerId));
                    }
                }
            }
            return players;
        }
    }
    public static List<Player> getBackUpPlayersOfUser(int userKey)
    {
        List<Player> players = new List<Player>();
        using (var db = new Football_Fantasy.Program.Database())
        {
            foreach (var record in db.userPlayers)
            {
                if (record.userKey == userKey)
                {
                    if (record.status == 2)
                    {
                        players.Add(getPlayerByPlayerKey(record.playerId));
                    }
                }
            }
            return players;
        }
    }
    public static void substitution(string userName ,int mainPlayerKey,string backUpFirstName , string backUpLastName)
    {
        string placeOfMain = "";
        using(var db = new Football_Fantasy.Program.Database())
        {
            foreach (var user in db.users)
            {
                if (user.userUserName == userName)
                {
                    foreach (var player1 in getMainPlayersOfUser(user.userKey))
                    {
                        if (player1.playerKey == mainPlayerKey)
                        { 
                            foreach (var player2 in getBackUpPlayersOfUser(user.userKey))
                            {
                                if (player2.first_name == backUpFirstName && player2.second_name == backUpLastName )
                                {
                                    foreach (var record in db.userPlayers)
                                    {
                                        if (player1.playerKey == record.playerId)
                                        {
                                            record.status = 2;
                                            placeOfMain = record.place;
                                            db.SaveChanges();
                                        }
                                        if (player2.playerKey == record.playerId)
                                        {
                                            record.status = 1;
                                            db.SaveChanges();
                                        }
                                    }
                                    foreach (var record in db.userPlayers)
                                    {
                                        if (player1.playerKey == record.playerId)
                                        {
                                            record.place = "";
                                            db.SaveChanges();
                                        }
                                        if (player2.playerKey == record.playerId)
                                        {
                                            record.place = placeOfMain;
                                            db.SaveChanges();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public static void removeAllPlayersOfUserPlayers()
    {
        using (var db = new Football_Fantasy.Program.Database())
        {
            foreach (var record in db.userPlayers)
            {
                db.userPlayers.Remove(record);
            }
            db.SaveChanges();
        }
    }
    public static void removeAllPlayersOfDataBase()
    {
        using (var db = new Football_Fantasy.Program.Database())
        {
            foreach (var player in db.players)
            {
                db.players.Remove(player);
            }
            db.SaveChanges();
        }
    }

    public static void removeAllPlayersOfUsers()
    {
        using (var db = new Football_Fantasy.Program.Database()) 
        {
            foreach (var user in db.users)
            {
                List<Player> userAllPlayers = getAllPlayerOfUser(user.userKey);
                foreach (var player in userAllPlayers)
                {
                    user.money += player.now_cost;
                }
            }
            db.SaveChanges();
        }
    }
    public static void addPlayersToDatabase()
    {
        using (var db = new Football_Fantasy.Program.Database())
        {
            if (db.players != null)
            { 
                removeAllPlayersOfUsers();
                removeAllPlayersOfUserPlayers();
                removeAllPlayersOfDataBase();
            }
            string url="https://fantasy.premierleague.com/api/bootstrap-static/";
            var response = url.GetJsonFromUrl().FromJson<Response>();
            foreach (var player in response.elements)
            {
                player.now_cost /= 10.0;
                player.event_points = BuisnessLayer.player.setScoreByPrice(player.now_cost);
                db.players.Add(player);
            }
            db.SaveChanges();
        }
    }
    public static void deletePLayerFromUserTeam(string userName, string playerFirstName , string playerLastName)
    {
        using(var db=new Football_Fantasy.Program.Database())
        {
            foreach (var user in db.users)
            {
                if (user.userUserName == userName)
                {
                    foreach (var record in db.userPlayers )
                    {
                        if (user.userKey == record.userKey)
                        {
                            Player player = getPlayerByFirstNameAndLastName(playerFirstName, playerLastName);
                            if (record.playerId == player.playerKey)
                            {
                                user.money += player.now_cost;
                                db.userPlayers.Remove(record);
                                db.SaveChanges();
                            }
                        }
                    }
                }
                
            }
        }
    }

    
    public static List<Player> getAllPlayersOfDatabase()
    {
        List<Player> response = new List<Player>();
        using (var db = new Football_Fantasy.Program.Database())
        {
            foreach (var player in db.players)
            {
                response.Add(player);
            }

            return response;
        }
    }
    public static void addPlayerToUserTeam(string userName,string playerFirstName , string playerLastName)
    {
        using(var db=new Football_Fantasy.Program.Database())
        {
            foreach (var user in db.users)
            {
                if (user.userUserName == userName)
                {
                    foreach (var player in db.players)
                    {
                        if (player.first_name == playerFirstName && player.second_name == playerLastName) 
                        {
                            user.money -= player.now_cost;
                            UserPlayers userPlayer = new UserPlayers();
                            userPlayer.userKey = user.userKey;
                            userPlayer.player = player;
                            userPlayer.playerId = player.playerKey;
                            userPlayer.status = 0;
                            userPlayer.place = "";
                            db.userPlayers.Add(userPlayer);
                            db.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}