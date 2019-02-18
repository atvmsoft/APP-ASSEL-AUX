using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Application.IO.Site.Migrations
{
    public partial class _2019021808 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoEndereco_AspNetUsers_IdInsertUser",
                table: "TipoEndereco");

            migrationBuilder.RenameColumn(
                name: "IdInsertUser",
                table: "TipoEndereco",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "DateInsert",
                table: "TipoEndereco",
                newName: "Date");

            migrationBuilder.RenameIndex(
                name: "IX_TipoEndereco_IdInsertUser",
                table: "TipoEndereco",
                newName: "IX_TipoEndereco_IdUser");

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "TipoEndereco",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoEndereco_AspNetUsers_IdUser",
                table: "TipoEndereco",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoEndereco_AspNetUsers_IdUser",
                table: "TipoEndereco");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "TipoEndereco");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "TipoEndereco",
                newName: "IdInsertUser");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "TipoEndereco",
                newName: "DateInsert");

            migrationBuilder.RenameIndex(
                name: "IX_TipoEndereco_IdUser",
                table: "TipoEndereco",
                newName: "IX_TipoEndereco_IdInsertUser");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoEndereco_AspNetUsers_IdInsertUser",
                table: "TipoEndereco",
                column: "IdInsertUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
