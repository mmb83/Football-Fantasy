namespace Football_Fantasy.BuisnessLayer;

public class player
{
    static string[] teams =
    {
        "empty",
        "Arsenal",
        "Aston_Villa",
        "Bournemouth",
        "Brentford",
        "Brighton",
        "Chelsea",
        "Crystal_Palace",
        "Everton",
        "Fulham",
        "Leicester",
        "Leeds",
        "Liverpool",
        "Man_City",
        "Man_Utd",
        "Newcastle",
        "Nottm Forest",
        "Southampton",
        "Spurs",
        "West_Ham",
        "Wolves"
    };

    static string[] positions =
    {
        "empty",
        "GoalKeeper",
        "Defencer",
        "Midfielder",
        "Attacker"
    };

    public static bool isPlayersHavePlace(string userName)
    {
        List<User> users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
        List<string> placesOfUserPlayers = new List<string>();
        foreach (var user in users)
        {
            if (user.userUserName == userName)
            {
                placesOfUserPlayers = DataAccessLayer.player.getPlaceOfUserPlayers(user.userKey);
            }
        }
        foreach (var record in placesOfUserPlayers)
        {
            if (record != "")
            {
                return true;
            }
        }
        return false;
    }
    public static int setScoreByPrice(double price)
    {
        int score = 0;
        Random rnd = new Random();
        int num = rnd.Next();
        if (price >= 12)
        {
            if (num % 3 == 0)
            {
                score = (int)((price * 6) + 10) / 4;
            }
            else if (num % 3 == 1)
            {
                score = (int)((price * 5) + 7) / 4;
            }
            else
            {
                score = (int)((price * 4.5) + 10) / 3;
            }
        }
        else if (price >= 10)
        {
            if (num % 3 == 0)
            {
                score = (int)((price * 6) + 6) / 4;
            }
            else if (num % 3 == 1)
            {
                score = (int)((price * 5) + 3) / 4;
            }
            else
            {
                score = (int)((price * 4.5) + 1) / 3;
            }
        }
        else if (price >= 7)
        {
            if (num % 3 == 0)
            {
                score = (int)((price * 5.5) + 10) / 4;
            }
            else if (num % 3 == 1)
            {
                score = (int)((price * 5) + 7) / 4;
            }
            else
            {
                score = (int)((price * 4.5) + 10) / 4;
            }
        }
        else
        {
            if (num % 4 == 0)
            {
                score = (int)((price * 6) + 10) / 4;
            }
            else if (num % 4 == 1)
            {
                score = (int)((price * 4) + 7) / 4;
            }
            else if (num % 4 == 2)
            {
                score = (int)((price * 4.5) + 7) / 5;
            }
            else if (num % 3 == 0)
            {
                score = (int)((price * 6) + 3) / 4;
            }
            else if (num % 3 == 1)
            {
                score = (int)((price * 4.5) + 7) / 4;
            }
            else if (num % 3 == 2)
            {
                score = 0;
            }
        }

        return score;
    }

    public static bool substitutionMainPlayers(string userName, int firstId, int secondId)
    {
        List<User> users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
        if (true)
        {
            foreach (var user in users)
            {
                if (user.userUserName == userName)
                {
                    DataAccessLayer.player.substitutionMainPlayers(user.userKey, firstId, secondId);
                    return true;
                }
            }
        }

        return false;
    }

    public static List<string> getPlaceOfUserPlayers(string userName)
    {
        List<string> places = new List<string>();
        List<User> users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
        foreach (var user in users)
        {
            if (user.userUserName == userName)
            {
                places = DataAccessLayer.player.getPlaceOfUserPlayers(user.userKey);
            }
        }

        return places;
    }

