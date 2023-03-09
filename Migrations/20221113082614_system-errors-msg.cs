using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace ModulerCrm.Migrations
{
    public partial class systemerrorsmsg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ErrorMassege",
                table: "SystemExceptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ErrorMassege",
                table: "SystemExceptions");
        }
    }
}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
