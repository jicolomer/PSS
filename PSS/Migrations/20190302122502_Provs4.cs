using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PSS.Migrations
{
    public partial class Provs4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
name: "Provincias",
columns: table => new
{
IdProvincia = table.Column<int>(nullable: false),
Provincia = table.Column<string>(maxLength: 256, nullable: true)
},
constraints: table =>
{
table.PrimaryKey("PK_Provincias", x => x.IdProvincia);
});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
