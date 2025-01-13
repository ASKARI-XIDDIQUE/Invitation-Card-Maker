using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvitationCardMaker.Migrations
{
    /// <inheritdoc />
    public partial class customtemplatechangngs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "TopContent",
                table: "Template");

            migrationBuilder.DropColumn(
                name: "TopDescription",
                table: "Template");

            migrationBuilder.DropColumn(
                name: "TopTitle",
                table: "Template");

            migrationBuilder.AddColumn<string>(
                name: "ContentStyles",
                table: "CustomTemplates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionStyles",
                table: "CustomTemplates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleStyles",
                table: "CustomTemplates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "GlobalId", "Active", "CreatedAt", "DeletedAt", "RoleName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("5da24219-44c8-47b5-bc17-5b6ceae75cb5"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c858c6cc-4a24-479f-a87c-532a45d49c14"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "GlobalId", "Active", "CreatedAt", "DeletedAt", "Email", "Password", "RefreshToken", "RefreshTokenExpiryTime", "ResetPasswordOtp", "ResetPasswordOtpExpiryTime", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("5c0921d8-7ea6-4f89-a4e2-b7ee7fbb73ba"), true, new DateTime(2024, 7, 8, 13, 8, 39, 72, DateTimeKind.Utc).AddTicks(5290), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "admin123", null, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" },
                    { new Guid("682cdbaa-961d-4edd-bbe6-02bfdd797e81"), true, new DateTime(2024, 7, 8, 13, 8, 39, 72, DateTimeKind.Utc).AddTicks(5294), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@example.com", "user123", null, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "GlobalId", "Active", "CreatedAt", "DeletedAt", "RoleId", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("43b16fe1-6384-42a6-ac10-3b83aadd7848"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5da24219-44c8-47b5-bc17-5b6ceae75cb5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("682cdbaa-961d-4edd-bbe6-02bfdd797e81") },
                    { new Guid("f153e79a-1bbf-45f2-90dd-9e633578f69e"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c858c6cc-4a24-479f-a87c-532a45d49c14"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5c0921d8-7ea6-4f89-a4e2-b7ee7fbb73ba") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "GlobalId",
                keyValue: new Guid("43b16fe1-6384-42a6-ac10-3b83aadd7848"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "GlobalId",
                keyValue: new Guid("f153e79a-1bbf-45f2-90dd-9e633578f69e"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "GlobalId",
                keyValue: new Guid("5da24219-44c8-47b5-bc17-5b6ceae75cb5"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "GlobalId",
                keyValue: new Guid("c858c6cc-4a24-479f-a87c-532a45d49c14"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "GlobalId",
                keyValue: new Guid("5c0921d8-7ea6-4f89-a4e2-b7ee7fbb73ba"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "GlobalId",
                keyValue: new Guid("682cdbaa-961d-4edd-bbe6-02bfdd797e81"));

            migrationBuilder.DropColumn(
                name: "ContentStyles",
                table: "CustomTemplates");

            migrationBuilder.DropColumn(
                name: "DescriptionStyles",
                table: "CustomTemplates");

            migrationBuilder.DropColumn(
                name: "TitleStyles",
                table: "CustomTemplates");

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
    }
}
