using Microsoft.EntityFrameworkCore.Migrations;

namespace UserService.Migrations
{
    public partial class DeviceTokenAdicionado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "device_token",
                table: "usuario",
                type: "varchar(200)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "device_token",
                table: "usuario");
        }
    }
}
