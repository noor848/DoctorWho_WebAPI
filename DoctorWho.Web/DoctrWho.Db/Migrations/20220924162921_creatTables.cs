using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctrWho.Db.Migrations
{
    public partial class creatTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanionEpisods",
                columns: table => new
                {
                    EpisodId = table.Column<int>(type: "int", nullable: false),
                    CompanionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanionEpisods", x => new { x.EpisodId, x.CompanionId });
                });

            migrationBuilder.CreateTable(
                name: "Companions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComapnionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhoPlayed = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorNumber = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstEpisodDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEpisodDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorViews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorViews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnemyEpisods",
                columns: table => new
                {
                    EpisodId = table.Column<int>(type: "int", nullable: false),
                    EnemyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnemyEpisods", x => new { x.EpisodId, x.EnemyId });
                });

            migrationBuilder.CreateTable(
                name: "Enemys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnemyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Episods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeriesNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EpisodNumber = table.Column<int>(type: "int", nullable: false),
                    EpisodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EpisodDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episods_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Episods_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanionEpisod",
                columns: table => new
                {
                    CompanionId = table.Column<int>(type: "int", nullable: false),
                    EpisodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanionEpisod", x => new { x.CompanionId, x.EpisodId });
                    table.ForeignKey(
                        name: "FK_CompanionEpisod_Companions_CompanionId",
                        column: x => x.CompanionId,
                        principalTable: "Companions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanionEpisod_Episods_EpisodId",
                        column: x => x.EpisodId,
                        principalTable: "Episods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnemyEpisod",
                columns: table => new
                {
                    EnemyId = table.Column<int>(type: "int", nullable: false),
                    EpisodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnemyEpisod", x => new { x.EnemyId, x.EpisodId });
                    table.ForeignKey(
                        name: "FK_EnemyEpisod_Enemys_EnemyId",
                        column: x => x.EnemyId,
                        principalTable: "Enemys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnemyEpisod_Episods_EpisodId",
                        column: x => x.EpisodId,
                        principalTable: "Episods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanionEpisod_EpisodId",
                table: "CompanionEpisod",
                column: "EpisodId");

            migrationBuilder.CreateIndex(
                name: "IX_EnemyEpisod_EpisodId",
                table: "EnemyEpisod",
                column: "EpisodId");

            migrationBuilder.CreateIndex(
                name: "IX_Episods_AuthorId",
                table: "Episods",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Episods_DoctorId",
                table: "Episods",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanionEpisod");

            migrationBuilder.DropTable(
                name: "CompanionEpisods");

            migrationBuilder.DropTable(
                name: "DoctorViews");

            migrationBuilder.DropTable(
                name: "EnemyEpisod");

            migrationBuilder.DropTable(
                name: "EnemyEpisods");

            migrationBuilder.DropTable(
                name: "Companions");

            migrationBuilder.DropTable(
                name: "Enemys");

            migrationBuilder.DropTable(
                name: "Episods");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
