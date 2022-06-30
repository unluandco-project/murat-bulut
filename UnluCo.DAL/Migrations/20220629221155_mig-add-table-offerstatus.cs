using Microsoft.EntityFrameworkCore.Migrations;

namespace UnluCo.DAL.Migrations
{
    public partial class migaddtableofferstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "OfferedPrice",
                table: "Offers",
                newName: "OfferStatusId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OfferPercentage",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OfferStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_OfferStatusId",
                table: "Offers",
                column: "OfferStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_OfferStatuses_OfferStatusId",
                table: "Offers",
                column: "OfferStatusId",
                principalTable: "OfferStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_OfferStatuses_OfferStatusId",
                table: "Offers");

            migrationBuilder.DropTable(
                name: "OfferStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Offers_OfferStatusId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "OfferPercentage",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "OfferStatusId",
                table: "Offers",
                newName: "OfferedPrice");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Offers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
