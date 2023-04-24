using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxinatorBackend.Migrations
{
    /// <inheritdoc />
    public partial class newStruct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_UserProfiles_UserProfileId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "UserProfileEmail",
                table: "Packages");

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileId",
                table: "Packages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_UserProfiles_UserProfileId",
                table: "Packages",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_UserProfiles_UserProfileId",
                table: "Packages");

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileId",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserProfileEmail",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_UserProfiles_UserProfileId",
                table: "Packages",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
