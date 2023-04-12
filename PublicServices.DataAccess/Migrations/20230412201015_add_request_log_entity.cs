using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicServices.DataAccess.Migrations
{
    public partial class add_request_log_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestLogs",
                columns: table => new
                {
                    NombreServicio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaUso = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestLogs");
        }
    }
}
