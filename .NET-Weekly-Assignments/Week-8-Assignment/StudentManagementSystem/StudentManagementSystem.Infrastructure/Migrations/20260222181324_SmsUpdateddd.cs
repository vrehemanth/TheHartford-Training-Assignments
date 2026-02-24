using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SmsUpdateddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_StudentProfiles_StudentEntityId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_StudentEntityId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "StudentEntityId",
                table: "Feedbacks");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_MaterialId",
                table: "Feedbacks",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_StudentId",
                table: "Feedbacks",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_StudentProfiles_StudentId",
                table: "Feedbacks",
                column: "StudentId",
                principalTable: "StudentProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_StudyMaterials_MaterialId",
                table: "Feedbacks",
                column: "MaterialId",
                principalTable: "StudyMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_StudentProfiles_StudentId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_StudyMaterials_MaterialId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_MaterialId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_StudentId",
                table: "Feedbacks");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentEntityId",
                table: "Feedbacks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_StudentEntityId",
                table: "Feedbacks",
                column: "StudentEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_StudentProfiles_StudentEntityId",
                table: "Feedbacks",
                column: "StudentEntityId",
                principalTable: "StudentProfiles",
                principalColumn: "Id");
        }
    }
}
