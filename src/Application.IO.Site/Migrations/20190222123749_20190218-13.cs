using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Application.IO.Site.Migrations
{
    public partial class _2019021813 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvogadoAreaAtuacao_AspNetUsers_IdInsertUser",
                table: "AdvogadoAreaAtuacao");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvogadoSituacao_AspNetUsers_IdInsertUser",
                table: "AdvogadoSituacao");

            migrationBuilder.RenameColumn(
                name: "IdInsertUser",
                table: "AdvogadoSituacao",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_AdvogadoSituacao_IdInsertUser",
                table: "AdvogadoSituacao",
                newName: "IX_AdvogadoSituacao_IdUser");

            migrationBuilder.RenameColumn(
                name: "IdInsertUser",
                table: "AdvogadoAreaAtuacao",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_AdvogadoAreaAtuacao_IdInsertUser",
                table: "AdvogadoAreaAtuacao",
                newName: "IX_AdvogadoAreaAtuacao_IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvogadoAreaAtuacao_AspNetUsers_IdUser",
                table: "AdvogadoAreaAtuacao",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvogadoSituacao_AspNetUsers_IdUser",
                table: "AdvogadoSituacao",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvogadoAreaAtuacao_AspNetUsers_IdUser",
                table: "AdvogadoAreaAtuacao");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvogadoSituacao_AspNetUsers_IdUser",
                table: "AdvogadoSituacao");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "AdvogadoSituacao",
                newName: "IdInsertUser");

            migrationBuilder.RenameIndex(
                name: "IX_AdvogadoSituacao_IdUser",
                table: "AdvogadoSituacao",
                newName: "IX_AdvogadoSituacao_IdInsertUser");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "AdvogadoAreaAtuacao",
                newName: "IdInsertUser");

            migrationBuilder.RenameIndex(
                name: "IX_AdvogadoAreaAtuacao_IdUser",
                table: "AdvogadoAreaAtuacao",
                newName: "IX_AdvogadoAreaAtuacao_IdInsertUser");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvogadoAreaAtuacao_AspNetUsers_IdInsertUser",
                table: "AdvogadoAreaAtuacao",
                column: "IdInsertUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvogadoSituacao_AspNetUsers_IdInsertUser",
                table: "AdvogadoSituacao",
                column: "IdInsertUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
