using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ch.cena.swiper.backend.data.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChallengeTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengeTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ExpiryDate = table.Column<DateTimeOffset>(nullable: true),
                    IssueDate = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MailAddress = table.Column<string>(maxLength: 62, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ChallengeTypeID = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Answers_ChallengeTypes_ChallengeTypeID",
                        column: x => x.ChallengeTypeID,
                        principalTable: "ChallengeTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ChallengeTypeID = table.Column<Guid>(nullable: false),
                    FileName = table.Column<string>(maxLength: 124, nullable: true),
                    ProjectID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Challenges_ChallengeTypes_ChallengeTypeID",
                        column: x => x.ChallengeTypeID,
                        principalTable: "ChallengeTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Challenges_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Annotations",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AnswerText = table.Column<string>(maxLength: 255, nullable: false),
                    ChallengeID = table.Column<Guid>(nullable: false),
                    Latitude = table.Column<float>(nullable: false),
                    LocalTime = table.Column<DateTimeOffset>(nullable: false),
                    Longitude = table.Column<float>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annotations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Annotations_Challenges_ChallengeID",
                        column: x => x.ChallengeID,
                        principalTable: "Challenges",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Annotations_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Annotations_ChallengeID",
                table: "Annotations",
                column: "ChallengeID");

            migrationBuilder.CreateIndex(
                name: "IX_Annotations_UserID",
                table: "Annotations",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_ChallengeTypeID",
                table: "Answers",
                column: "ChallengeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_ChallengeTypeID",
                table: "Challenges",
                column: "ChallengeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_ProjectID",
                table: "Challenges",
                column: "ProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Annotations");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Challenges");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ChallengeTypes");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
