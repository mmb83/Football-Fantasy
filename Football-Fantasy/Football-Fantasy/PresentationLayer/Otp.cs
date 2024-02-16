namespace Football_Fantasy.PresentationLayer;

public class Otp
{
    public static List<Object> getOtp(string userName, string Otp)
    {
        List<Object> response = new List<object>();
        if (BuisnessLayer.Otp.getOtp(userName, Otp) == "OK")
        {
            response.Add(new
            {
                message="SignUp completed : please Login"
            });
            return response;
        }

        else if(BuisnessLayer.Otp.getOtp(userName, Otp) == "ex")
        {
            response.Add(new
            {
                message="SignUp failed : Code is expired"
            });
            return response;
        }
        else if(BuisnessLayer.Otp.getOtp(userName,Otp)=="W")
        {
            response.Add(new
            {
                message="SignUp failed : Code is wrong , try again"
            });
            return response;
        }
        else
        {
            response.Add(new
            {
                message="SignUp process failed : please signUp again"
            });
            return response;
        }
        
    }
    public static List<Object> userDidntSendOtp(string username)
    {
        List<Object> response = new List<object>();
        if (BuisnessLayer.Otp.userDidntSendOtp(username))
        {
            response.Add(new
            {
                message="The User who didn't send otp deleted from helper database"
            });
            return response;
        }
        response.Add(new
        {
            message="That user not found in helper database"
        });
        return response;
    }
}