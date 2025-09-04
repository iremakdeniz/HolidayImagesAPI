using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HolidayImagesAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSubCategoryIdToImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "Images",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_Images_SubCategoryId",
                table: "Images",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Categories_SubCategoryId",
                table: "Images",
                column: "SubCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Categories_SubCategoryId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_SubCategoryId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
