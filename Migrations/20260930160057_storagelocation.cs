using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Combine_Day_Sixteen_N_Tier_APIs.Migrations
{
    /// <inheritdoc />
    public partial class storagelocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StorageLocation",
                table: "Supplies",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StorageLocation",
                table: "Supplies");
        }
    }
}
