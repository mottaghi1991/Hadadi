using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addPaymentEventDatabasetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentEventDatabases",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    authority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fee = table.Column<int>(type: "int", nullable: true),
                    fee_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code = table.Column<int>(type: "int", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    myUserItUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentEventDatabases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentEventDatabases_MyUser_myUserItUserId",
                        column: x => x.myUserItUserId,
                        principalSchema: "dbo",
                        principalTable: "MyUser",
                        principalColumn: "ItUserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentEventDatabases_myUserItUserId",
                schema: "dbo",
                table: "PaymentEventDatabases",
                column: "myUserItUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentEventDatabases",
                schema: "dbo");
        }
    }
}
