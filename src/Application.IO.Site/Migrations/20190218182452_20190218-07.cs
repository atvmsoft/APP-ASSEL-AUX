using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Application.IO.Site.Migrations
{
    public partial class _2019021807 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoContato_AspNetUsers_IdInsertUser",
                table: "TipoContato");

            migrationBuilder.DropColumn(
                name: "Formato",
                table: "TipoContato");

            migrationBuilder.RenameColumn(
                name: "IdInsertUser",
                table: "TipoContato",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "DateInsert",
                table: "TipoContato",
                newName: "Date");

            migrationBuilder.RenameIndex(
                name: "IX_TipoContato_IdInsertUser",
                table: "TipoContato",
                newName: "IX_TipoContato_IdUser");

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "TipoContato",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoContato_AspNetUsers_IdUser",
                table: "TipoContato",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoContato_AspNetUsers_IdUser",
                table: "TipoContato");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "TipoContato");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "TipoContato",
                newName: "IdInsertUser");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "TipoContato",
                newName: "DateInsert");

            migrationBuilder.RenameIndex(
                name: "IX_TipoContato_IdUser",
                table: "TipoContato",
                newName: "IX_TipoContato_IdInsertUser");

            migrationBuilder.AddColumn<string>(
                name: "Formato",
                table: "TipoContato",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoContato_AspNetUsers_IdInsertUser",
                table: "TipoContato",
                column: "IdInsertUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
