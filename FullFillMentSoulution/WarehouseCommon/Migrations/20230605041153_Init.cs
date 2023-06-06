using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseCommon.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_입고상품_창고_창고Id",
                table: "입고상품");

            migrationBuilder.DropForeignKey(
                name: "FK_입고상품_창고상품_창고상품Id",
                table: "입고상품");

            migrationBuilder.DropForeignKey(
                name: "FK_적재상품_입고상품_입고상품Id",
                table: "적재상품");

            migrationBuilder.DropForeignKey(
                name: "FK_적재상품_창고_창고Id",
                table: "적재상품");

            migrationBuilder.DropForeignKey(
                name: "FK_적재상품_창고상품_창고상품Id",
                table: "적재상품");

            migrationBuilder.DropForeignKey(
                name: "FK_출고상품_입고상품_입고상품Id",
                table: "출고상품");

            migrationBuilder.DropForeignKey(
                name: "FK_출고상품_적재상품_적재상품Id",
                table: "출고상품");

            migrationBuilder.DropForeignKey(
                name: "FK_출고상품_창고_창고Id",
                table: "출고상품");

            migrationBuilder.DropForeignKey(
                name: "FK_출고상품_창고상품_창고상품Id",
                table: "출고상품");

            migrationBuilder.AlterColumn<string>(
                name: "창고상품Id",
                table: "출고상품",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "창고Id",
                table: "출고상품",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "적재상품Id",
                table: "출고상품",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "입고상품Id",
                table: "출고상품",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "창고상품Id",
                table: "적재상품",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "창고Id",
                table: "적재상품",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "입고상품Id",
                table: "적재상품",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "창고상품Id",
                table: "입고상품",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "창고Id",
                table: "입고상품",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AddForeignKey(
                name: "FK_입고상품_창고_창고Id",
                table: "입고상품",
                column: "창고Id",
                principalTable: "창고",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_입고상품_창고상품_창고상품Id",
                table: "입고상품",
                column: "창고상품Id",
                principalTable: "창고상품",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_적재상품_입고상품_입고상품Id",
                table: "적재상품",
                column: "입고상품Id",
                principalTable: "입고상품",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_적재상품_창고_창고Id",
                table: "적재상품",
                column: "창고Id",
                principalTable: "창고",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_적재상품_창고상품_창고상품Id",
                table: "적재상품",
                column: "창고상품Id",
                principalTable: "창고상품",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_출고상품_입고상품_입고상품Id",
                table: "출고상품",
                column: "입고상품Id",
                principalTable: "입고상품",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_출고상품_적재상품_적재상품Id",
                table: "출고상품",
                column: "적재상품Id",
                principalTable: "적재상품",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_출고상품_창고_창고Id",
                table: "출고상품",
                column: "창고Id",
                principalTable: "창고",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_출고상품_창고상품_창고상품Id",
                table: "출고상품",
                column: "창고상품Id",
                principalTable: "창고상품",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_입고상품_창고_창고Id",
                table: "입고상품");

            migrationBuilder.DropForeignKey(
                name: "FK_입고상품_창고상품_창고상품Id",
                table: "입고상품");

            migrationBuilder.DropForeignKey(
                name: "FK_적재상품_입고상품_입고상품Id",
                table: "적재상품");

            migrationBuilder.DropForeignKey(
                name: "FK_적재상품_창고_창고Id",
                table: "적재상품");

            migrationBuilder.DropForeignKey(
                name: "FK_적재상품_창고상품_창고상품Id",
                table: "적재상품");

            migrationBuilder.DropForeignKey(
                name: "FK_출고상품_입고상품_입고상품Id",
                table: "출고상품");

            migrationBuilder.DropForeignKey(
                name: "FK_출고상품_적재상품_적재상품Id",
                table: "출고상품");

            migrationBuilder.DropForeignKey(
                name: "FK_출고상품_창고_창고Id",
                table: "출고상품");

            migrationBuilder.DropForeignKey(
                name: "FK_출고상품_창고상품_창고상품Id",
                table: "출고상품");

            migrationBuilder.AlterColumn<string>(
                name: "창고상품Id",
                table: "출고상품",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "창고Id",
                table: "출고상품",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "적재상품Id",
                table: "출고상품",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "입고상품Id",
                table: "출고상품",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "창고상품Id",
                table: "적재상품",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "창고Id",
                table: "적재상품",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "입고상품Id",
                table: "적재상품",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "창고상품Id",
                table: "입고상품",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "창고Id",
                table: "입고상품",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_입고상품_창고_창고Id",
                table: "입고상품",
                column: "창고Id",
                principalTable: "창고",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_입고상품_창고상품_창고상품Id",
                table: "입고상품",
                column: "창고상품Id",
                principalTable: "창고상품",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_적재상품_입고상품_입고상품Id",
                table: "적재상품",
                column: "입고상품Id",
                principalTable: "입고상품",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_적재상품_창고_창고Id",
                table: "적재상품",
                column: "창고Id",
                principalTable: "창고",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_적재상품_창고상품_창고상품Id",
                table: "적재상품",
                column: "창고상품Id",
                principalTable: "창고상품",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_출고상품_입고상품_입고상품Id",
                table: "출고상품",
                column: "입고상품Id",
                principalTable: "입고상품",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_출고상품_적재상품_적재상품Id",
                table: "출고상품",
                column: "적재상품Id",
                principalTable: "적재상품",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_출고상품_창고_창고Id",
                table: "출고상품",
                column: "창고Id",
                principalTable: "창고",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_출고상품_창고상품_창고상품Id",
                table: "출고상품",
                column: "창고상품Id",
                principalTable: "창고상품",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
