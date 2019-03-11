using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PSS.Migrations
{
    public partial class TiposObra3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposObra",
                table: "TiposObra");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TiposObra");

            migrationBuilder.AlterColumn<string>(
                name: "IdTipoObra",
                table: "TiposObra",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposObra",
                table: "TiposObra",
                column: "IdTipoObra");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposObra",
                table: "TiposObra");

            migrationBuilder.AlterColumn<int>(
                name: "IdTipoObra",
                table: "TiposObra",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TiposObra",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposObra",
                table: "TiposObra",
                column: "Id");
        }
    }
}
