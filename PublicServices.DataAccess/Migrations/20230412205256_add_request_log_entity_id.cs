using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicServices.DataAccess.Migrations
{
    public partial class add_request_log_entity_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RequestLogs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestLogs",
                table: "RequestLogs",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestLogs",
                table: "RequestLogs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RequestLogs");
        }
    }
}
