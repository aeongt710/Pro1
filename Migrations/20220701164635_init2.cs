using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pro1.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_TicketBuyerId",
                table: "Tickets");

            migrationBuilder.AlterColumn<string>(
                name: "TicketBuyerId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_TicketBuyerId",
                table: "Tickets",
                column: "TicketBuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_TicketBuyerId",
                table: "Tickets");

            migrationBuilder.AlterColumn<string>(
                name: "TicketBuyerId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_TicketBuyerId",
                table: "Tickets",
                column: "TicketBuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
