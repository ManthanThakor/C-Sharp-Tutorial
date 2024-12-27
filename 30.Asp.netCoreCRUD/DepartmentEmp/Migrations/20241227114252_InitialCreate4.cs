using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepartmentEmp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageData",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<byte[]>(
                name: "imageData",
                table: "Employees",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
