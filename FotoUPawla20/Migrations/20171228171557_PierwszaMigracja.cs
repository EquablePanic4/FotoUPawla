using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FotoUPawla20.Migrations
{
    public partial class PierwszaMigracja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    KlienciModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdresZdjec = table.Column<string>(nullable: true),
                    Data = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    KodKlienta = table.Column<string>(nullable: true),
                    Nazwa = table.Column<string>(nullable: false),
                    Telefon = table.Column<string>(nullable: false),
                    Tytul = table.Column<string>(nullable: false),
                    Zrealizowano = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienci", x => x.KlienciModelId);
                });

            migrationBuilder.CreateTable(
                name: "Konfiguracja",
                columns: table => new
                {
                    CodliConfigurationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConfName = table.Column<string>(nullable: true),
                    ConfValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konfiguracja", x => x.CodliConfigurationId);
                });

            migrationBuilder.CreateTable(
                name: "Zdjecia",
                columns: table => new
                {
                    ZdjeciaModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GaleriaId = table.Column<int>(nullable: false),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zdjecia", x => x.ZdjeciaModelId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Klienci");

            migrationBuilder.DropTable(
                name: "Konfiguracja");

            migrationBuilder.DropTable(
                name: "Zdjecia");
        }
    }
}
