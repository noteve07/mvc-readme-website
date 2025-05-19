using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcReadMe_Group4.Migrations
{
    /// <inheritdoc />
    public partial class AddReadCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReadCount",
                table: "BookReads",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadCount",
                table: "BookReads");
        }
    }
}
