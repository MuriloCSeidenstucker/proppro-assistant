using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropproAssistant.Data.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyNotNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Biddings_BiddingId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "BiddingId",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Biddings_BiddingId",
                table: "Items",
                column: "BiddingId",
                principalTable: "Biddings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Biddings_BiddingId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "BiddingId",
                table: "Items",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Biddings_BiddingId",
                table: "Items",
                column: "BiddingId",
                principalTable: "Biddings",
                principalColumn: "Id");
        }
    }
}
