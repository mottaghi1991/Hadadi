using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class editPaymentEventDatabasetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentEventDatabases_MyUser_myUserItUserId",
                schema: "dbo",
                table: "PaymentEventDatabases");

            migrationBuilder.DropIndex(
                name: "IX_PaymentEventDatabases_myUserItUserId",
                schema: "dbo",
                table: "PaymentEventDatabases");

            migrationBuilder.DropColumn(
                name: "myUserItUserId",
                schema: "dbo",
                table: "PaymentEventDatabases");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentEventDatabases_UserId",
                schema: "dbo",
                table: "PaymentEventDatabases",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentEventDatabases_MyUser_UserId",
                schema: "dbo",
                table: "PaymentEventDatabases",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "MyUser",
                principalColumn: "ItUserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentEventDatabases_MyUser_UserId",
                schema: "dbo",
                table: "PaymentEventDatabases");

            migrationBuilder.DropIndex(
                name: "IX_PaymentEventDatabases_UserId",
                schema: "dbo",
                table: "PaymentEventDatabases");

            migrationBuilder.AddColumn<int>(
                name: "myUserItUserId",
                schema: "dbo",
                table: "PaymentEventDatabases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentEventDatabases_myUserItUserId",
                schema: "dbo",
                table: "PaymentEventDatabases",
                column: "myUserItUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentEventDatabases_MyUser_myUserItUserId",
                schema: "dbo",
                table: "PaymentEventDatabases",
                column: "myUserItUserId",
                principalSchema: "dbo",
                principalTable: "MyUser",
                principalColumn: "ItUserId");
        }
    }
}