    public static bool autoSetUserPlayers(string userName)
    {
        if(!isPlayersHavePlace(userName)){
            string[] places = { "p1" , "p2" , "p3" , "p4" ,"p5" , "p6" ,"p7" , "p8","p9" , "p10" , "p11"};
            int place = 0 , userKey = 0;
            int[] maxCapacityOfMain = { 0, 1, 4, 3, 3 };
            List<User> users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
            foreach (var user in users)
            {
                if (user.userUserName == userName)
                {
                    userKey = user.userKey;
                }
            }
            for (int i = 1; i < 5; i++)
            {
                List<Player> filteredPlayers = DataAccessLayer.player.getSortPlayersOfUserByPosition(userKey, i);
           
                for (int j = 0; j < filteredPlayers.Count; j++)
                {
                    if ((j + 1) <= maxCapacityOfMain[i])
                    {
                        DataAccessLayer.player.addPlayerToMainOfUser(userKey, filteredPlayers.ElementAt(j),places[place]);
                        place++;
                    }
                    else{
                        DataAccessLayer.player.addPlayerToBackUpOfUser(userKey, filteredPlayers.ElementAt(j));
                    } 
                } 
            }
        }
        return true;
    }
    
    public static List<Player> getBackUpPlayersOfUser(string userName)
    {
        List<User> users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
        List<Player> players = new List<Player>();
        foreach (var user in users)
        {
            if (user.userUserName == userName)
            {
                players = DataAccessLayer.player.getBackUpPlayersOfUser(user.userKey);
            }
        }
        return players;
    }
    public static List<Player> getMainPlayersOfUser(string userName)
    {
        List<User> users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
        List<Player> players = new List<Player>();
        foreach (var user in users)
        {
            if (user.userUserName == userName)
            {
                players = DataAccessLayer.player.getMainPlayersOfUser(user.userKey);
            }
        }

        return players;
    }
    public static List<Player> getUserAllPlayers(string userName)
    {
        List<User> users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
        List<Player> response = new List<Player>();
        foreach (var user in users )
        {
            if (user.userUserName == userName)
            {
                List<Player> players = DataAccessLayer.player.getAllPlayerOfUser(user.userKey);
                if(players?.Any() ?? false)
                {
                    foreach (var player in players)
                    {
                        response.Add(player);
                    }

                    return response;
                }
                else
                {
                    foreach(Player? player in players?? Enumerable.Empty<Player>() )
                    {
                        response.Add(player);
                    }
                    
                    return response;
                }
            }
        }
        return response;
    }
    public static List<Player> SortAndFilterPlayers(int position, int sortType, int mode, int page)
    {
        List<Player> response = new List<Player>();
        List<Player> players = DataAccessLayer.player.getAllPlayersOfDatabase();
        List<Player> sortedAndFilteredPlayers = new List<Player>();
        if (sortType == 1)
        {
            List<Player> sortedPlayersByPrice = players.OrderBy(o => o.now_cost).ToList();
            if (mode == 1)
            { 
                sortedPlayersByPrice.Reverse();
            }
            if (position <= 4)
            {
                foreach (var player in sortedPlayersByPrice )
                {
                    if (player.element_type == position)
                    {
                        sortedAndFilteredPlayers.Add(player);
                    }
                }
            }
            else
            {
                foreach (var player in sortedPlayersByPrice )
                {
                    if (player.team == (position-4))
                    {
                        sortedAndFilteredPlayers.Add(player);
                    }
                }
            }
            int start = 0, end = 20;
            if (page != 1)
            {
                start = (page - 1) * 20 ;
                end += start ;
                if (end > sortedAndFilteredPlayers.Count)
                {
                    end =sortedAndFilteredPlayers.Count;
                }
            }
            for (int i = start; i < end; i++)
            {
                response.Add(sortedAndFilteredPlayers.ElementAt(i));
            }
            return response;
        }
        List<Player> sortedPlayersByScore = players.OrderBy(o => o.event_points).ToList();
        if (mode == 1)
        {
            sortedPlayersByScore.Reverse();
        }
        foreach (var player in sortedPlayersByScore)
        {
            if (player.element_type == position)
            {
                sortedAndFilteredPlayers.Add(player);
            }
        }
        int start1 = 0, end1 = 20;
        if (page != 1)
        {
            start1 = (page - 1) * 20 ;
            end1 += start1 ;
            if (end1 > sortedAndFilteredPlayers.Count)
            {
                end1 =sortedAndFilteredPlayers.Count;
            }
        }
        for (int i = start1; i < end1; i++)
        {
            response.Add(sortedAndFilteredPlayers.ElementAt(i));
        }
        return response;
    }
    public static List<Player> filterByTeam(string team, int page)
    {
        List<Player> response = new List<Player>();
        List<Player> players = DataAccessLayer.player.getAllPlayersOfDatabase();
        List<Player> filteredPalyers = new List<Player>();
        foreach (var player in players)
        {
            if (teams[player.team] == team)
            {
                filteredPalyers.Add(player);
            }
        }
        int start = 0, end = 20;
        if (page != 1)
        {
            start = (page - 1) * 20 ;
            end += start ;
            if (end > filteredPalyers.Count)
            {
                end =filteredPalyers.Count;
            }
        }
        for (int i = start; i < end; i++)
        {
            response.Add(filteredPalyers.ElementAt(i));
        }
        return response;
    }
    public static List<Player> filterByPoition(int position, int page)
    {
        List<Player> response = new List<Player>();
        List<Player> players = DataAccessLayer.player.getAllPlayersOfDatabase();
        List<Player> filteredPalyers = new List<Player>();
        
        foreach (var player in players)
        {
            if (player.element_type == position)
            {
                filteredPalyers.Add(player);
            }
        }
        int start = 0, end = 20;
        if (page != 1)
        {
            start = (page - 1) * 20 ;
            end += start ;
            if (end > filteredPalyers.Count)
            {
                end =filteredPalyers.Count;
            }
        }
        for (int i = start; i < end; i++)
        {
            response.Add(filteredPalyers.ElementAt(i));
        }
        return response;

    }
    public static List<Player> sortDatabasePayersByPriceOrPoint(int sortType ,int mode, int page)
    {
        List<Player> response = new List<Player>();
        List<Player> players = DataAccessLayer.player.getAllPlayersOfDatabase();
        if (sortType == 1)
        {
            List<Player> sortedPlayersByPrice = players.OrderBy(o => o.now_cost).ToList();
            if (mode == 1)
            { 
                sortedPlayersByPrice.Reverse();
            }
            int start = 0, end = 20;
            if (page != 1)
            {
                start = (page - 1) * 20 ;
                end += start ;
                if (end > sortedPlayersByPrice.Count)
                {
                    end = sortedPlayersByPrice.Count;
                }
            }
            for (int i = start; i < end; i++)
            {
                response.Add(sortedPlayersByPrice.ElementAt(i));
            }
            return response;
        }
        List<Player> sortedPlayersByScore = players.OrderBy(o => o.event_points).ToList();
        if (mode == 1)
        {
            sortedPlayersByScore.Reverse();
        }
        //sortedPlayersByScore.Reverse();
        int start1 = 0, end1 = 20;
        if (page != 1)
        {
            start1 = (page - 1) * 20 ;
            end1 += start1 ;
            if (end1 > sortedPlayersByScore.Count)
            {
                end1 = sortedPlayersByScore.Count;
            }
        }
        for (int i = start1; i < end1; i++)
        {
            response.Add(sortedPlayersByScore.ElementAt(i));
        }
        return response;
        
    }

