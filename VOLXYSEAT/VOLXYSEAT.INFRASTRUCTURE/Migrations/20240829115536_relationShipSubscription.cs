using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VOLXYSEAT.INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class relationShipSubscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Subscriptions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Subscriptions",
                type: "rowversion",
                rowVersion: true,
                nullable: true);
        }
    }
}
