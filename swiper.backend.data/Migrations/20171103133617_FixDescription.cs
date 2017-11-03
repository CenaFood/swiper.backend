using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ch.cena.swiper.backend.data.Migrations
{
    public partial class FixDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectDescription",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Payload",
                table: "Challenges");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Challenges",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Challenges");

            migrationBuilder.AddColumn<string>(
                name: "ProjectDescription",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Payload",
                table: "Challenges",
                nullable: true);
        }
    }
}