    public static List<Player> searchPlayerByName(string webName,int page)
    {
        List<Player> response = new List<Player>();
        List<Player> players = new List<Player>();
        List<Player> searchedPlayers = new List<Player>();
        players = DataAccessLayer.player.getAllPlayersOfDatabase();
        StringComparison comp = StringComparison.OrdinalIgnoreCase;
        foreach (var player in players)
        {
            if (player.web_name.Contains(webName, comp))
            {
                searchedPlayers.Add(player);
            }
        }
        if (searchedPlayers.Count > 0)
        {
            int start = 0, end = 20;
            if (page != 1)
            {
                start = (page - 1) * 20 ;
                end += start ;
                if (end > searchedPlayers.Count)
                {
                    end = searchedPlayers.Count;
                }
            }
            if (end > searchedPlayers.Count)
            {
                end = searchedPlayers.Count;
            }
            for (int i = start; i < end; i++)
            {
                response.Add(searchedPlayers.ElementAt(i));
            }
            return response;
        }
        int[] wordPoints = new int[players.Count];
        for (int j = 0; j < players.Count; j++)
        {
            for (int i = 0; i < players[j].web_name.Length && i < webName.Length ; i++)
            {
                if (players[j].web_name[i] == webName[i])
                {
                    wordPoints[j]++;
                }
            }
        }
        int maxValue = wordPoints.Max();
        if (maxValue == 0)
        {
            return response;
        }
        int indexOfMax = Array.IndexOf(wordPoints, maxValue);
        searchedPlayers.Add(players[indexOfMax]);
        int start1 = 0, end1 = 20;
        if (page != 1)
        {
            start1 = (page - 1) * 20 ;
            end1 += start1 ;
            if (end1 > searchedPlayers.Count)
            {
                end1 = searchedPlayers.Count;
            }
        }
        for (int i = start1; i < end1; i++)
        {
            response.Add(searchedPlayers.ElementAt(i));
        }
        return response;
    }

