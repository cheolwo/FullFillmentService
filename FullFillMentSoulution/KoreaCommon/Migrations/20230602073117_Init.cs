using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoreaCommon.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "수산협동조합",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Code = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    FaxNumber = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Email = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_수산협동조합", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "수산창고",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    수협Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Code = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    FaxNumber = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Email = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_수산창고", x => x.Id);
                    table.ForeignKey(
                        name: "FK_수산창고_수산협동조합_수협Id",
                        column: x => x.수협Id,
                        principalTable: "수산협동조합",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "수산품",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    수협Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    창고Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Code = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Quantity = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_수산품", x => x.Id);
                    table.ForeignKey(
                        name: "FK_수산품_수산창고_창고Id",
                        column: x => x.창고Id,
                        principalTable: "수산창고",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_수산품_수산협동조합_수협Id",
                        column: x => x.수협Id,
                        principalTable: "수산협동조합",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_수산창고_수협Id",
                table: "수산창고",
                column: "수협Id");

            migrationBuilder.CreateIndex(
                name: "IX_수산품_수협Id",
                table: "수산품",
                column: "수협Id");

            migrationBuilder.CreateIndex(
                name: "IX_수산품_창고Id",
                table: "수산품",
                column: "창고Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "수산품");

            migrationBuilder.DropTable(
                name: "수산창고");

            migrationBuilder.DropTable(
                name: "수산협동조합");
        }
    }
}
