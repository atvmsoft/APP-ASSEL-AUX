using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Application.IO.Site.Migrations
{
    public partial class _2019021804 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreaAtuacao_AspNetUsers_IdInsertUser",
                table: "AreaAtuacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Situacao_AspNetUsers_IdInsertUser",
                table: "Situacao");

            migrationBuilder.RenameColumn(
                name: "IdInsertUser",
                table: "Situacao",
                newName: "IdtUser");

            migrationBuilder.RenameIndex(
                name: "IX_Situacao_IdInsertUser",
                table: "Situacao",
                newName: "IX_Situacao_IdtUser");

            migrationBuilder.RenameColumn(
                name: "IdInsertUser",
                table: "AreaAtuacao",
                newName: "IdtUser");

            migrationBuilder.RenameIndex(
                name: "IX_AreaAtuacao_IdInsertUser",
                table: "AreaAtuacao",
                newName: "IX_AreaAtuacao_IdtUser");

            migrationBuilder.AddForeignKey(
                name: "FK_AreaAtuacao_AspNetUsers_IdtUser",
                table: "AreaAtuacao",
                column: "IdtUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Situacao_AspNetUsers_IdtUser",
                table: "Situacao",
                column: "IdtUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreaAtuacao_AspNetUsers_IdtUser",
                table: "AreaAtuacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Situacao_AspNetUsers_IdtUser",
                table: "Situacao");

            migrationBuilder.RenameColumn(
                name: "IdtUser",
                table: "Situacao",
                newName: "IdInsertUser");

            migrationBuilder.RenameIndex(
                name: "IX_Situacao_IdtUser",
                table: "Situacao",
                newName: "IX_Situacao_IdInsertUser");

            migrationBuilder.RenameColumn(
                name: "IdtUser",
                table: "AreaAtuacao",
                newName: "IdInsertUser");

            migrationBuilder.RenameIndex(
                name: "IX_AreaAtuacao_IdtUser",
                table: "AreaAtuacao",
                newName: "IX_AreaAtuacao_IdInsertUser");

            migrationBuilder.AddForeignKey(
                name: "FK_AreaAtuacao_AspNetUsers_IdInsertUser",
                table: "AreaAtuacao",
                column: "IdInsertUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Situacao_AspNetUsers_IdInsertUser",
                table: "Situacao",
                column: "IdInsertUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
