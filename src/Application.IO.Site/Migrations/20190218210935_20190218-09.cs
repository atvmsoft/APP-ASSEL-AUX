using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Application.IO.Site.Migrations
{
    public partial class _2019021809 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advogado_AspNetUsers_IdInsertUser",
                table: "Advogado");

            migrationBuilder.RenameColumn(
                name: "IdInsertUser",
                table: "Advogado",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "DateInsert",
                table: "Advogado",
                newName: "Date");

            migrationBuilder.RenameIndex(
                name: "IX_Advogado_IdInsertUser",
                table: "Advogado",
                newName: "IX_Advogado_IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Advogado_AspNetUsers_IdUser",
                table: "Advogado",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advogado_AspNetUsers_IdUser",
                table: "Advogado");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Advogado",
                newName: "IdInsertUser");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Advogado",
                newName: "DateInsert");

            migrationBuilder.RenameIndex(
                name: "IX_Advogado_IdUser",
                table: "Advogado",
                newName: "IX_Advogado_IdInsertUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Advogado_AspNetUsers_IdInsertUser",
                table: "Advogado",
                column: "IdInsertUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
