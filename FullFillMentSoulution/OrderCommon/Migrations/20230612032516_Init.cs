using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace 주문Common.Migrations
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
                name: "주문자",
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
                    table.PrimaryKey("PK_주문자", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "판매자판매정보요약",
                columns: table => new
                {
                    판매자Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Id = table.Column<string>(type: "longtext", nullable: true),
                    Code = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_판매자판매정보요약", x => x.판매자Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "판매자",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    판매자판매정보요약Id = table.Column<string>(type: "varchar(255)", nullable: false),
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
                    table.PrimaryKey("PK_판매자", x => x.Id);
                    table.ForeignKey(
                        name: "FK_판매자_판매자판매정보요약_판매자판매정보요약Id",
                        column: x => x.판매자판매정보요약Id,
                        principalTable: "판매자판매정보요약",
                        principalColumn: "판매자Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "판매자상품",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    판매개시일자 = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    판매자Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    창고Id = table.Column<string>(type: "longtext", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: false),
                    Code = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Quantity = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_판매자상품", x => x.Id);
                    table.ForeignKey(
                        name: "FK_판매자상품_판매자_판매자Id",
                        column: x => x.판매자Id,
                        principalTable: "판매자",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "댓글",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    판매자상품Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    주문자Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    판매자Id = table.Column<string>(type: "varchar(255)", nullable: true),
                    Code = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_댓글", x => x.Id);
                    table.ForeignKey(
                        name: "FK_댓글_주문자_주문자Id",
                        column: x => x.주문자Id,
                        principalTable: "주문자",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_댓글_판매자_판매자Id",
                        column: x => x.판매자Id,
                        principalTable: "판매자",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_댓글_판매자상품_판매자상품Id",
                        column: x => x.판매자상품Id,
                        principalTable: "판매자상품",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "상품문의",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    ImageUrlsJson = table.Column<string>(type: "longtext", nullable: true),
                    Content = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    판매자상품Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    주문자Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    판매자Id = table.Column<string>(type: "varchar(255)", nullable: true),
                    Code = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_상품문의", x => x.Id);
                    table.ForeignKey(
                        name: "FK_상품문의_주문자_주문자Id",
                        column: x => x.주문자Id,
                        principalTable: "주문자",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_상품문의_판매자_판매자Id",
                        column: x => x.판매자Id,
                        principalTable: "판매자",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_상품문의_판매자상품_판매자상품Id",
                        column: x => x.판매자상품Id,
                        principalTable: "판매자상품",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "주문",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    주문일자 = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    주문자Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    판매자상품Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    판매자Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Code = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Quantity = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_주문", x => x.Id);
                    table.ForeignKey(
                        name: "FK_주문_주문자_주문자Id",
                        column: x => x.주문자Id,
                        principalTable: "주문자",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_주문_판매자_판매자Id",
                        column: x => x.판매자Id,
                        principalTable: "판매자",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_주문_판매자상품_판매자상품Id",
                        column: x => x.판매자상품Id,
                        principalTable: "판매자상품",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "판매자상품판매정보요약",
                columns: table => new
                {
                    판매자상품Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    판매자Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Id = table.Column<string>(type: "longtext", nullable: true),
                    판매자판매정보요약판매자Id = table.Column<string>(type: "varchar(255)", nullable: true),
                    Code = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_판매자상품판매정보요약", x => new { x.판매자상품Id, x.판매자Id });
                    table.ForeignKey(
                        name: "FK_판매자상품판매정보요약_판매자_판매자Id",
                        column: x => x.판매자Id,
                        principalTable: "판매자",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_판매자상품판매정보요약_판매자상품_판매자상품Id",
                        column: x => x.판매자상품Id,
                        principalTable: "판매자상품",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_판매자상품판매정보요약_판매자판매정보요약_판매자판매정보요약판매자Id",
                        column: x => x.판매자판매정보요약판매자Id,
                        principalTable: "판매자판매정보요약",
                        principalColumn: "판매자Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "할일목록",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    판매자Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    주문Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    우선순위 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    상태 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_할일목록", x => x.Id);
                    table.ForeignKey(
                        name: "FK_할일목록_주문_주문Id",
                        column: x => x.주문Id,
                        principalTable: "주문",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_할일목록_판매자_판매자Id",
                        column: x => x.판매자Id,
                        principalTable: "판매자",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "주문자구매요약",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    구매일시 = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    총구매가격 = table.Column<string>(type: "longtext", nullable: false),
                    총수량 = table.Column<string>(type: "longtext", nullable: false),
                    판매자상품판매정보요약판매자상품Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    판매자상품판매정보요약판매자Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    판매자상품판매정보요약Id = table.Column<string>(type: "longtext", nullable: false),
                    판매자Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    판매자상품Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    주문자Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Code = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_주문자구매요약", x => x.Id);
                    table.ForeignKey(
                        name: "FK_주문자구매요약_주문자_주문자Id",
                        column: x => x.주문자Id,
                        principalTable: "주문자",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_주문자구매요약_판매자_판매자Id",
                        column: x => x.판매자Id,
                        principalTable: "판매자",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_주문자구매요약_판매자상품_판매자상품Id",
                        column: x => x.판매자상품Id,
                        principalTable: "판매자상품",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_주문자구매요약_판매자상품판매정보요약_판매자상품판매정보요약판매자상품Id_판매자상품판매정보요약판매자Id",
                        columns: x => new { x.판매자상품판매정보요약판매자상품Id, x.판매자상품판매정보요약판매자Id },
                        principalTable: "판매자상품판매정보요약",
                        principalColumns: new[] { "판매자상품Id", "판매자Id" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_댓글_주문자Id",
                table: "댓글",
                column: "주문자Id");

            migrationBuilder.CreateIndex(
                name: "IX_댓글_판매자상품Id",
                table: "댓글",
                column: "판매자상품Id");

            migrationBuilder.CreateIndex(
                name: "IX_댓글_판매자Id",
                table: "댓글",
                column: "판매자Id");

            migrationBuilder.CreateIndex(
                name: "IX_상품문의_주문자Id",
                table: "상품문의",
                column: "주문자Id");

            migrationBuilder.CreateIndex(
                name: "IX_상품문의_판매자상품Id",
                table: "상품문의",
                column: "판매자상품Id");

            migrationBuilder.CreateIndex(
                name: "IX_상품문의_판매자Id",
                table: "상품문의",
                column: "판매자Id");

            migrationBuilder.CreateIndex(
                name: "IX_주문_주문자Id",
                table: "주문",
                column: "주문자Id");

            migrationBuilder.CreateIndex(
                name: "IX_주문_판매자상품Id",
                table: "주문",
                column: "판매자상품Id");

            migrationBuilder.CreateIndex(
                name: "IX_주문_판매자Id",
                table: "주문",
                column: "판매자Id");

            migrationBuilder.CreateIndex(
                name: "IX_주문자구매요약_주문자Id",
                table: "주문자구매요약",
                column: "주문자Id");

            migrationBuilder.CreateIndex(
                name: "IX_주문자구매요약_판매자상품판매정보요약판매자상품Id_판매자상품판매정보요약판매자Id",
                table: "주문자구매요약",
                columns: new[] { "판매자상품판매정보요약판매자상품Id", "판매자상품판매정보요약판매자Id" });

            migrationBuilder.CreateIndex(
                name: "IX_주문자구매요약_판매자상품Id",
                table: "주문자구매요약",
                column: "판매자상품Id");

            migrationBuilder.CreateIndex(
                name: "IX_주문자구매요약_판매자Id",
                table: "주문자구매요약",
                column: "판매자Id");

            migrationBuilder.CreateIndex(
                name: "IX_판매자_판매자판매정보요약Id",
                table: "판매자",
                column: "판매자판매정보요약Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_판매자상품_판매자Id",
                table: "판매자상품",
                column: "판매자Id");

            migrationBuilder.CreateIndex(
                name: "IX_판매자상품판매정보요약_판매자판매정보요약판매자Id",
                table: "판매자상품판매정보요약",
                column: "판매자판매정보요약판매자Id");

            migrationBuilder.CreateIndex(
                name: "IX_판매자상품판매정보요약_판매자Id",
                table: "판매자상품판매정보요약",
                column: "판매자Id");

            migrationBuilder.CreateIndex(
                name: "IX_할일목록_주문Id",
                table: "할일목록",
                column: "주문Id");

            migrationBuilder.CreateIndex(
                name: "IX_할일목록_판매자Id",
                table: "할일목록",
                column: "판매자Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "댓글");

            migrationBuilder.DropTable(
                name: "상품문의");

            migrationBuilder.DropTable(
                name: "주문자구매요약");

            migrationBuilder.DropTable(
                name: "할일목록");

            migrationBuilder.DropTable(
                name: "판매자상품판매정보요약");

            migrationBuilder.DropTable(
                name: "주문");

            migrationBuilder.DropTable(
                name: "주문자");

            migrationBuilder.DropTable(
                name: "판매자상품");

            migrationBuilder.DropTable(
                name: "판매자");

            migrationBuilder.DropTable(
                name: "판매자판매정보요약");
        }
    }
}
