using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Silicon_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedBiographytoUserTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Biography",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Biography",
                table: "AspNetUsers");
        }
    }
}
