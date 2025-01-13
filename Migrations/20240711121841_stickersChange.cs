using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvitationCardMaker.Migrations
{
    /// <inheritdoc />
    public partial class stickersChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "StickerStyles",
                table: "TemplateStickers");

            migrationBuilder.DropColumn(
                name: "StickersPath",
                table: "TemplateStickers");

            migrationBuilder.AddColumn<Guid>(
                name: "StickerId",
                table: "TemplateStickers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Stickers",
                columns: table => new
                {
                    GlobalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sticker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StickerStyle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stickers", x => x.GlobalId);
                });

            migrationBuilder.CreateTable(
                name: "TemplateUserImages",
                columns: table => new
                {
                    GlobalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageStyles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateUserImages", x => x.GlobalId);
                    table.ForeignKey(
                        name: "FK_TemplateUserImages_CustomTemplates_CustomTemplateId",
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
                    { new Guid("42be2fbf-2cf0-46af-9596-7d2003291a48"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d87e3e66-5e33-4c30-82b7-8b9f7a8fc8e4"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "GlobalId", "Active", "CreatedAt", "DeletedAt", "Email", "Password", "RefreshToken", "RefreshTokenExpiryTime", "ResetPasswordOtp", "ResetPasswordOtpExpiryTime", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("2076b72e-f821-4fe8-b772-b181532553db"), true, new DateTime(2024, 7, 11, 12, 18, 41, 422, DateTimeKind.Utc).AddTicks(9082), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@example.com", "user123", null, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user" },
                    { new Guid("5b29b0d7-5981-4d60-913f-50876568910e"), true, new DateTime(2024, 7, 11, 12, 18, 41, 422, DateTimeKind.Utc).AddTicks(9079), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "admin123", null, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "GlobalId", "Active", "CreatedAt", "DeletedAt", "RoleId", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("35cbd75f-c70b-4764-b807-f14d3cdee608"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("42be2fbf-2cf0-46af-9596-7d2003291a48"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5b29b0d7-5981-4d60-913f-50876568910e") },
                    { new Guid("9272b757-c765-4129-b939-37499ecf957f"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d87e3e66-5e33-4c30-82b7-8b9f7a8fc8e4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2076b72e-f821-4fe8-b772-b181532553db") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateStickers_StickerId",
                table: "TemplateStickers",
                column: "StickerId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateUserImages_CustomTemplateId",
                table: "TemplateUserImages",
                column: "CustomTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateStickers_Stickers_StickerId",
                table: "TemplateStickers",
                column: "StickerId",
                principalTable: "Stickers",
                principalColumn: "GlobalId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplateStickers_Stickers_StickerId",
                table: "TemplateStickers");

            migrationBuilder.DropTable(
                name: "Stickers");

            migrationBuilder.DropTable(
                name: "TemplateUserImages");

            migrationBuilder.DropIndex(
                name: "IX_TemplateStickers_StickerId",
                table: "TemplateStickers");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "GlobalId",
                keyValue: new Guid("35cbd75f-c70b-4764-b807-f14d3cdee608"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "GlobalId",
                keyValue: new Guid("9272b757-c765-4129-b939-37499ecf957f"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "GlobalId",
                keyValue: new Guid("42be2fbf-2cf0-46af-9596-7d2003291a48"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "GlobalId",
                keyValue: new Guid("d87e3e66-5e33-4c30-82b7-8b9f7a8fc8e4"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "GlobalId",
                keyValue: new Guid("2076b72e-f821-4fe8-b772-b181532553db"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "GlobalId",
                keyValue: new Guid("5b29b0d7-5981-4d60-913f-50876568910e"));

            migrationBuilder.DropColumn(
                name: "StickerId",
                table: "TemplateStickers");

            migrationBuilder.AddColumn<string>(
                name: "StickerStyles",
                table: "TemplateStickers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StickersPath",
                table: "TemplateStickers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
        }
    }
}
