namespace Football_Fantasy.BuisnessLayer;
public class Otp
{
    public static string getOtp(string userName, string Otp)
    {
        List<ClientIsVerifying> users = new List<ClientIsVerifying>();
        users = DataAccessLayer.Otp.getHelperDatabase();
        foreach (var user in users)
        {
            if (user.helperUserName == userName)
            {
                int result = DateTime.Now.Minute;
                int expireTime = 2;
                if ((result - user.verifyingTime) >= expireTime)
                {
                    DataAccessLayer.Otp.removeUserFromHelperDatabase(userName);
                    return "ex";
                }
                else if (user.OTP == Otp)
                {
                    DataAccessLayer.Otp.addUserFromHelperDataBaseToMainDatabase(userName);
                    return "OK";
                }
                else
                {
                    return "W";
                }
            }
        }
        return "-1";
    }
    public static string otpGenerator()
    {
        return OTP.OTP.otpGenerator();
    }
    public static bool userDidntSendOtp(string userName)
    {
        if (true)
        {
            DataAccessLayer.Otp.removeUserFromHelperDatabase(userName);
            return true;
        }
        return false;
    }
   
}