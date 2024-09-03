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
            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordConfirm = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldStatus = table.Column<int>(type: "int", nullable: false),
                    NewStatus = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscription_SubscriptionHistory",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionProperties",
                columns: table => new
                {
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Support = table.Column<bool>(type: "bit", nullable: false),
                    Phone = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<bool>(type: "bit", nullable: false),
                    Messenger = table.Column<bool>(type: "bit", nullable: false),
                    Chat = table.Column<bool>(type: "bit", nullable: false),
                    LiveSupport = table.Column<bool>(type: "bit", nullable: false),
                    Documentation = table.Column<bool>(type: "bit", nullable: false),
                    Onboarding = table.Column<bool>(type: "bit", nullable: false),
                    Training = table.Column<bool>(type: "bit", nullable: false),
                    Updates = table.Column<bool>(type: "bit", nullable: false),
                    Backup = table.Column<bool>(type: "bit", nullable: false),
                    Customization = table.Column<bool>(type: "bit", nullable: false),
                    Analytics = table.Column<bool>(type: "bit", nullable: false),
                    Integration = table.Column<bool>(type: "bit", nullable: false),
                    APIAccess = table.Column<bool>(type: "bit", nullable: false),
                    CloudStorage = table.Column<bool>(type: "bit", nullable: false),
                    MultiUser = table.Column<bool>(type: "bit", nullable: false),
                    PrioritySupport = table.Column<bool>(type: "bit", nullable: false),
                    SLA = table.Column<bool>(type: "bit", nullable: false),
                    ServiceLevel = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionProperties", x => x.SubscriptionId);
                    table.ForeignKey(
                        name: "FK_SubscriptionProperties_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionHistories_SubscriptionId",
                table: "SubscriptionHistories",
                column: "SubscriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscriptionHistories");

            migrationBuilder.DropTable(
                name: "SubscriptionProperties");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Subscriptions");
        }
    }
}
