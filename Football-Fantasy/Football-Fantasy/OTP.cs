using System;
using System.Net.Mail; 
namespace OTP;
public class OTP
{
    public static string otpGenerator()
    {
        Guid obj = Guid.NewGuid();
        string a = obj.ToString().Substring(0,2);
        int OTP = obj.GetHashCode();
        if (OTP <= 0)
        {
            OTP *= -1;
        }
        string result = OTP.ToString().Substring(0,4) + a;
        return result;    
    }
    public static void sendEmail(string Otp,string name,string email) 
    { 
        using (MailMessage mail = new MailMessage())
        {
            string message = $"Hi dear {name} \n  Welcome to the Football-Fantasy Please enter this code in the EmailVerifying page : \n ({Otp}) ";
            mail.From = new MailAddress("footballfantasy402@gmail.com"); 
            mail.To.Add(email); 
            mail.Subject = "Verify your email"; 
            mail.Body = message ; 
 
            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)) 
            { 
                smtp.Credentials = new System.Net.NetworkCredential("footballfantasy402@gmail.com", "rfrajytndkjjhcfx"); 
                smtp.EnableSsl = true; 
                smtp.Send(mail); 
            } 
        } 
    }
}