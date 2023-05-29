using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderCommon.Migrations
{
    /// <inheritdoc />
    public partial class SeCond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Orderers_OrdererId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_SellerCommodites_SellerCommodityId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "SellerCommodityId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Orders",
                type: "double",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<int>(
                name: "OrdererId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Orderers_OrdererId",
                table: "Orders",
                column: "OrdererId",
                principalTable: "Orderers",
                principalColumn: "OrdererId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_SellerCommodites_SellerCommodityId",
                table: "Orders",
                column: "SellerCommodityId",
                principalTable: "SellerCommodites",
                principalColumn: "SellerCommodityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Orderers_OrdererId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_SellerCommodites_SellerCommodityId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "SellerCommodityId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Orders",
                type: "double",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrdererId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Orderers_OrdererId",
                table: "Orders",
                column: "OrdererId",
                principalTable: "Orderers",
                principalColumn: "OrdererId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_SellerCommodites_SellerCommodityId",
                table: "Orders",
                column: "SellerCommodityId",
                principalTable: "SellerCommodites",
                principalColumn: "SellerCommodityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
