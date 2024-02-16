using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;

namespace Football_Fantasy.PresentationLayer;
public class player
{
    static string[] teams =
    {
        "empty",
        "Arsenal",
        "Aston Villa",
        "Bournemouth",
        "Brentford",
        "Brighton",
        "Burnley",
        "Chelsea",
        "Crystal Palace",
        "Everton",
        "Fulham",
        "Liverpool",
        "Luton",
        "Man City",
        "Man Utd",
        "Newcastle",
        "Nott'm Forest",
        "Sheffield Utd",
        "Spurs",
        "West Ham",
        "Wolves",

    };
    static string[] positions =
    {
        "empty",
        "GoalKeeper",
        "Defender",
        "Midfielder",
        "Attacker"
    };

    public static List<Object> substitutionMainPlayers(string token , int firstId , int secondId)
    {
        string userName = JWT.decodeToken(token);
        List<Object> response = new List<object>();
        if(!BuisnessLayer.player.substitutionMainPlayers(userName,firstId,secondId))
        {
            response.Add(new
            {
                message="substitution process failed"
            });
        }
        else
        {
            response.Add(new
            {
                message="substitution process finished successfully"                
            });   
        }
        return response;
    }
    public static List<Object> autoSetUserPlayers(string token)
    {
        string userName = JWT.decodeToken(token);
        List<Object> response = new List<object>();
        if(!BuisnessLayer.player.autoSetUserPlayers(userName))
        {
            response.Add(new
            {
                message="auto set process failed"
            });
        }
        else
        {
            response.Add(new
            {
                message="auto set process finished successfully"                
            });   
        }
        return response;
    }
    public static List<Object> getUserBackUpPlayers(string token)
    {
        string userName = JWT.decodeToken(token);
        List<Player> players = BuisnessLayer.player.getBackUpPlayersOfUser(userName);
        List<Object> response = new List<object>();
        foreach (var player in players)
        {
            response.Add(new
            {
                firstname=player.first_name,
                lastname=player.second_name,
                position=positions[player.element_type],
                score=player.event_points,
            });
        }

        if (response.Count == 0)
        {
            response.Add(new
            {
                message="backUp players is empty"
            });
            return response;
        }

        return response;
    }
    public static List<Object> getUserMainPlayers(string token)
    {
        string userName = JWT.decodeToken(token);
        int i = 0;
        List<Player> players = BuisnessLayer.player.getMainPlayersOfUser(userName);
        List<string> places = BuisnessLayer.player.getPlaceOfUserPlayers(userName);
        List<Object> response = new List<object>();
        foreach (var player in players)
        {
            response.Add(new
            {
                firstname=player.first_name,
                lastname=player.second_name,
                id=player.playerKey,
                webname = player.web_name,
                place = places.ElementAt(i),
                position=player.element_type,
                team=player.team,
                score=player.event_points,
                price=player.now_cost
            });
            i++;
        }
        if (response.Count == 0)
        {
            response.Add(new
            {
                message="main players is empty"
            });
            return response;
        }

        return response;
    }
    public static List<Object> getUserAllPlayers(string token)
    {
        string userName = JWT.decodeToken(token);
        List<Player> players = BuisnessLayer.player.getUserAllPlayers(userName);
        List<Object> response = new List<object>();
        foreach (var player in players)
        {
            if (player != null)
            {
                response.Add(new
                {
                    firstname=player.first_name,
                    lastname = player.second_name,
                    position=positions[player.element_type],
                    team=teams[player.team],
                    score=player.event_points,
                    price=player.now_cost
                });
            }
        }
        if (response.Count == 0)
        {
            
            response.Add(new
            {
                first_name = "",
                last_name="",
                position = "",
                team = "",
                score = "",
                price="" 
            });
            
        }
        return response;
    }
    public static List<Object> sortAndFilterPlayers(int position, int sortType, int mode, int page)
    {
        List<Player> players = BuisnessLayer.player.SortAndFilterPlayers(position,sortType,mode,page);
        List<Object> response = new List<object>();
        foreach (var player in players)
        {
            response.Add(new
            {
                firstName=player.first_name,
                lastName=player.second_name,
                position=positions[player.element_type],
                team=teams[player.team],
                score=player.event_points,
                price=player.now_cost
            });
        }
        return response;
    }
    public static List<Object> filterByTeam(string team, int page)
    {
        List<Player> players = BuisnessLayer.player.filterByTeam(team, page);
        List<Object> response = new List<object>();
        if (players.Count == 0)
        {
            response.Add(new
            {
                
            });
            return response;
        } 
        foreach (var player in players)
        {
            response.Add(new
            {
                firstName=player.first_name,
                lastName=player.second_name,
                position=positions[player.element_type],
                team=teams[player.team],
                score=player.event_points,
                price=player.now_cost
            });
        }
        return response;
        
    }
    public static List<Object> filterByPoition(int position, int page)
    {
        List<Player> players = BuisnessLayer.player.filterByPoition(position ,page);
        List<Object> response = new List<object>();
        if (players.Count == 0)
        {
            response.Add(new
            {
                id="",
                firstName="",
                lastName="",
                position="",
                team="",
                score="",
                price=""
            });
            return response;
        }
        foreach (var player in players)
        {
            response.Add(new
            {
                firstName=player.first_name,
                lastName=player.second_name,
                position=positions[player.element_type],
                team=teams[player.team],
                score=player.event_points,
                price=player.now_cost
            });
        }
        return response;
    }
    public static List<Object> sortDatabasePayersByPriceOrPoint(int sortType ,int mode ,int page)
    {
        List<Player> players = BuisnessLayer.player.sortDatabasePayersByPriceOrPoint(sortType ,mode ,page);
        List<Object> response = new List<object>();
        foreach (var player in players)
        {
            response.Add(new
            {
                firstName=player.first_name,
                lastName=player.second_name,
                position=positions[player.element_type],
                team=teams[player.team],
                score=player.event_points,
                price=player.now_cost
            });
        }
        return response;
    }
    public static List<Object> searchPlayerByName(string webName , int page)
    {
        List<Player> players = BuisnessLayer.player.searchPlayerByName(webName,page);
        List<Object> response = new List<object>();
        if (BuisnessLayer.player.searchPlayerByName(webName,page).Count == 0)
        {
            response.Add(new
            {
                id="",
                webName="",
                firstName="",
                lastName="",
                position="",
                team="",
                score="",
                price=""
            });
            return response;
        }
        else
        {
            foreach (var player in players)
            {
                response.Add(new
                {
                    firstName=player.first_name,
                    lastName=player.second_name,
                    position=positions[player.element_type],
                    team=teams[player.team],
                    score=player.event_points,
                    price=player.now_cost
                });
            }

            return response;
        }
    }
    public static List<Object> substitution(string token, int idMain,string backUpFirstName, string backUpLastName)
    {
        string userName = JWT.decodeToken(token);
        List<Object> response = new List<object>();
        if (!BuisnessLayer.player.isExistInMain(userName, idMain))
        {
            response.Add(new
            {
                message = "Bazikone toye tarkib asli nistaaa!  yechi dige entekhab kon"
            });
            return response;
        }

        if (!BuisnessLayer.player.isExistInBackup(userName,backUpFirstName , backUpLastName))
        {
            response.Add(new
            {
                message = "bazikone toye nimkat nistaaa!  yechi dige entekhab kon"
            });
            return response;
        }

        if (!BuisnessLayer.player.isUserExist(userName))
        {
            response.Add(new
            {
                message = "usernamet eshetebe!!!"
            });
            return response;
        }
        if (BuisnessLayer.player.substitutedSuccessfully(userName, idMain,backUpFirstName,backUpLastName))
        {
            response.Add(new
            {
                message = "Revale, jashoon avaz shod."
            });
            return response;
        }
        return response;
    }

