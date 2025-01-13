using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 

namespace InvitationCardMaker.Migrations
{
    /// <inheritdoc />
    public partial class updatingTemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "GlobalId",
                keyValue: new Guid("1b08dd0e-a4d3-47c2-99ce-d5f0d5099573"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "GlobalId",
                keyValue: new Guid("cf2950be-55e0-48ce-86fd-f5bb7d5232e2"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "GlobalId",
                keyValue: new Guid("0c247561-d0c8-4d1f-9ed2-6dabd47a513d"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "GlobalId",
                keyValue: new Guid("6f2b946f-bba8-45e6-9ad7-d201f09c8587"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "GlobalId",
                keyValue: new Guid("a27b7bb7-97c1-4c6a-97b9-3b07c5abb9b9"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "GlobalId",
                keyValue: new Guid("bb7b2bcc-15b2-4f17-85db-f7b5d64e78eb"));

            migrationBuilder.AddColumn<string>(
                name: "ContentStyles",
                table: "Template",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionStyles",
                table: "Template",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleStyles",
                table: "Template",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TopContent",
                table: "Template",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TopDescription",
                table: "Template",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TopTitle",
                table: "Template",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "GlobalId", "Active", "CreatedAt", "DeletedAt", "RoleName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("9cf031bf-709a-4fbd-9209-c603fe25555b"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cc4fc6c8-63d1-40bc-b8fc-bf0c87fb0fa9"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "GlobalId", "Active", "CreatedAt", "DeletedAt", "Email", "Password", "RefreshToken", "RefreshTokenExpiryTime", "ResetPasswordOtp", "ResetPasswordOtpExpiryTime", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("547af502-da3f-47a8-a6f9-72ea40f45100"), true, new DateTime(2024, 6, 28, 11, 5, 26, 829, DateTimeKind.Utc).AddTicks(9189), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@example.com", "user123", null, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user" },
                    { new Guid("cf5d5744-ab9e-45a0-bd93-03eea6056c15"), true, new DateTime(2024, 6, 28, 11, 5, 26, 829, DateTimeKind.Utc).AddTicks(9184), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "admin123", null, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "GlobalId", "Active", "CreatedAt", "DeletedAt", "RoleId", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("d660cd45-965a-48df-ba36-658dbc7dafdb"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9cf031bf-709a-4fbd-9209-c603fe25555b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("547af502-da3f-47a8-a6f9-72ea40f45100") },
                    { new Guid("e5ce8310-5d4b-4b6b-b735-071ca188b754"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cc4fc6c8-63d1-40bc-b8fc-bf0c87fb0fa9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cf5d5744-ab9e-45a0-bd93-03eea6056c15") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "GlobalId",
                keyValue: new Guid("d660cd45-965a-48df-ba36-658dbc7dafdb"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "GlobalId",
                keyValue: new Guid("e5ce8310-5d4b-4b6b-b735-071ca188b754"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "GlobalId",
                keyValue: new Guid("9cf031bf-709a-4fbd-9209-c603fe25555b"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "GlobalId",
                keyValue: new Guid("cc4fc6c8-63d1-40bc-b8fc-bf0c87fb0fa9"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "GlobalId",
                keyValue: new Guid("547af502-da3f-47a8-a6f9-72ea40f45100"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "GlobalId",
                keyValue: new Guid("cf5d5744-ab9e-45a0-bd93-03eea6056c15"));

            migrationBuilder.DropColumn(
                name: "ContentStyles",
                table: "Template");

            migrationBuilder.DropColumn(
                name: "DescriptionStyles",
                table: "Template");

            migrationBuilder.DropColumn(
                name: "TitleStyles",
                table: "Template");

            migrationBuilder.DropColumn(
                name: "TopContent",
                table: "Template");

            migrationBuilder.DropColumn(
                name: "TopDescription",
                table: "Template");

            migrationBuilder.DropColumn(
                name: "TopTitle",
                table: "Template");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "GlobalId", "Active", "CreatedAt", "DeletedAt", "RoleName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0c247561-d0c8-4d1f-9ed2-6dabd47a513d"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6f2b946f-bba8-45e6-9ad7-d201f09c8587"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "GlobalId", "Active", "CreatedAt", "DeletedAt", "Email", "Password", "RefreshToken", "RefreshTokenExpiryTime", "ResetPasswordOtp", "ResetPasswordOtpExpiryTime", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("a27b7bb7-97c1-4c6a-97b9-3b07c5abb9b9"), true, new DateTime(2024, 6, 25, 14, 49, 23, 337, DateTimeKind.Utc).AddTicks(524), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "admin123", null, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" },
                    { new Guid("bb7b2bcc-15b2-4f17-85db-f7b5d64e78eb"), true, new DateTime(2024, 6, 25, 14, 49, 23, 337, DateTimeKind.Utc).AddTicks(532), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@example.com", "user123", null, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "GlobalId", "Active", "CreatedAt", "DeletedAt", "RoleId", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("1b08dd0e-a4d3-47c2-99ce-d5f0d5099573"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0c247561-d0c8-4d1f-9ed2-6dabd47a513d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a27b7bb7-97c1-4c6a-97b9-3b07c5abb9b9") },
                    { new Guid("cf2950be-55e0-48ce-86fd-f5bb7d5232e2"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6f2b946f-bba8-45e6-9ad7-d201f09c8587"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bb7b2bcc-15b2-4f17-85db-f7b5d64e78eb") }
                });
        }
    }
}
