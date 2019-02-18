using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Application.IO.Site.Migrations
{
    public partial class _2019021806 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LogicalDelete",
                table: "AreaAtuacao",
                newName: "Delete");

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "Situacao",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Delete",
                table: "Situacao");

            migrationBuilder.RenameColumn(
                name: "Delete",
                table: "AreaAtuacao",
                newName: "LogicalDelete");
        }
    }
}
