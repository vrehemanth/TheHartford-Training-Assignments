using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeMaterialOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_StudyMaterials_MaterialId",
                table: "Feedbacks");

            migrationBuilder.AlterColumn<Guid>(
                name: "MaterialId",
                table: "Feedbacks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_StudyMaterials_MaterialId",
                table: "Feedbacks",
                column: "MaterialId",
                principalTable: "StudyMaterials",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_StudyMaterials_MaterialId",
                table: "Feedbacks");

            migrationBuilder.AlterColumn<Guid>(
                name: "MaterialId",
                table: "Feedbacks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_StudyMaterials_MaterialId",
                table: "Feedbacks",
                column: "MaterialId",
                principalTable: "StudyMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
