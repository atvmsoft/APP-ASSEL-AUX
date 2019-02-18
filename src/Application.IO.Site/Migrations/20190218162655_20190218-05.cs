using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Application.IO.Site.Migrations
{
    public partial class _2019021805 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Situacao_IdtUser",
                table: "Situacao",
                newName: "IX_Situacao_IdUser");

            migrationBuilder.RenameColumn(
                name: "IdtUser",
                table: "AreaAtuacao",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_AreaAtuacao_IdtUser",
                table: "AreaAtuacao",
                newName: "IX_AreaAtuacao_IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_AreaAtuacao_AspNetUsers_IdUser",
                table: "AreaAtuacao",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Situacao_AspNetUsers_IdUser",
                table: "Situacao",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreaAtuacao_AspNetUsers_IdUser",
                table: "AreaAtuacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Situacao_AspNetUsers_IdUser",
                table: "Situacao");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Situacao",
                newName: "IdtUser");

            migrationBuilder.RenameIndex(
                name: "IX_Situacao_IdUser",
                table: "Situacao",
                newName: "IX_Situacao_IdtUser");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "AreaAtuacao",
                newName: "IdtUser");

            migrationBuilder.RenameIndex(
                name: "IX_AreaAtuacao_IdUser",
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
    }
}
