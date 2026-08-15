using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChamaGarcom.Migrations
{
    /// <inheritdoc />
    public partial class RenameTablesToRestaurantTablesAtt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatetdA",
                table: "CallRequests",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "CallRequests",
                newName: "CreatetdA");
        }
    }
}
