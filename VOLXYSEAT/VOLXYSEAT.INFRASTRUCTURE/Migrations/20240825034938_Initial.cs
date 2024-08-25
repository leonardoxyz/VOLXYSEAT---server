using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VOLXYSEAT.INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "volxyseat");

            migrationBuilder.CreateTable(
                name: "Subscription",
                schema: "volxyseat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordConfirm = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VolxyseatHistory",
                schema: "volxyseat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", unicode: false, nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", unicode: false, maxLength: 255, nullable: false),
                    Comment = table.Column<string>(type: "TEXT", unicode: false, maxLength: 255, nullable: true),
                    SubscriptionId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolxyseatHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VolxyseatHistory_Subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalSchema: "volxyseat",
                        principalTable: "Subscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VolxyseatHistory_SubscriptionId",
                schema: "volxyseat",
                table: "VolxyseatHistory",
                column: "SubscriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VolxyseatHistory",
                schema: "volxyseat");

            migrationBuilder.DropTable(
                name: "Subscription",
                schema: "volxyseat");
        }
    }
}
