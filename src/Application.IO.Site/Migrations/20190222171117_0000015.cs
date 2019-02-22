using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Application.IO.Site.Migrations
{
    public partial class _0000015 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvogadoContato_AspNetUsers_IdInsertUser",
                table: "AdvogadoContato");

            migrationBuilder.RenameColumn(
                name: "IdInsertUser",
                table: "AdvogadoContato",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_AdvogadoContato_IdInsertUser",
                table: "AdvogadoContato",
                newName: "IX_AdvogadoContato_IdUser");

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "AdvogadoContato",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvogadoContato_AspNetUsers_IdUser",
                table: "AdvogadoContato",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvogadoContato_AspNetUsers_IdUser",
                table: "AdvogadoContato");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "AdvogadoContato");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "AdvogadoContato",
                newName: "IdInsertUser");

            migrationBuilder.RenameIndex(
                name: "IX_AdvogadoContato_IdUser",
                table: "AdvogadoContato",
                newName: "IX_AdvogadoContato_IdInsertUser");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvogadoContato_AspNetUsers_IdInsertUser",
                table: "AdvogadoContato",
                column: "IdInsertUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
