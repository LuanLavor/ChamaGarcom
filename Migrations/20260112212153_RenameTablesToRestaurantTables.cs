using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChamaGarcom.Migrations
{
    /// <inheritdoc />
    public partial class RenameTablesToRestaurantTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CallRequests_Tables_RestaurantTableId",
                table: "CallRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Restaurants_RestaurantId",
                table: "Tables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tables",
                table: "Tables");

            migrationBuilder.RenameTable(
                name: "Tables",
                newName: "RestaurantTables");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "CallRequests",
                newName: "IsCompleted");

            migrationBuilder.RenameColumn(
                name: "RequestedAt",
                table: "CallRequests",
                newName: "CreatetdA");

            migrationBuilder.RenameIndex(
                name: "IX_Tables_RestaurantId",
                table: "RestaurantTables",
                newName: "IX_RestaurantTables_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantTables",
                table: "RestaurantTables",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CallRequests_RestaurantTables_RestaurantTableId",
                table: "CallRequests",
                column: "RestaurantTableId",
                principalTable: "RestaurantTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantTables_Restaurants_RestaurantId",
                table: "RestaurantTables",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CallRequests_RestaurantTables_RestaurantTableId",
                table: "CallRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantTables_Restaurants_RestaurantId",
                table: "RestaurantTables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantTables",
                table: "RestaurantTables");

            migrationBuilder.RenameTable(
                name: "RestaurantTables",
                newName: "Tables");

            migrationBuilder.RenameColumn(
                name: "IsCompleted",
                table: "CallRequests",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "CreatetdA",
                table: "CallRequests",
                newName: "RequestedAt");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantTables_RestaurantId",
                table: "Tables",
                newName: "IX_Tables_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tables",
                table: "Tables",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CallRequests_Tables_RestaurantTableId",
                table: "CallRequests",
                column: "RestaurantTableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Restaurants_RestaurantId",
                table: "Tables",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
