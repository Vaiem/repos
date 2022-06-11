using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogDesing.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "autors",
                columns: table => new
                {
                    AutorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autors", x => x.AutorId);
                });

            migrationBuilder.CreateTable(
                name: "desings",
                columns: table => new
                {
                    DesingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Autor = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    PhotoOne = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_desings", x => x.DesingId);
                });

            migrationBuilder.CreateTable(
                name: "AutorToDesing",
                columns: table => new
                {
                    AutorId = table.Column<int>(nullable: false),
                    DesingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorToDesing", x => new { x.AutorId, x.DesingId });
                    table.ForeignKey(
                        name: "FK_AutorToDesing_autors_AutorId",
                        column: x => x.AutorId,
                        principalTable: "autors",
                        principalColumn: "AutorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutorToDesing_desings_DesingId",
                        column: x => x.DesingId,
                        principalTable: "desings",
                        principalColumn: "DesingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutorToDesing_DesingId",
                table: "AutorToDesing",
                column: "DesingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorToDesing");

            migrationBuilder.DropTable(
                name: "autors");

            migrationBuilder.DropTable(
                name: "desings");
        }
    }
}
