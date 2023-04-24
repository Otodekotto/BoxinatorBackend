using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxinatorBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserProfileEmail",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_Packages_UserProfileId",
                table: "Packages",
                column: "UserProfileId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_UserProfiles_UserProfileId",
                table: "Packages",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countrys_Packages_PackageId",
                table: "Countrys");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_UserProfiles_UserProfileId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_UserProfileId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Countrys_PackageId",
                table: "Countrys");

            migrationBuilder.DropColumn(
                name: "UserProfileEmail",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Countrys");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "Countrys");
        }
    }
}
