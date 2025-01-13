using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvitationCardMaker.Migrations
{
    /// <inheritdoc />
    public partial class customTemplatesChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "TemplateStickers",
                columns: table => new
                {
                    GlobalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StickersPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StickerStyles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateStickers", x => x.GlobalId);
                    table.ForeignKey(
                        name: "FK_TemplateStickers_CustomTemplates_CustomTemplateId",
                        column: x => x.CustomTemplateId,
                        principalTable: "CustomTemplates",
                        principalColumn: "GlobalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateTextBox",
                columns: table => new
                {
                    GlobalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TextBox = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Style = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateTextBox", x => x.GlobalId);
                    table.ForeignKey(
                        name: "FK_TemplateTextBox_CustomTemplates_CustomTemplateId",
                        column: x => x.CustomTemplateId,
                        principalTable: "CustomTemplates",
                        principalColumn: "GlobalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "GlobalId", "Active", "CreatedAt", "DeletedAt", "RoleName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3bd86960-c37c-441f-b3a0-292f53d12e89"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f3d82957-c4e8-4a53-9fa3-68e878c68252"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "GlobalId", "Active", "CreatedAt", "DeletedAt", "Email", "Password", "RefreshToken", "RefreshTokenExpiryTime", "ResetPasswordOtp", "ResetPasswordOtpExpiryTime", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("0ea3606e-151f-4dd8-aa1d-b9ac5cc32e60"), true, new DateTime(2024, 7, 9, 11, 48, 38, 308, DateTimeKind.Utc).AddTicks(1839), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@example.com", "user123", null, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user" },
                    { new Guid("37098140-2fa1-405b-9012-922b8a6c65e7"), true, new DateTime(2024, 7, 9, 11, 48, 38, 308, DateTimeKind.Utc).AddTicks(1835), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "admin123", null, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "GlobalId", "Active", "CreatedAt", "DeletedAt", "RoleId", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("a9459fde-b0e2-4846-8726-2e1a444c9691"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f3d82957-c4e8-4a53-9fa3-68e878c68252"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("37098140-2fa1-405b-9012-922b8a6c65e7") },
                    { new Guid("f43c727a-df96-414b-a596-43934059075c"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3bd86960-c37c-441f-b3a0-292f53d12e89"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0ea3606e-151f-4dd8-aa1d-b9ac5cc32e60") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateStickers_CustomTemplateId",
                table: "TemplateStickers",
                column: "CustomTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateTextBox_CustomTemplateId",
                table: "TemplateTextBox",
                column: "CustomTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemplateStickers");

            migrationBuilder.DropTable(
                name: "TemplateTextBox");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "GlobalId",
                keyValue: new Guid("a9459fde-b0e2-4846-8726-2e1a444c9691"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "GlobalId",
                keyValue: new Guid("f43c727a-df96-414b-a596-43934059075c"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "GlobalId",
                keyValue: new Guid("3bd86960-c37c-441f-b3a0-292f53d12e89"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "GlobalId",
                keyValue: new Guid("f3d82957-c4e8-4a53-9fa3-68e878c68252"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "GlobalId",
                keyValue: new Guid("0ea3606e-151f-4dd8-aa1d-b9ac5cc32e60"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "GlobalId",
                keyValue: new Guid("37098140-2fa1-405b-9012-922b8a6c65e7"));

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
    }
}
