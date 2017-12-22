using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ch.cena.swiper.backend.data.Migrations
{
    public partial class RenamingPayload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Annotations_Answers_AnswerID",
                table: "Annotations");

            migrationBuilder.DropColumn(
                name: "Payload",
                table: "Annotations");

            migrationBuilder.AlterColumn<Guid>(
                name: "AnswerID",
                table: "Annotations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Annotations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Annotations_Answers_AnswerID",
                table: "Annotations",
                column: "AnswerID",
                principalTable: "Answers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Annotations_Answers_AnswerID",
                table: "Annotations");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Annotations");

            migrationBuilder.AlterColumn<Guid>(
                name: "AnswerID",
                table: "Annotations",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Payload",
                table: "Annotations",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Annotations_Answers_AnswerID",
                table: "Annotations",
                column: "AnswerID",
                principalTable: "Answers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
