using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace 주문Common.Migrations
{
    /// <inheritdoc />
    public partial class InitContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "댓글",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "댓글");
        }
    }
}
