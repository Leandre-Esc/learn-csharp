using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnCSharp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTimestamps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "users",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "users",
                newName: "first_name");

            migrationBuilder.RenameIndex(
                name: "IX_users_Username",
                table: "users",
                newName: "ix_users_username");

            migrationBuilder.RenameIndex(
                name: "IX_users_Email",
                table: "users",
                newName: "ix_users_email");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                table: "users",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                table: "users");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "users");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "users",
                newName: "FirstName");

            migrationBuilder.RenameIndex(
                name: "ix_users_username",
                table: "users",
                newName: "IX_users_Username");

            migrationBuilder.RenameIndex(
                name: "ix_users_email",
                table: "users",
                newName: "IX_users_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");
        }
    }
}
