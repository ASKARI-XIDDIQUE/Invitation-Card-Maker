using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvitationCardMaker.Migrations
{
    /// <inheritdoc />
    public partial class forgotpass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResetPasswordOtp",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResetPasswordOtpExpiryTime",
                table: "User",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResetPasswordOtp",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ResetPasswordOtpExpiryTime",
                table: "User");
        }
    }
}
