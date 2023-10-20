using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SofttekFinalProjectBackend.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_password = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    user_email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    user_isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    user_deletedTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "cryptoAccount",
                columns: table => new
                {
                    account_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cryptoAccount_uuid = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    cryptoAccount_description = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    account_amount = table.Column<int>(type: "int", nullable: false),
                    account_sortofaccount = table.Column<int>(type: "int", nullable: false),
                    account_user = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cryptoAccount", x => x.account_id);
                    table.ForeignKey(
                        name: "FK_cryptoAccount_users_account_user",
                        column: x => x.account_user,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fiduciaryAccount",
                columns: table => new
                {
                    account_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fiduciaryAccount_cbu = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    fiduciaryAccount_alias = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    fiduciaryAccount_accountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    account_amount = table.Column<int>(type: "int", nullable: false),
                    account_sortofaccount = table.Column<int>(type: "int", nullable: false),
                    account_user = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fiduciaryAccount", x => x.account_id);
                    table.ForeignKey(
                        name: "FK_fiduciaryAccount_users_account_user",
                        column: x => x.account_user,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "user_deletedTimeUtc", "user_email", "user_isDeleted", "user_password" },
                values: new object[] { 1, null, "test@gmail.com", false, "fa6e018b85c7a6f1512b76a0d8d38a4562580b7a24ddff27bac616548d8639da" });

            migrationBuilder.InsertData(
                table: "cryptoAccount",
                columns: new[] { "account_id", "account_amount", "cryptoAccount_description", "account_sortofaccount", "account_user", "cryptoAccount_uuid" },
                values: new object[] { 1, 1000, "Bitcoin", 2, 1, "CryptoUUID1" });

            migrationBuilder.InsertData(
                table: "cryptoAccount",
                columns: new[] { "account_id", "account_amount", "cryptoAccount_description", "account_sortofaccount", "account_user", "cryptoAccount_uuid" },
                values: new object[] { 2, 1500, "Ethereum", 2, 1, "CryptoUUID2" });

            migrationBuilder.InsertData(
                table: "fiduciaryAccount",
                columns: new[] { "account_id", "fiduciaryAccount_accountNumber", "fiduciaryAccount_alias", "account_amount", "fiduciaryAccount_cbu", "account_sortofaccount", "account_user" },
                values: new object[] { 1, "12345", "Alias1", 500, "CBU1", 0, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_cryptoAccount_account_user",
                table: "cryptoAccount",
                column: "account_user");

            migrationBuilder.CreateIndex(
                name: "IX_fiduciaryAccount_account_user",
                table: "fiduciaryAccount",
                column: "account_user");

            migrationBuilder.CreateIndex(
                name: "IX_users_user_email",
                table: "users",
                column: "user_email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cryptoAccount");

            migrationBuilder.DropTable(
                name: "fiduciaryAccount");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
