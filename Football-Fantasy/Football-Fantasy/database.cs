using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
#nullable enable
namespace Football_Fantasy 
{
    public class Program{
        public class Database : DbContext
        {
            public  DbSet<User>? users { get; set; }
            public DbSet<ClientIsVerifying>? clientIsVerifying { get; set; }
            public DbSet<Player>? players { get; set; }
            public DbSet<UserPlayers>? userPlayers { get; set; } 
            protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
            {
                contextOptionsBuilder.UseSqlite("Data source=database.db");
            }
        }
    }

    public class UserPlayers
    {
        [Key]
        public int id { get; set; }
        public int userKey { get; set; }
        public virtual Player player { get; set; }
        public int playerId { get; set; }
        public string place { get; set; }
        public int status { get; set; }
        
    }
    public class User
    {
        [Key]
        public int  userKey { get; set; }
        public string userFirstName { get; set; }
        public string userLastName {get;set;}
        public string userEmail { get; set; }
        public string userUserName { get; set; }
        public string userPassword { get; set; }
        
        public double money { get; set; }
        public int score { get; set; }
    }

    public class ClientIsVerifying
    {
        [Key]
        public int  helperKey { get; set; }
        public string helperName { get; set; }
        public string helperLastName {get;set;}
        public string helperEmail { get; set; }
        public string  helperUserName { get; set; }
        public string helperPassword { get; set; }
        public int verifyingTime { get; set; }
        public string OTP { get; set; }
    }
    public class Player
    {
        [Key]
        public int playerKey { get; set; }
        public string first_name { get; set; }
        public string second_name { get; set; }
        public int element_type { get; set; }
        public double now_cost { get; set; }
        public int team { get; set; }
        public int event_points{ get; set; }
        public string web_name { get; set; }
        }

    public class Response
    {
        public List<Player> elements { get; set; }
    }
    
}    