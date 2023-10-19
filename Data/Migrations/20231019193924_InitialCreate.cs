using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropproAssistant.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Biddings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(type: "TEXT", nullable: true),
                    BiddingObject = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<string>(type: "TEXT", nullable: true),
                    Modality = table.Column<string>(type: "TEXT", nullable: true),
                    JudgingType = table.Column<string>(type: "TEXT", nullable: true),
                    Portal = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTimeOffset>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biddings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BiddingItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    CostValue = table.Column<double>(type: "REAL", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Unit = table.Column<string>(type: "TEXT", nullable: true),
                    Brand = table.Column<string>(type: "TEXT", nullable: true),
                    BiddingKey = table.Column<int>(type: "INTEGER", nullable: false),
                    BiddingId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiddingItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BiddingItem_Biddings_BiddingId",
                        column: x => x.BiddingId,
                        principalTable: "Biddings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BiddingItem_BiddingId",
                table: "BiddingItem",
                column: "BiddingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BiddingItem");

            migrationBuilder.DropTable(
                name: "Biddings");
        }
    }
}
