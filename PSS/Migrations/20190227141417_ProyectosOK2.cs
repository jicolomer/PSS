using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PSS.Migrations
{
    public partial class ProyectosOK2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdEmpresa",
                table: "Proyectos",
                newName: "IdEmpre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdEmpre",
                table: "Proyectos",
                newName: "IdEmpresa");
        }
    }
}
