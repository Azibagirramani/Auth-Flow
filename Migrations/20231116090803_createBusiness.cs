using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NgGold.Migrations
{
    /// <inheritdoc />
    public partial class createBusiness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User_businessCac_doc",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "business",
                columns: table => new
                {
                    cac_doc = table.Column<string>(type: "text", nullable: false),
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    country = table.Column<string>(type: "text", nullable: true),
                    state = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    currency = table.Column<string>(type: "text", nullable: true),
                    trial_ends = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    estimated_income = table.Column<long>(type: "bigint", nullable: false),
                    subscription = table.Column<long>(type: "bigint", nullable: false),
                    subsidiary_of = table.Column<long>(type: "bigint", nullable: false),
                    is_verified = table.Column<bool>(type: "boolean", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_business", x => x.cac_doc);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_User_businessCac_doc",
                table: "users",
                column: "User_businessCac_doc");

            migrationBuilder.AddForeignKey(
                name: "FK_users_business_User_businessCac_doc",
                table: "users",
                column: "User_businessCac_doc",
                principalTable: "business",
                principalColumn: "cac_doc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_business_User_businessCac_doc",
                table: "users");

            migrationBuilder.DropTable(
                name: "business");

            migrationBuilder.DropIndex(
                name: "IX_users_User_businessCac_doc",
                table: "users");

            migrationBuilder.DropColumn(
                name: "User_businessCac_doc",
                table: "users");
        }
    }
}
