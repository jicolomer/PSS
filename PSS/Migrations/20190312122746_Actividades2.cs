using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PSS.Migrations
{
    public partial class Actividades2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdArea",
                table: "Actividades",
                newName: "IdActividad");

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "Actividades",
                newName: "Actividad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdActividad",
                table: "Actividades",
                newName: "IdArea");

            migrationBuilder.RenameColumn(
                name: "Actividad",
                table: "Actividades",
                newName: "Area");
        }
    }
}
