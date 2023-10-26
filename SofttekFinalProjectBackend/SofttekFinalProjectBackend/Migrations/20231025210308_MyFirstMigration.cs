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
                name: "roles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role_isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    role_deletedTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionCrypto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uuid = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionCrypto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionFiduciary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cbu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionFiduciary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_password = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    user_email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    user_isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    user_deletedTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_users_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cryptoAccounts",
                columns: table => new
                {
                    account_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cryptoAccount_uuid = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    cryptoAccount_description = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    account_amount = table.Column<double>(type: "float", nullable: false),
                    account_typeOfaccount = table.Column<int>(type: "int", nullable: false),
                    account_user = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cryptoAccounts", x => x.account_id);
                    table.ForeignKey(
                        name: "FK_cryptoAccounts_users_account_user",
                        column: x => x.account_user,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fiduciaryAccounts",
                columns: table => new
                {
                    account_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fiduciaryAccount_cbu = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    fiduciaryAccount_alias = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    fiduciaryAccount_accountNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    account_amount = table.Column<double>(type: "float", nullable: false),
                    account_typeOfaccount = table.Column<int>(type: "int", nullable: false),
                    account_user = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fiduciaryAccounts", x => x.account_id);
                    table.ForeignKey(
                        name: "FK_fiduciaryAccounts_users_account_user",
                        column: x => x.account_user,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sales",
                columns: table => new
                {
                    sale_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sale_amount = table.Column<double>(type: "float", nullable: false),
                    sale_description = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    sale_cbuaccountpesos = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    sale_isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    sale_deletedTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales", x => x.sale_id);
                    table.ForeignKey(
                        name: "FK_sales_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    transaction_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transaction_typeofoperation = table.Column<int>(type: "int", nullable: false),
                    descriptionOperation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fiduciaryAccountOriginId = table.Column<int>(type: "int", nullable: true),
                    cryptoAccountOriginId = table.Column<int>(type: "int", nullable: true),
                    fiduciaryAccountDestinationId = table.Column<int>(type: "int", nullable: true),
                    cryptoAccountDestinationId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    transaction_createdTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    transaction_user = table.Column<int>(type: "int", nullable: false),
                    transaction_isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    transaction_deletedTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.transaction_id);
                    table.ForeignKey(
                        name: "FK_transactions_TransactionCrypto_cryptoAccountDestinationId",
                        column: x => x.cryptoAccountDestinationId,
                        principalTable: "TransactionCrypto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_transactions_TransactionCrypto_cryptoAccountOriginId",
                        column: x => x.cryptoAccountOriginId,
                        principalTable: "TransactionCrypto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_transactions_TransactionFiduciary_fiduciaryAccountDestinationId",
                        column: x => x.fiduciaryAccountDestinationId,
                        principalTable: "TransactionFiduciary",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_transactions_TransactionFiduciary_fiduciaryAccountOriginId",
                        column: x => x.fiduciaryAccountOriginId,
                        principalTable: "TransactionFiduciary",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_transactions_users_transaction_user",
                        column: x => x.transaction_user,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TransactionCrypto",
                columns: new[] { "Id", "Uuid" },
                values: new object[,]
                {
                    { 1, "CryptoUUID1" },
                    { 2, "CryptoUUID2" }
                });

            migrationBuilder.InsertData(
                table: "TransactionFiduciary",
                columns: new[] { "Id", "AccountNumber", "Alias", "Cbu" },
                values: new object[,]
                {
                    { 1, "12345", "Alias1", "CBU1" },
                    { 2, "54321", "Alias2", "CBU2" }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "role_id", "role_deletedTimeUtc", "role_description", "role_isDeleted", "role_name" },
                values: new object[,]
                {
                    { 1, null, "Administrator", false, "Administrator" },
                    { 2, null, "User", false, "User" }
                });

            migrationBuilder.InsertData(
                table: "sales",
                columns: new[] { "sale_id", "sale_amount", "sale_cbuaccountpesos", "sale_deletedTimeUtc", "sale_isDeleted", "sale_description", "UserId" },
                values: new object[,]
                {
                    { 1, 100.0, "CBU1", null, false, "bitcoin", null },
                    { 2, 50.0, "CBU1", null, false, "ethereum", null },
                    { 3, 75.0, "CBU3", null, false, "bitcoin", null },
                    { 4, 60.0, "CBU3", null, false, "ethereum", null },
                    { 5, 1.0, "CBU3", null, false, "bitcoin", null }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "user_deletedTimeUtc", "user_email", "user_isDeleted", "user_password", "role_id" },
                values: new object[,]
                {
                    { 1, null, "test@gmail.com", false, "fa6e018b85c7a6f1512b76a0d8d38a4562580b7a24ddff27bac616548d8639da", 2 },
                    { 2, null, "user1@example.com", false, "5453e3d9a64595e073a645187c4ab64ca4d851ac409ee9b13e665c6c41759924", 2 },
                    { 3, null, "user2@example.com", false, "c306b773f2093ae806bdf7b10f298d1ee824d5b519a69bddedb8a688ca4507b3", 2 },
                    { 4, null, "user3@example.com", false, "f998f7d0cf3ac4a74f4d1384615236a7d191f20100b83ae0633ed734335f1f52", 2 },
                    { 5, null, "user4@example.com", false, "683c958ae461277b7996eb5156869d3f1b26000fd937297dcdb59fed8f6cab23", 2 },
                    { 6, null, "user5@example.com", false, "5bb45a32b5f168a072bd9d043ab75e647add3694dfbf2e01c787c0c783292841", 2 }
                });

            migrationBuilder.InsertData(
                table: "cryptoAccounts",
                columns: new[] { "account_id", "account_amount", "cryptoAccount_description", "account_typeOfaccount", "account_user", "cryptoAccount_uuid" },
                values: new object[,]
                {
                    { 1, 1000.0, "Bitcoin", 2, 1, "CryptoUUID1" },
                    { 2, 1500.0, "Ethereum", 2, 1, "CryptoUUID2" },
                    { 3, 800.0, "Litecoin", 2, 2, "CryptoUUID3" },
                    { 4, 2000.0, "Ripple", 2, 2, "CryptoUUID4" }
                });

            migrationBuilder.InsertData(
                table: "fiduciaryAccounts",
                columns: new[] { "account_id", "fiduciaryAccount_accountNumber", "fiduciaryAccount_alias", "account_amount", "fiduciaryAccount_cbu", "account_typeOfaccount", "account_user" },
                values: new object[,]
                {
                    { 1, "12345", "Alias1", 500000000.0, "CBU1", 0, 1 },
                    { 2, "54321", "Alias2", 1000.0, "CBU2", 1, 1 },
                    { 3, "67890", "Alias3", 800.0, "CBU3", 0, 2 },
                    { 4, "98765", "Alias4", 1500.0, "CBU4", 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "transactions",
                columns: new[] { "transaction_id", "Amount", "transaction_createdTimeUtc", "transaction_deletedTimeUtc", "transaction_isDeleted", "transaction_typeofoperation", "transaction_user", "cryptoAccountDestinationId", "cryptoAccountOriginId", "descriptionOperation", "fiduciaryAccountDestinationId", "fiduciaryAccountOriginId" },
                values: new object[,]
                {
                    { 1, 100.0, new DateTime(2023, 10, 25, 21, 3, 7, 718, DateTimeKind.Utc).AddTicks(8576), null, false, 0, 1, null, 1, "Sale", null, null },
                    { 2, 50.0, new DateTime(2023, 10, 25, 21, 3, 7, 718, DateTimeKind.Utc).AddTicks(8584), null, false, 1, 2, null, null, "Buy", 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cryptoAccounts_account_user",
                table: "cryptoAccounts",
                column: "account_user");

            migrationBuilder.CreateIndex(
                name: "IX_cryptoAccounts_cryptoAccount_uuid",
                table: "cryptoAccounts",
                column: "cryptoAccount_uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fiduciaryAccounts_account_user",
                table: "fiduciaryAccounts",
                column: "account_user");

            migrationBuilder.CreateIndex(
                name: "IX_fiduciaryAccounts_fiduciaryAccount_accountNumber",
                table: "fiduciaryAccounts",
                column: "fiduciaryAccount_accountNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fiduciaryAccounts_fiduciaryAccount_alias",
                table: "fiduciaryAccounts",
                column: "fiduciaryAccount_alias",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fiduciaryAccounts_fiduciaryAccount_cbu",
                table: "fiduciaryAccounts",
                column: "fiduciaryAccount_cbu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sales_UserId",
                table: "sales",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_cryptoAccountDestinationId",
                table: "transactions",
                column: "cryptoAccountDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_cryptoAccountOriginId",
                table: "transactions",
                column: "cryptoAccountOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_fiduciaryAccountDestinationId",
                table: "transactions",
                column: "fiduciaryAccountDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_fiduciaryAccountOriginId",
                table: "transactions",
                column: "fiduciaryAccountOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_transaction_user",
                table: "transactions",
                column: "transaction_user");

            migrationBuilder.CreateIndex(
                name: "IX_users_role_id",
                table: "users",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_user_email",
                table: "users",
                column: "user_email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cryptoAccounts");

            migrationBuilder.DropTable(
                name: "fiduciaryAccounts");

            migrationBuilder.DropTable(
                name: "sales");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "TransactionCrypto");

            migrationBuilder.DropTable(
                name: "TransactionFiduciary");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
