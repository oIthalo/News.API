using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoticesAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemovingUserPreferences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsItems_UserDtoRead_AuthorId",
                table: "NewsItems");

            migrationBuilder.DropTable(
                name: "UserDtoRead");

            migrationBuilder.DropTable(
                name: "UserPreferences");

            migrationBuilder.DropIndex(
                name: "IX_NewsItems_AuthorId",
                table: "NewsItems");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "NewsItems");

            migrationBuilder.RenameColumn(
                name: "Topics",
                table: "NewsItems",
                newName: "UrlToImage");

            migrationBuilder.RenameColumn(
                name: "PublishedDate",
                table: "NewsItems",
                newName: "PublishedAt");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "NewsItems",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "NewsItems",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SourceId",
                table: "NewsItems",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "NewsItems",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Source",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Source", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_NewsItems_SourceId",
                table: "NewsItems",
                column: "SourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsItems_Source_SourceId",
                table: "NewsItems",
                column: "SourceId",
                principalTable: "Source",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsItems_Source_SourceId",
                table: "NewsItems");

            migrationBuilder.DropTable(
                name: "Source");

            migrationBuilder.DropIndex(
                name: "IX_NewsItems_SourceId",
                table: "NewsItems");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "NewsItems");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "NewsItems");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "NewsItems");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "NewsItems");

            migrationBuilder.RenameColumn(
                name: "UrlToImage",
                table: "NewsItems",
                newName: "Topics");

            migrationBuilder.RenameColumn(
                name: "PublishedAt",
                table: "NewsItems",
                newName: "PublishedDate");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "NewsItems",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "UserDtoRead",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDtoRead", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDtoRead_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserPreferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FromDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PreferredKeyword = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PreferredLanguage = table.Column<int>(type: "int", nullable: false),
                    PreferredSortBy = table.Column<int>(type: "int", nullable: false),
                    Topics = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPreferences", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_NewsItems_AuthorId",
                table: "NewsItems",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDtoRead_RoleId",
                table: "UserDtoRead",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsItems_UserDtoRead_AuthorId",
                table: "NewsItems",
                column: "AuthorId",
                principalTable: "UserDtoRead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
