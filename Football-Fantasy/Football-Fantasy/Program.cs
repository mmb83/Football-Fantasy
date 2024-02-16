using System;
using System.Runtime.InteropServices.JavaScript;
using SignUp;
using Football_Fantasy;
using Football_Fantasy.BuisnessLayer;
using Football_Fantasy.PresentationLayer;
using OTP;
using Admin = Football_Fantasy.PresentationLayer.Admin;
using Client = Football_Fantasy.PresentationLayer.Client;
using logIn = Football_Fantasy.PresentationLayer.logIn;
using Otp = Football_Fantasy.PresentationLayer.Otp;
using player = Football_Fantasy.PresentationLayer.player;
using signUpUser = Football_Fantasy.PresentationLayer.signUpUser;
using tablePaginations = Football_Fantasy.PresentationLayer.tablePaginations;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
            {
                var builder = WebApplication.CreateBuilder(args);
                builder.Services.AddCors(options =>
                {
                    options.AddDefaultPolicy(
                        builder =>
                        {
                            builder.WithOrigins("https://localhost:44351", "http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        });
                });
                var app = builder.Build();
                app.UseCors(builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
                app.MapGet("/ranking", async context =>
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "htmlFiles/UsersRanking.html");
                    var fileStream = await File.ReadAllTextAsync(filePath);
                    await context.Response.WriteAsync(fileStream);
                });
                app.MapGet("/AllPlayers", async context =>
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "htmlFiles/allPlayersTable.html");
                    var fileStream = await File.ReadAllTextAsync(filePath);
                    await context.Response.WriteAsync(fileStream);
                });
                app.MapGet("/formation", async context =>
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "htmlFiles/formation.html");
                    var fileStream = await File.ReadAllTextAsync(filePath);
                    await context.Response.WriteAsync(fileStream);
                });
                app.MapGet("/store", async context =>
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "htmlFiles/store.html");
                    var fileStream = await File.ReadAllTextAsync(filePath);
                    await context.Response.WriteAsync(fileStream);
                });
                app.MapGet("/dashbord", async context =>
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "htmlFiles/dashbord.html");
                    var fileStream = await File.ReadAllTextAsync(filePath);
                    await context.Response.WriteAsync(fileStream);
                });
                app.MapGet("/otp", async context =>
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "htmlFiles/otp.html");
                    var fileStream = await File.ReadAllTextAsync(filePath);
                    await context.Response.WriteAsync(fileStream);
                });
                app.MapGet("/contactUs", async context =>
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "htmlFiles/contactUs.html");
                    var fileStream = await File.ReadAllTextAsync(filePath);
                    await context.Response.WriteAsync(fileStream);
                });
                app.MapGet("/login", async context =>
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "htmlFiles/login.html");
                    var fileStream = await File.ReadAllTextAsync(filePath);
                    await context.Response.WriteAsync(fileStream);
                });
                app.MapGet("/signUp.css", async context =>
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "htmlFiles/signUp.css");
                    var fileStream = await File.ReadAllTextAsync(filePath);
                    await context.Response.WriteAsync(fileStream);
                });
                app.MapGet("/register", async context =>
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "htmlFiles/signUp.html");
                    var fileStream = await File.ReadAllTextAsync(filePath);
                    await context.Response.WriteAsync(fileStream);
                });
                app.MapGet("/", async context =>
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "htmlFiles/main.html");
                    var fileStream = await File.ReadAllTextAsync(filePath);
                    await context.Response.WriteAsync(fileStream);
                });
                app.MapGet("/user/rankingTable", Client.client.usersScoreTable);
                app.MapPost("/user/substitutionMainPlayers", player.substitutionMainPlayers);
                app.MapGet("/user/numberOfAllPlayres", Client.client.numberOfAllPlayers);
                app.MapGet("/user/profile", Client.client.getProfileOfUser);
                app.MapGet("/user/getUserMoney", Client.client.getUserMoney);
                app.MapGet("/user/getBackUpPlayersOfUser", player.getUserBackUpPlayers);
                app.MapGet("/user/getMainPlayersOfUser", player.getUserMainPlayers);
                app.MapGet("/user/getAllPlayerOfUser", player.getUserAllPlayers);
                app.MapGet("/user/paginationOfSortAndFilter", tablePaginations.numberOfPaginationsForSortAndFilter);
                app.MapGet("/user/sortAndFilterPlayers", player.sortAndFilterPlayers);
                app.MapGet("/user/paginationOfSearch", tablePaginations.numberOfPaginationsForSearch);
                app.MapGet("/user/paginationOfAllPlayers", tablePaginations.numberOfPaginationsForAllPlayers);
                app.MapGet("/user/filterPlayersByPosition", player.filterByPoition);
                app.MapGet("/user/sortdatabasePlayers", player.sortDatabasePayersByPriceOrPoint);
                app.MapPost("/user/autoSetUserPlayers", player.autoSetUserPlayers);
                app.MapGet("/user/search", player.searchPlayerByName);
                app.MapPost("/user/substitution", player.substitution);
                app.MapGet("/user/getAllplayers", player.getAllPlayers);
                app.MapPost("/admin/addMoneyToUser", Admin.addMoneyToUser);
                app.MapPost("/admin/addPlayers", player.addPlayersToDatabase);
                app.MapPost("/user/removePlayer", player.deletePLayerFromUserTeam);
                app.MapPost("/user/addPlayer", player.addPlayerToUserTeam);
                app.MapDelete("/clear/userAllPlayers", Admin.clearUserAllPlayers);
                app.MapDelete("/clear",PresentationLayer.clear);
                app.MapDelete("/admin/removeUser", Admin.removeUser);
                app.MapPost("/signUp/emailVerifying/didntSendOtp", Otp.userDidntSendOtp);
                app.MapPost("/signUp/emailVerifying/SendOtp", Otp.getOtp);
                app.MapPost("/signUp/emailVerifying", Football_Fantasy.BuisnessLayer.signUpUser.sendVerifyingEmail);
                app.MapPost("/signUp",signUpUser.addUser);
                app.MapPost("/profile/information", PresentationLayer.getAllUsersInfo);
                app.MapPost("/login/token", logIn.userLoginByToken);
                app.MapPost("/login/user", logIn.userLogin);
                app.Run("http://localhost:3001");
            }
        }
}



