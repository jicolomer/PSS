﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PSS.Migrations
{
    public partial class _20190318c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
    name: "Fase",
    table: "Actividades");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
