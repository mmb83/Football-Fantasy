namespace Football_Fantasy.PresentationLayer;

public class logIn
{
    public static List<Object> userLoginByToken(string token)
    {
        List<Object> response = new List<object>();
        if (BuisnessLayer.logIn.userLoginByToken(token).Count == 0)
        {
            response.Add(new
            {
                message="Token is invalid"
            });
            return response;
        }
        return BuisnessLayer.logIn.userLoginByToken(token);
    }
    public static List<Object> userLogin(string userName, string password)
    {
        List<Object> response = new List<object>();
        if (BuisnessLayer.logIn.userLogin(userName,password).Count == 0)
        {
            response.Add(new
            {
                message="username or password is wrong"
            });
            return response;
        }
        return BuisnessLayer.logIn.userLogin(userName, password);
    }
}