namespace Football_Fantasy.BuisnessLayer;

public class logIn
{
    public static List<Object> userLoginByToken(string token)
    {
        List<Object> response = new List<object>();
        List<User> users = new List<User>();
        users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
        foreach (var user in users)
        {
            if (user.userUserName == decodeToken(token))
            {
                response.Add(new
                {
                    firstName=user.userFirstName,
                    lastName=user.userLastName,
                    userName=user.userUserName,
                });
            }
        }
        return response;
    }
    public static List<Object> userLogin(string userName, string password)
    {
        List<User> users = new List<User>();
        List<Object> response = new List<object>();
        users = DataAccessLayer.DataAccessLayer.getAllUsersOfDatabase();
        foreach (var user in users)
        {
            if (user.userUserName == userName)
            {
                if (user.userPassword == password)
                {
                    response.Add(new
                    {
                        Token=generateToken(userName)
                    });
                    return response;
                }
            }
        }
        return response;
    }
    public static string generateToken(string userName)
    {
        return JWT.generateToken(userName);
    }
    public static string decodeToken(string token)
    {
        return JWT.decodeToken(token);
    }
}