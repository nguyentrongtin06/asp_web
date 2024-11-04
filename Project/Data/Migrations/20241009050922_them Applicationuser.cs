using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class themApplicationuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sanPham_theloai_TheLoaiId",
                table: "sanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sanPham",
                table: "sanPham");

            migrationBuilder.RenameTable(
                name: "sanPham",
                newName: "SanPham");

            migrationBuilder.RenameIndex(
                name: "IX_sanPham_TheLoaiId",
                table: "SanPham",
                newName: "IX_SanPham_TheLoaiId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SanPham",
                table: "SanPham",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_theloai_TheLoaiId",
                table: "SanPham",
                column: "TheLoaiId",
                principalTable: "theloai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_theloai_TheLoaiId",
                table: "SanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SanPham",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "SanPham",
                newName: "sanPham");

            migrationBuilder.RenameIndex(
                name: "IX_SanPham_TheLoaiId",
                table: "sanPham",
                newName: "IX_sanPham_TheLoaiId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sanPham",
                table: "sanPham",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sanPham_theloai_TheLoaiId",
                table: "sanPham",
                column: "TheLoaiId",
                principalTable: "theloai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
