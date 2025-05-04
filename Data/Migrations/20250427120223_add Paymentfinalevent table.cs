using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addPaymentfinaleventtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                schema: "dbo",
                table: "PaymentEventDatabases",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                schema: "dbo",
                table: "PaymentEventDatabases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PaymentFinalEvents",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    card_hash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    card_pan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ref_id = table.Column<int>(type: "int", nullable: true),
                    fee_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fee = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentFinalEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentFinalEvents_ExamList_ExamId",
                        column: x => x.ExamId,
                        principalSchema: "dbo",
                        principalTable: "ExamList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentFinalEvents_MyUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "MyUser",
                        principalColumn: "ItUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentEventDatabases_ExamId",
                schema: "dbo",
                table: "PaymentEventDatabases",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentFinalEvents_ExamId",
                schema: "dbo",
                table: "PaymentFinalEvents",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentFinalEvents_UserId",
                schema: "dbo",
                table: "PaymentFinalEvents",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentEventDatabases_ExamList_ExamId",
                schema: "dbo",
                table: "PaymentEventDatabases",
                column: "ExamId",
                principalSchema: "dbo",
                principalTable: "ExamList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentEventDatabases_ExamList_ExamId",
                schema: "dbo",
                table: "PaymentEventDatabases");

            migrationBuilder.DropTable(
                name: "PaymentFinalEvents",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_PaymentEventDatabases_ExamId",
                schema: "dbo",
                table: "PaymentEventDatabases");

            migrationBuilder.DropColumn(
                name: "ExamId",
                schema: "dbo",
                table: "PaymentEventDatabases");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "dbo",
                table: "PaymentEventDatabases");
        }
    }
}
