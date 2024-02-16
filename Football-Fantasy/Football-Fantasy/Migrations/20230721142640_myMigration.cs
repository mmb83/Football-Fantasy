using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Football_Fantasy.Migrations
{
    /// <inheritdoc />
    public partial class myMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientIsVerifying",
                columns: table => new
                {
                    helperKey = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    helperName = table.Column<string>(type: "TEXT", nullable: false),
                    helperLastName = table.Column<string>(type: "TEXT", nullable: false),
                    helperEmail = table.Column<string>(type: "TEXT", nullable: false),
                    helperUserName = table.Column<string>(type: "TEXT", nullable: false),
                    helperPassword = table.Column<string>(type: "TEXT", nullable: false),
                    verifyingTime = table.Column<int>(type: "INTEGER", nullable: false),
                    OTP = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientIsVerifying", x => x.helperKey);
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    playerKey = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    first_name = table.Column<string>(type: "TEXT", nullable: false),
                    second_name = table.Column<string>(type: "TEXT", nullable: false),
                    element_type = table.Column<int>(type: "INTEGER", nullable: false),
                    now_cost = table.Column<double>(type: "REAL", nullable: false),
                    team = table.Column<int>(type: "INTEGER", nullable: false),
                    event_points = table.Column<int>(type: "INTEGER", nullable: false),
                    web_name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.playerKey);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userKey = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    userFirstName = table.Column<string>(type: "TEXT", nullable: false),
                    userLastName = table.Column<string>(type: "TEXT", nullable: false),
                    userEmail = table.Column<string>(type: "TEXT", nullable: false),
                    userUserName = table.Column<string>(type: "TEXT", nullable: false),
                    userPassword = table.Column<string>(type: "TEXT", nullable: false),
                    money = table.Column<double>(type: "REAL", nullable: false),
                    score = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userKey);
                });

            migrationBuilder.CreateTable(
                name: "userPlayers",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    userKey = table.Column<int>(type: "INTEGER", nullable: false),
                    playerId = table.Column<int>(type: "INTEGER", nullable: false),
                    place = table.Column<string>(type: "TEXT", nullable: false),
                    status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userPlayers", x => x.id);
                    table.ForeignKey(
                        name: "FK_userPlayers_players_playerId",
                        column: x => x.playerId,
                        principalTable: "players",
                        principalColumn: "playerKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userPlayers_playerId",
                table: "userPlayers",
                column: "playerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clientIsVerifying");

            migrationBuilder.DropTable(
                name: "userPlayers");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "players");
        }
    }
}
