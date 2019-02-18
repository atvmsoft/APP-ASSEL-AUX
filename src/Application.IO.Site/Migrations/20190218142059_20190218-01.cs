using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Application.IO.Site.Migrations
{
    public partial class _2019021801 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LogicalDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    NumDocument = table.Column<string>(maxLength: 40, nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserEmailConfirm = table.Column<DateTime>(nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeoEstado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(20)", nullable: false),
                    Sigla = table.Column<string>(type: "varchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoEstado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AreaAtuacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateInsert = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdInsertUser = table.Column<Guid>(nullable: false),
                    LogicalDelete = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaAtuacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreaAtuacao_AspNetUsers_IdInsertUser",
                        column: x => x.IdInsertUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeoCep",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bairro = table.Column<string>(type: "varchar(150)", nullable: true),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(8)", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "datetime", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(300)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(20)", nullable: false),
                    IdInsertUser = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoCep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeoCep_AspNetUsers_IdInsertUser",
                        column: x => x.IdInsertUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Situacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateInsert = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdInsertUser = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Situacao_AspNetUsers_IdInsertUser",
                        column: x => x.IdInsertUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoContato",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateInsert = table.Column<DateTime>(type: "datetime", nullable: false),
                    Formato = table.Column<string>(type: "varchar(20)", nullable: true),
                    IdInsertUser = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoContato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoContato_AspNetUsers_IdInsertUser",
                        column: x => x.IdInsertUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoEndereco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateInsert = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdInsertUser = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEndereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoEndereco_AspNetUsers_IdInsertUser",
                        column: x => x.IdInsertUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GeoCidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdGeoEstado = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoCidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeoCidade_GeoEstado_IdGeoEstado",
                        column: x => x.IdGeoEstado,
                        principalTable: "GeoEstado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Advogado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAtualizacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateInscricaoOAB = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdGeoCidade = table.Column<int>(nullable: false),
                    IdInsertUser = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    NomeMae = table.Column<string>(type: "varchar(100)", nullable: true),
                    NomePai = table.Column<string>(type: "varchar(100)", nullable: true),
                    NumOrdem = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advogado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advogado_GeoCidade_IdGeoCidade",
                        column: x => x.IdGeoCidade,
                        principalTable: "GeoCidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Advogado_AspNetUsers_IdInsertUser",
                        column: x => x.IdInsertUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdvogadoAreaAtuacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateInsert = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdAdvogado = table.Column<int>(nullable: false),
                    IdAreaAtuacao = table.Column<int>(nullable: false),
                    IdInsertUser = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvogadoAreaAtuacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvogadoAreaAtuacao_Advogado_IdAdvogado",
                        column: x => x.IdAdvogado,
                        principalTable: "Advogado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvogadoAreaAtuacao_AreaAtuacao_IdAreaAtuacao",
                        column: x => x.IdAreaAtuacao,
                        principalTable: "AreaAtuacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvogadoAreaAtuacao_AspNetUsers_IdInsertUser",
                        column: x => x.IdInsertUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdvogadoContato",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Contato = table.Column<string>(type: "varchar(100)", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdAdvogado = table.Column<int>(nullable: false),
                    IdInsertUser = table.Column<Guid>(nullable: false),
                    IdTipoContato = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvogadoContato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvogadoContato_Advogado_IdAdvogado",
                        column: x => x.IdAdvogado,
                        principalTable: "Advogado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvogadoContato_AspNetUsers_IdInsertUser",
                        column: x => x.IdInsertUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvogadoContato_TipoContato_IdTipoContato",
                        column: x => x.IdTipoContato,
                        principalTable: "TipoContato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdvogadoEndereco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Complemento = table.Column<string>(type: "varchar(50)", nullable: true),
                    DateInsert = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdAdvogado = table.Column<int>(nullable: false),
                    IdGeoCep = table.Column<int>(nullable: false),
                    IdInsertUser = table.Column<Guid>(nullable: false),
                    IdTipoEndereco = table.Column<int>(nullable: false),
                    Numero = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvogadoEndereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvogadoEndereco_Advogado_IdAdvogado",
                        column: x => x.IdAdvogado,
                        principalTable: "Advogado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvogadoEndereco_GeoCep_IdGeoCep",
                        column: x => x.IdGeoCep,
                        principalTable: "GeoCep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvogadoEndereco_AspNetUsers_IdInsertUser",
                        column: x => x.IdInsertUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvogadoEndereco_TipoEndereco_IdTipoEndereco",
                        column: x => x.IdTipoEndereco,
                        principalTable: "TipoEndereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdvogadoSituacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateInsert = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdAdvogado = table.Column<int>(nullable: false),
                    IdInsertUser = table.Column<Guid>(nullable: false),
                    IdSituacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvogadoSituacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvogadoSituacao_Advogado_IdAdvogado",
                        column: x => x.IdAdvogado,
                        principalTable: "Advogado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvogadoSituacao_AspNetUsers_IdInsertUser",
                        column: x => x.IdInsertUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvogadoSituacao_Situacao_IdSituacao",
                        column: x => x.IdSituacao,
                        principalTable: "Situacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advogado_IdGeoCidade",
                table: "Advogado",
                column: "IdGeoCidade");

            migrationBuilder.CreateIndex(
                name: "IX_Advogado_IdInsertUser",
                table: "Advogado",
                column: "IdInsertUser");

            migrationBuilder.CreateIndex(
                name: "IX_AdvogadoAreaAtuacao_IdAdvogado",
                table: "AdvogadoAreaAtuacao",
                column: "IdAdvogado");

            migrationBuilder.CreateIndex(
                name: "IX_AdvogadoAreaAtuacao_IdAreaAtuacao",
                table: "AdvogadoAreaAtuacao",
                column: "IdAreaAtuacao");

            migrationBuilder.CreateIndex(
                name: "IX_AdvogadoAreaAtuacao_IdInsertUser",
                table: "AdvogadoAreaAtuacao",
                column: "IdInsertUser");

            migrationBuilder.CreateIndex(
                name: "IX_AdvogadoContato_IdAdvogado",
                table: "AdvogadoContato",
                column: "IdAdvogado");

            migrationBuilder.CreateIndex(
                name: "IX_AdvogadoContato_IdInsertUser",
                table: "AdvogadoContato",
                column: "IdInsertUser");

            migrationBuilder.CreateIndex(
                name: "IX_AdvogadoContato_IdTipoContato",
                table: "AdvogadoContato",
                column: "IdTipoContato");

            migrationBuilder.CreateIndex(
                name: "IX_AdvogadoEndereco_IdAdvogado",
                table: "AdvogadoEndereco",
                column: "IdAdvogado");

            migrationBuilder.CreateIndex(
                name: "IX_AdvogadoEndereco_IdGeoCep",
                table: "AdvogadoEndereco",
                column: "IdGeoCep");

            migrationBuilder.CreateIndex(
                name: "IX_AdvogadoEndereco_IdInsertUser",
                table: "AdvogadoEndereco",
                column: "IdInsertUser");

            migrationBuilder.CreateIndex(
                name: "IX_AdvogadoEndereco_IdTipoEndereco",
                table: "AdvogadoEndereco",
                column: "IdTipoEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_AdvogadoSituacao_IdAdvogado",
                table: "AdvogadoSituacao",
                column: "IdAdvogado");

            migrationBuilder.CreateIndex(
                name: "IX_AdvogadoSituacao_IdInsertUser",
                table: "AdvogadoSituacao",
                column: "IdInsertUser");

            migrationBuilder.CreateIndex(
                name: "IX_AdvogadoSituacao_IdSituacao",
                table: "AdvogadoSituacao",
                column: "IdSituacao");

            migrationBuilder.CreateIndex(
                name: "IX_AreaAtuacao_IdInsertUser",
                table: "AreaAtuacao",
                column: "IdInsertUser");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GeoCep_IdInsertUser",
                table: "GeoCep",
                column: "IdInsertUser");

            migrationBuilder.CreateIndex(
                name: "IX_GeoCidade_IdGeoEstado",
                table: "GeoCidade",
                column: "IdGeoEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Situacao_IdInsertUser",
                table: "Situacao",
                column: "IdInsertUser");

            migrationBuilder.CreateIndex(
                name: "IX_TipoContato_IdInsertUser",
                table: "TipoContato",
                column: "IdInsertUser");

            migrationBuilder.CreateIndex(
                name: "IX_TipoEndereco_IdInsertUser",
                table: "TipoEndereco",
                column: "IdInsertUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvogadoAreaAtuacao");

            migrationBuilder.DropTable(
                name: "AdvogadoContato");

            migrationBuilder.DropTable(
                name: "AdvogadoEndereco");

            migrationBuilder.DropTable(
                name: "AdvogadoSituacao");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AreaAtuacao");

            migrationBuilder.DropTable(
                name: "TipoContato");

            migrationBuilder.DropTable(
                name: "GeoCep");

            migrationBuilder.DropTable(
                name: "TipoEndereco");

            migrationBuilder.DropTable(
                name: "Advogado");

            migrationBuilder.DropTable(
                name: "Situacao");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "GeoCidade");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "GeoEstado");
        }
    }
}
