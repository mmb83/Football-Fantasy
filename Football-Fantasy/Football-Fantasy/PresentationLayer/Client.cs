using System;
using System.Runtime.InteropServices.JavaScript;
using Football_Fantasy.BuisnessLayer;
namespace Football_Fantasy.PresentationLayer;

public class Client
{
    public class client
    {
        public static List<Object> numberOfAllPlayers(string token)
        {
            string userName = JWT.decodeToken(token);
            List<Object> response = new List<object>();
            int numberOfPlayers = BuisnessLayer.Client.client.numberOfAllPlayers(userName);
            response.Add(new
            {
                message = numberOfPlayers
            });
            return response;
        }
        public static List<Object> getProfileOfUser(string token)
        {
            string userName = JWT.decodeToken(token);
            List<Object> response = new List<object>();
            DataAccessLayer.Client.client.addScoreToUsers();
            User user = BuisnessLayer.Client.client.getProfileOfUser(userName);
            response.Add(new
            {
                firstname = user.userFirstName,
                lastname = user.userLastName,
                username = user.userUserName,
                money = user.money,
                score = user.score
            });
            return response;
        }
        public static List<Object> getUserMoney(string token)
        {
            string userName = JWT.decodeToken(token);
            double userMoney = BuisnessLayer.Client.client.getUserMoney(userName);
            List<Object> response = new List<object>();
            if (userMoney == -1)
            {
                response.Add(new
                {
                    message = "User not found!"
                });
                return response;
            }
            else
            {
                response.Add(new
                {
                    message = userMoney
                });
                return response;
            }
        }
        public static List<Object> calculateScore(string token)
        {
            string userName = JWT.decodeToken(token);
            DataAccessLayer.Client.client.addScoreToUsers();
            int userScore = 0;
            userScore = BuisnessLayer.Client.client.calculateScore(userName);
            List <Object> response = new List<Object>();
            List<User> users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
            foreach (var user in users)
            {
                if (user.userUserName == userName)
                {
                    response.Add(new
                    {
                        firstName = user.userFirstName,
                        lastName = user.userLastName,
                        userName = user.userUserName,
                        money = user.money,
                        score = userScore
                    });
                    return response;
                }
            }
            return response;
        }

        public static List<Object> usersScoreTable(int page)
        {
            int userRank=1;
            List<User> users = BuisnessLayer.Client.client.usersScoreTable(page);
            List<object> response = new List<object>();
            foreach (var user in users )
            {
                response.Add(new
                {
                    rank = userRank++,
                    firstName = user.userFirstName,
                    lastName = user.userLastName,
                    userName = user.userUserName,
                    Score = user.score

                });
            }

            return response;
        }
    }
}