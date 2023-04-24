using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxinatorBackend.Migrations
{
    /// <inheritdoc />
    public partial class updatedCountryStruc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countrys_Packages_PackageId",
                table: "Countrys");

            migrationBuilder.DropIndex(
                name: "IX_Countrys_PackageId",
                table: "Countrys");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Countrys");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "Countrys");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Countrys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "Countrys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Countrys_PackageId",
                table: "Countrys",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countrys_Packages_PackageId",
                table: "Countrys",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
