using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvitationCardMaker.Migrations
{
    /// <inheritdoc />
    public partial class seedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BottPosContent",
                table: "Template",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BottPosDescription",
                table: "Template",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BottPosTitle",
                table: "Template",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LefPosDescription",
                table: "Template",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LefPosTitle",
                table: "Template",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LeftPosContent",
                table: "Template",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RigPosContent",
                table: "Template",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RigPosDescription",
                table: "Template",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RigPosTitle",
                table: "Template",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    GlobalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.GlobalId);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    GlobalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.GlobalId);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "GlobalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "GlobalId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "GlobalId",
                keyValue: new Guid("a27b7bb7-97c1-4c6a-97b9-3b07c5abb9b9"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "GlobalId",
                keyValue: new Guid("bb7b2bcc-15b2-4f17-85db-f7b5d64e78eb"));

            migrationBuilder.DropColumn(
                name: "BottPosContent",
                table: "Template");

            migrationBuilder.DropColumn(
                name: "BottPosDescription",
                table: "Template");

            migrationBuilder.DropColumn(
                name: "BottPosTitle",
                table: "Template");

            migrationBuilder.DropColumn(
                name: "LefPosDescription",
                table: "Template");

            migrationBuilder.DropColumn(
                name: "LefPosTitle",
                table: "Template");

            migrationBuilder.DropColumn(
                name: "LeftPosContent",
                table: "Template");

            migrationBuilder.DropColumn(
                name: "RigPosContent",
                table: "Template");

            migrationBuilder.DropColumn(
                name: "RigPosDescription",
                table: "Template");

            migrationBuilder.DropColumn(
                name: "RigPosTitle",
                table: "Template");
        }
    }
}
