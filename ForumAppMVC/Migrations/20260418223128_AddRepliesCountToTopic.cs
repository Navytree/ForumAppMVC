using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCForumApp.Migrations
{
    /// <inheritdoc />
    public partial class AddRepliesCountToTopic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RepliesCount",
                table: "Topic",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepliesCount",
                table: "Topic");
        }
    }
}
