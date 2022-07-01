using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pro1.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchasedTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketOwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasedTickets_AspNetUsers_TicketOwnerId",
                        column: x => x.TicketOwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    isPurchased = table.Column<bool>(type: "bit", nullable: false),
                    TicketCreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_TicketCreatorId",
                        column: x => x.TicketCreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedTickets_TicketOwnerId",
                table: "PurchasedTickets",
                column: "TicketOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketCreatorId",
                table: "Tickets",
                column: "TicketCreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchasedTickets");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
