using LMS.Domain.Entities;
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTransactionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_AspNetUsers_UserId",
                table: "Transaction");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Transaction",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Transaction",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "IssuedByUserId",
                table: "Transaction",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDate",
                table: "Transaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ReturnNotes",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReturnedByUserId",
                table: "Transaction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_IssuedByUserId",
                table: "Transaction",
                column: "IssuedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ReturnedByUserId",
                table: "Transaction",
                column: "ReturnedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_AspNetUsers_IssuedByUserId",
                table: "Transaction",
                column: "IssuedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_AspNetUsers_ReturnedByUserId",
                table: "Transaction",
                column: "ReturnedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_AspNetUsers_UserId",
                table: "Transaction",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_AspNetUsers_IssuedByUserId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_AspNetUsers_ReturnedByUserId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_AspNetUsers_UserId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_IssuedByUserId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_ReturnedByUserId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "IssuedByUserId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "RequestDate",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "ReturnNotes",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "ReturnedByUserId",
                table: "Transaction");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Transaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Transaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_AspNetUsers_UserId",
                table: "Transaction",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
