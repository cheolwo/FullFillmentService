using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseCommon.Migrations
{
    /// <inheritdoc />
    public partial class Init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "창고",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Code = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    FaxNumber = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Email = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Address = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    ZipCode = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_창고", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "창고상품",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    창고Id = table.Column<string>(type: "varchar(255)", nullable: true),
                    Code = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_창고상품", x => x.Id);
                    table.ForeignKey(
                        name: "FK_창고상품_창고_창고Id",
                        column: x => x.창고Id,
                        principalTable: "창고",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "입고상품",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    창고Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    창고상품Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Code = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Quantity = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_입고상품", x => x.Id);
                    table.ForeignKey(
                        name: "FK_입고상품_창고_창고Id",
                        column: x => x.창고Id,
                        principalTable: "창고",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_입고상품_창고상품_창고상품Id",
                        column: x => x.창고상품Id,
                        principalTable: "창고상품",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "적재상품",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    창고Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    창고상품Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    입고상품Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Code = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Quantity = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_적재상품", x => x.Id);
                    table.ForeignKey(
                        name: "FK_적재상품_입고상품_입고상품Id",
                        column: x => x.입고상품Id,
                        principalTable: "입고상품",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_적재상품_창고_창고Id",
                        column: x => x.창고Id,
                        principalTable: "창고",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_적재상품_창고상품_창고상품Id",
                        column: x => x.창고상품Id,
                        principalTable: "창고상품",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "출고상품",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    창고Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    창고상품Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    입고상품Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    적재상품Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Code = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Quantity = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_출고상품", x => x.Id);
                    table.ForeignKey(
                        name: "FK_출고상품_입고상품_입고상품Id",
                        column: x => x.입고상품Id,
                        principalTable: "입고상품",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_출고상품_적재상품_적재상품Id",
                        column: x => x.적재상품Id,
                        principalTable: "적재상품",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_출고상품_창고_창고Id",
                        column: x => x.창고Id,
                        principalTable: "창고",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_출고상품_창고상품_창고상품Id",
                        column: x => x.창고상품Id,
                        principalTable: "창고상품",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_입고상품_창고상품Id",
                table: "입고상품",
                column: "창고상품Id");

            migrationBuilder.CreateIndex(
                name: "IX_입고상품_창고Id",
                table: "입고상품",
                column: "창고Id");

            migrationBuilder.CreateIndex(
                name: "IX_적재상품_입고상품Id",
                table: "적재상품",
                column: "입고상품Id");

            migrationBuilder.CreateIndex(
                name: "IX_적재상품_창고상품Id",
                table: "적재상품",
                column: "창고상품Id");

            migrationBuilder.CreateIndex(
                name: "IX_적재상품_창고Id",
                table: "적재상품",
                column: "창고Id");

            migrationBuilder.CreateIndex(
                name: "IX_창고상품_창고Id",
                table: "창고상품",
                column: "창고Id");

            migrationBuilder.CreateIndex(
                name: "IX_출고상품_입고상품Id",
                table: "출고상품",
                column: "입고상품Id");

            migrationBuilder.CreateIndex(
                name: "IX_출고상품_적재상품Id",
                table: "출고상품",
                column: "적재상품Id");

            migrationBuilder.CreateIndex(
                name: "IX_출고상품_창고상품Id",
                table: "출고상품",
                column: "창고상품Id");

            migrationBuilder.CreateIndex(
                name: "IX_출고상품_창고Id",
                table: "출고상품",
                column: "창고Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "출고상품");

            migrationBuilder.DropTable(
                name: "적재상품");

            migrationBuilder.DropTable(
                name: "입고상품");

            migrationBuilder.DropTable(
                name: "창고상품");

            migrationBuilder.DropTable(
                name: "창고");
        }
    }
}
