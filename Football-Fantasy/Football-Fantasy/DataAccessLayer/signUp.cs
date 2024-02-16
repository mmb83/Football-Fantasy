namespace Football_Fantasy.DataAccessLayer;

public class signUp
{
    public static void addUser(User newUser)
    {
        using (var db = new Program.Database())
        {
            ClientIsVerifying userIsVerifying = new ClientIsVerifying();
            userIsVerifying.helperName = newUser.userFirstName;
            userIsVerifying.helperLastName = newUser.userLastName;
            userIsVerifying.helperEmail = newUser.userEmail;
            userIsVerifying.helperUserName = newUser.userUserName;
            userIsVerifying.helperPassword = newUser.userPassword;
            userIsVerifying.verifyingTime = DateTime.Now.Minute; ;
            userIsVerifying.OTP = BuisnessLayer.Otp.otpGenerator();
            db.clientIsVerifying.Add(userIsVerifying);
            db.SaveChanges();
            BuisnessLayer.signUpUser.sendVerifyingEmail(userIsVerifying.OTP, userIsVerifying.helperName,
                userIsVerifying.helperEmail);
        }
    }
}