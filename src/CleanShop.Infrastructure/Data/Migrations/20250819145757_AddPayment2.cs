using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanShop.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPayment2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BasketId",
                table: "Payments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "BasketId1",
                table: "Payments",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BasketId1",
                table: "Payments",
                column: "BasketId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Baskets_BasketId1",
                table: "Payments",
                column: "BasketId1",
                principalTable: "Baskets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Baskets_BasketId1",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_BasketId1",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "BasketId1",
                table: "Payments");

            migrationBuilder.AlterColumn<string>(
                name: "BasketId",
                table: "Payments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
