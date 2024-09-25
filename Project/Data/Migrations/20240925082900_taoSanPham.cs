﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class taoSanPham : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sanPham",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheLoaiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sanPham_theloai_TheLoaiId",
                        column: x => x.TheLoaiId,
                        principalTable: "theloai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sanPham_TheLoaiId",
                table: "sanPham",
                column: "TheLoaiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sanPham");
        }
    }
}
