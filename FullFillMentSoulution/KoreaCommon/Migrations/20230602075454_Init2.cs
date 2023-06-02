using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoreaCommon.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "수산품");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "수산협동조합",
                type: "varchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "수산협동조합",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "수산창고",
                type: "varchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "수산창고",
                type: "longtext",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "수산품별재고현황",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    수협Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    창고Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    수산품Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Code = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Quantity = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_수산품별재고현황", x => x.Id);
                    table.ForeignKey(
                        name: "FK_수산품별재고현황_수산창고_창고Id",
                        column: x => x.창고Id,
                        principalTable: "수산창고",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_수산품별재고현황_수산품_수산품Id",
                        column: x => x.수산품Id,
                        principalTable: "수산품",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_수산품별재고현황_수산협동조합_수협Id",
                        column: x => x.수협Id,
                        principalTable: "수산협동조합",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_수산품별재고현황_수산품Id",
                table: "수산품별재고현황",
                column: "수산품Id");

            migrationBuilder.CreateIndex(
                name: "IX_수산품별재고현황_수협Id",
                table: "수산품별재고현황",
                column: "수협Id");

            migrationBuilder.CreateIndex(
                name: "IX_수산품별재고현황_창고Id",
                table: "수산품별재고현황",
                column: "창고Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "수산품별재고현황");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "수산협동조합");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "수산협동조합");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "수산창고");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "수산창고");

            migrationBuilder.AddColumn<string>(
                name: "Quantity",
                table: "수산품",
                type: "longtext",
                nullable: false);
        }
    }
}
