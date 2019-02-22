using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Application.IO.Site.Migrations
{
    public partial class _0000016 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvogadoEndereco_AspNetUsers_IdInsertUser",
                table: "AdvogadoEndereco");

            migrationBuilder.DropForeignKey(
                name: "FK_GeoCep_AspNetUsers_IdInsertUser",
                table: "GeoCep");

            migrationBuilder.RenameColumn(
                name: "IdInsertUser",
                table: "GeoCep",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "DateInsert",
                table: "GeoCep",
                newName: "Date");

            migrationBuilder.RenameIndex(
                name: "IX_GeoCep_IdInsertUser",
                table: "GeoCep",
                newName: "IX_GeoCep_IdUser");

            migrationBuilder.RenameColumn(
                name: "IdInsertUser",
                table: "AdvogadoEndereco",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "DateInsert",
                table: "AdvogadoEndereco",
                newName: "Date");

            migrationBuilder.RenameIndex(
                name: "IX_AdvogadoEndereco_IdInsertUser",
                table: "AdvogadoEndereco",
                newName: "IX_AdvogadoEndereco_IdUser");

            migrationBuilder.RenameColumn(
                name: "DateInsert",
                table: "AdvogadoContato",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "DateInsert",
                table: "AdvogadoAreaAtuacao",
                newName: "Date");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvogadoEndereco_AspNetUsers_IdUser",
                table: "AdvogadoEndereco",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GeoCep_AspNetUsers_IdUser",
                table: "GeoCep",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvogadoEndereco_AspNetUsers_IdUser",
                table: "AdvogadoEndereco");

            migrationBuilder.DropForeignKey(
                name: "FK_GeoCep_AspNetUsers_IdUser",
                table: "GeoCep");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "GeoCep",
                newName: "IdInsertUser");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "GeoCep",
                newName: "DateInsert");

            migrationBuilder.RenameIndex(
                name: "IX_GeoCep_IdUser",
                table: "GeoCep",
                newName: "IX_GeoCep_IdInsertUser");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "AdvogadoEndereco",
                newName: "IdInsertUser");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "AdvogadoEndereco",
                newName: "DateInsert");

            migrationBuilder.RenameIndex(
                name: "IX_AdvogadoEndereco_IdUser",
                table: "AdvogadoEndereco",
                newName: "IX_AdvogadoEndereco_IdInsertUser");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "AdvogadoContato",
                newName: "DateInsert");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "AdvogadoAreaAtuacao",
                newName: "DateInsert");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvogadoEndereco_AspNetUsers_IdInsertUser",
                table: "AdvogadoEndereco",
                column: "IdInsertUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GeoCep_AspNetUsers_IdInsertUser",
                table: "GeoCep",
                column: "IdInsertUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