    public static bool substitutedSuccessfully(string userName, int idMain, string backUpFirstName , string backUpLastName )
    {
        if (true)
        {
            DataAccessLayer.player.substitution(userName,idMain,backUpFirstName,backUpLastName);
            return true;
        }
        return false;
    }

    public static bool isExistInBackup(string userName,string backUpFirstName , string backUpLastName)
    {
        List<User> users = new List<User>();
        users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
        foreach (var user in users)
        {
            if (user.userUserName == userName)
            {
                List<Player> players = DataAccessLayer.player.getBackUpPlayersOfUser(user.userKey);
                foreach (var player in players)
                {
                   if (player.first_name == backUpFirstName && player.second_name == backUpLastName)
                   {
                        return true;
                   }
                }
                return false;
            }
        }

        return false;
    }

    public static bool isExistInMain(string userName, int mainPlayerKey)
    {
        List<User> users = new List<User>();
        users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
        foreach (var user in users)
        {
            if (user.userUserName == userName)
            {
                List<Player> players = DataAccessLayer.player.getMainPlayersOfUser(user.userKey);
               foreach (var player in players)
                {
                    if (player.playerKey == mainPlayerKey)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        return false;
    }

    public static List<Player> getAllPlayers(int page)
    {
        List<Player> response = new List<Player>();
        List<Player> players = new List<Player>();
        players = DataAccessLayer.player.getAllPlayersOfDatabase();
        int start = 0, end = 20;
        if (page != 1)
        {
            start = (page - 1) * 20 ;
            end += start ;
            if (end > players.Count)
            {
                end = players.Count;
            }
        }
        for (int i = start; i < end; i++)
        {
            response.Add(players.ElementAt(i));
        }
        return response;
    }
    public static bool addPlayersToDatabase()
    {
        if (true)
        {
            DataAccessLayer.player.addPlayersToDatabase();
            return true;
        }
        return false;
    }
    public static bool deletePLayerFromUserTeam(string userName, string playerFirstName ,string playerLastName)
    {
        if (true)
        {
            DataAccessLayer.player.deletePLayerFromUserTeam(userName,playerFirstName,playerLastName);
            return true;
        }
        return false;
    }
    
     public static bool isPlayerSecondCondition(string userName, string playerFirstName , string playerLastName)
     { 
            if (numberOfPlayersChosenFromOneTeam(userName, playerFirstName,playerLastName)>=3)
            {
                return false;
            }

            return true;
    }
    public static bool isValueOfPositionValid(int position)
    {
        if (position >= 1 && position <= 4)
        {
            return true;
        }
        return false;
    }
    public static bool isPlayerFirstCondition(string userName,int position)
    {
        int numberOfPlayers = 0;
        numberOfPlayers = numberOfPlayersByPosition(userName,position);
        int[] capacityOfPosition = { 2, 5, 5, 3 };
        for (int i = 0; i <= 3; i++)
        {
            if (i + 1 == position)
            {
                if (numberOfPlayersByPosition(userName,position) >= capacityOfPosition[i])
                {
                    return false;
                }
                return true;
            }
        }
        return false;
    }
    public static bool isUserTeamHungry(string userName)
    {
        List<User> users = new List<User>();
        users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
        foreach (var user in users )
        {
            if (user.userUserName == userName)
            {
                List<Player> players = DataAccessLayer.player.getAllPlayerOfUser(user.userKey);
                if(players?.Any() ?? false){
                    if (players.Count >= 15)
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }
        return false;
    }
    public static bool isPlayerExistInUserTeam(string userName,string playerFirstName, string playerLastName)
    {
        
        List<User> users = new List<User>();
        users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
        foreach (var user in users)
        {
            if (user.userUserName == userName)
            {
                List<Player> players = DataAccessLayer.player.getAllPlayerOfUser(user.userKey);
                foreach(var player in players)
                {
                    if (player == null)
                    {
                            return false;
                    }
                    else
                    {
                        if (player.first_name == playerFirstName && player.second_name == playerLastName)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
        return false;
    }
    public static bool isMoneyEnough(string userName, string playerFirstName , string playerLastName)
    {
        List<User> users = new List<User>();
        List<Player> players = new List<Player>();
        users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
        players = DataAccessLayer.player.getAllPlayersOfDatabase();
        foreach (var user in users) 
        {
            if (user.userUserName == userName)
            {
                foreach (var player in players)
                {
                    if (player.first_name == playerFirstName && player.second_name == playerLastName) 
                    {
                        if (user.money >= player.now_cost)
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
        }
        return false;
    }
    public static bool isUserExist(string userName)
    {
        List<User> users = new List<User>();
        users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
        foreach (var user in users)
        {
            if (user.userUserName == userName)
            {
                return true;
            }
        }
        return false;
    }
    public static bool isPlayerExistInDataBase(string playerFirstName , string playerLastName)
    {
        List<Player> players = DataAccessLayer.player.getAllPlayersOfDatabase();
        foreach (var player in players)
        {
            if (player.first_name == playerFirstName && player.second_name == playerLastName) 
            {
                return true;
            }
        }
        return false;
    }
    public static bool isPositionValid(string playerFirstName , string playerLastName , int position)
    {
        List<Player> players = new List<Player>();
        players = DataAccessLayer.player.getAllPlayersOfDatabase();
        foreach (var player in players )
        {
            if (player.first_name == playerFirstName && player.second_name == playerLastName)
            {
                if (player.element_type == position)
                {
                    return true;
                }

                return false;
            }
        }

        return false;
    }
    public static bool addPlayerToUserTeam(string userName,string playerFirstName , string playerLastName)
    {
        if (true)
        {
            DataAccessLayer.player.addPlayerToUserTeam(userName, playerFirstName,playerLastName);
            return true;
        }

        return false;
    }

    public static int numberOfPlayersByPosition(string userName, int position)
    {
        int numberOfPlayers = 0;
        List<User> users = new List<User>();
        users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
        foreach (var user in users)
        {
            if (user.userUserName == userName)
            { 
                List<Player> players = DataAccessLayer.player.getAllPlayerOfUser(user.userKey);
               foreach (var player in players )
                {
                    if (player != null)
                    {
                        if (player.element_type == position)
                        {
                            numberOfPlayers++;
                        }
                    }
                }
                return numberOfPlayers;
            }
        }
        return numberOfPlayers;
    }

    public static int numberOfPlayersChosenFromOneTeam(string userName, string playerFirstName , string playerLastName)
    {
        int teamOfPlayer = 0;
        int numberOfPlayers = 0;
        List<User> users = new List<User>();
        users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
        foreach (var user in users )
        {
            if (user.userUserName == userName)
            {
                List<Player> players = DataAccessLayer.player.getAllPlayerOfUser(user.userKey);
               foreach(var player in players)
                {
                    if (player != null)
                    {
                        if (player.first_name == playerFirstName && player.second_name == playerLastName)
                        {
                            teamOfPlayer = player.team;
                            break;
                        }
                    }
                }
                foreach(var player in players)
                {
                    if (player != null)
                    {
                        if (player.team == teamOfPlayer)
                        {
                            numberOfPlayers++;
                        }
                    }
                }
                return numberOfPlayers;
            }
        }
        
        return numberOfPlayers;
    }
}