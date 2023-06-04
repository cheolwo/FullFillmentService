using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoreaCommon.Migrations
{
    /// <inheritdoc />
    public partial class Init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_수산창고_수산협동조합_수협Id",
                table: "수산창고");

            migrationBuilder.DropForeignKey(
                name: "FK_수산품_수산창고_창고Id",
                table: "수산품");

            migrationBuilder.DropForeignKey(
                name: "FK_수산품_수산협동조합_수협Id",
                table: "수산품");

            migrationBuilder.DropForeignKey(
                name: "FK_수산품별재고현황_수산창고_창고Id",
                table: "수산품별재고현황");

            migrationBuilder.DropForeignKey(
                name: "FK_수산품별재고현황_수산품_수산품Id",
                table: "수산품별재고현황");

            migrationBuilder.DropForeignKey(
                name: "FK_수산품별재고현황_수산협동조합_수협Id",
                table: "수산품별재고현황");

            migrationBuilder.AlterColumn<string>(
                name: "창고Id",
                table: "수산품별재고현황",
                type: "varchar(128)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(128)");

            migrationBuilder.AlterColumn<string>(
                name: "수협Id",
                table: "수산품별재고현황",
                type: "varchar(128)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(128)");

            migrationBuilder.AlterColumn<string>(
                name: "수산품Id",
                table: "수산품별재고현황",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "date",
                table: "수산품별재고현황",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "창고Id",
                table: "수산품",
                type: "varchar(128)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(128)");

            migrationBuilder.AlterColumn<string>(
                name: "수협Id",
                table: "수산품",
                type: "varchar(128)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(128)");

            migrationBuilder.AlterColumn<string>(
                name: "수협Id",
                table: "수산창고",
                type: "varchar(128)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(128)");

            migrationBuilder.AddForeignKey(
                name: "FK_수산창고_수산협동조합_수협Id",
                table: "수산창고",
                column: "수협Id",
                principalTable: "수산협동조합",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_수산품_수산창고_창고Id",
                table: "수산품",
                column: "창고Id",
                principalTable: "수산창고",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_수산품_수산협동조합_수협Id",
                table: "수산품",
                column: "수협Id",
                principalTable: "수산협동조합",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_수산품별재고현황_수산창고_창고Id",
                table: "수산품별재고현황",
                column: "창고Id",
                principalTable: "수산창고",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_수산품별재고현황_수산품_수산품Id",
                table: "수산품별재고현황",
                column: "수산품Id",
                principalTable: "수산품",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_수산품별재고현황_수산협동조합_수협Id",
                table: "수산품별재고현황",
                column: "수협Id",
                principalTable: "수산협동조합",
                principalColumn: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_수산창고_수산협동조합_수협Id",
                table: "수산창고");

            migrationBuilder.DropForeignKey(
                name: "FK_수산품_수산창고_창고Id",
                table: "수산품");

            migrationBuilder.DropForeignKey(
                name: "FK_수산품_수산협동조합_수협Id",
                table: "수산품");

            migrationBuilder.DropForeignKey(
                name: "FK_수산품별재고현황_수산창고_창고Id",
                table: "수산품별재고현황");

            migrationBuilder.DropForeignKey(
                name: "FK_수산품별재고현황_수산품_수산품Id",
                table: "수산품별재고현황");

            migrationBuilder.DropForeignKey(
                name: "FK_수산품별재고현황_수산협동조합_수협Id",
                table: "수산품별재고현황");

            migrationBuilder.AlterColumn<string>(
                name: "창고Id",
                table: "수산품별재고현황",
                type: "varchar(128)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "수협Id",
                table: "수산품별재고현황",
                type: "varchar(128)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "수산품Id",
                table: "수산품별재고현황",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "date",
                table: "수산품별재고현황",
                type: "longtext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "창고Id",
                table: "수산품",
                type: "varchar(128)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "수협Id",
                table: "수산품",
                type: "varchar(128)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "수협Id",
                table: "수산창고",
                type: "varchar(128)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_수산창고_수산협동조합_수협Id",
                table: "수산창고",
                column: "수협Id",
                principalTable: "수산협동조합",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_수산품_수산창고_창고Id",
                table: "수산품",
                column: "창고Id",
                principalTable: "수산창고",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_수산품_수산협동조합_수협Id",
                table: "수산품",
                column: "수협Id",
                principalTable: "수산협동조합",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_수산품별재고현황_수산창고_창고Id",
                table: "수산품별재고현황",
                column: "창고Id",
                principalTable: "수산창고",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_수산품별재고현황_수산품_수산품Id",
                table: "수산품별재고현황",
                column: "수산품Id",
                principalTable: "수산품",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_수산품별재고현황_수산협동조합_수협Id",
                table: "수산품별재고현황",
                column: "수협Id",
                principalTable: "수산협동조합",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