    public static List<Object> getAllPlayers(int page)
    {
        List<Object> response = new List<Object>();
        List<Player> players = new List<Player>();
        players = BuisnessLayer.player.getAllPlayers(page);
        foreach (var player in players)
        {
            response.Add(new
            {
                firstName=player.first_name,
                lastName=player.second_name,
                position=positions[player.element_type],
                team=teams[player.team],
                score=player.event_points,
                price=player.now_cost
            });
        }
        return response;
    }
    public static List<Object> addPlayersToDatabase()
    {
        List<Object> response = new List<object>();
        if (!BuisnessLayer.player.addPlayersToDatabase())
        {
            response.Add(new
            {
                message="Adding players to database process failed , try again"
            });
            return response;
        }
        response.Add(new
        {
            message="Players added to database successfully"
        });
        return response;
    }
    public static List<Object> deletePLayerFromUserTeam(string token,string playerFirstName , string playerLastName)
    {
        string userName = JWT.decodeToken(token);
        List<Object> response = new List<object>();
        
        if (!BuisnessLayer.player.isUserExist(userName))
        {
            response.Add(new
            {
                message="User not found"
            });
            return response;
        }
        if (!BuisnessLayer.player.isPlayerExistInDataBase(playerFirstName , playerLastName))
        {
            response.Add(new
            {
                message="Player not found!"
            });
            return response;
        }
        
        if (BuisnessLayer.player.deletePLayerFromUserTeam(userName, playerFirstName , playerLastName))
        {
            response.Add(new
            {
                message = "Player deleted successfully. Your players number is now less than 15. Please add new players."
            });
            return response;
        }
        response.Add(new
        {
            message="Player removing Process failed , try again "
        });
        return response;
    }
    public static List<Object> addPlayerToUserTeam(string token , string playerFirstName , string playerLastName ,int position)
    {
        string userName = JWT.decodeToken(token);
        List<Object> response = new List<object>();
        if (!BuisnessLayer.player.isValueOfPositionValid(position))
        {
            response.Add(new
            {
                message="We don't have player with this position!!"
            });
            return response;
        }
        if (!BuisnessLayer.player.isUserExist(userName))
        {
            response.Add(new
            {
                message="User not found"
            });
            return response;
        }
        if (!BuisnessLayer.player.isPlayerExistInDataBase(playerFirstName,playerLastName))
        {
            response.Add(new
            {
                message="Player not found!"
            });
            return response;
        }
        if (!BuisnessLayer.player.isPositionValid(playerFirstName,playerLastName, position))
        {
            response.Add(new
            {
                message="Player Position is wrong"
            });
            return response;
        }

        if (!BuisnessLayer.player.isMoneyEnough(userName, playerFirstName,playerLastName))
        {
            response.Add(new
            {
                message="Your money is not enough to buy this player"
            });
            return response;
        }
        if (BuisnessLayer.player.isPlayerExistInUserTeam(userName,playerFirstName,playerLastName))
        {
            response.Add(new
            { 
                message="Player is already in your team"
            });
            return response;
        }
        
        if (BuisnessLayer.player.isUserTeamHungry(userName))
        {
            response.Add(new
            {
                message="The maximum number of players is 15!"
            });
            return response;
        }
        if (!BuisnessLayer.player.isPlayerFirstCondition(userName, position))
        {
            response.Add(new
            {
                message="You can't add this player : The maximum player of this position is selected!!"
            });
            return response;
        }
        if (!BuisnessLayer.player.isPlayerSecondCondition(userName, playerFirstName,playerLastName))
        {
            response.Add(new
            {
                message="You can't add this player : The maximum player from team is selected!!"
            });
            return response;
        }
        if (BuisnessLayer.player.addPlayerToUserTeam(userName, playerFirstName,playerLastName))
        {
           response.Add(new
           {
               message="Player was added successfully"
           });
           return response;
        }
        response.Add(new
        {
            message="Player Adding Process failed , try again "
        });
        return response;
    }
}