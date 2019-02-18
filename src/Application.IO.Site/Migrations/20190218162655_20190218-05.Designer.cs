﻿// <auto-generated />
using Application.IO.Site.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Application.IO.Site.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190218162655_20190218-05")]
    partial class _2019021805
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Application.IO.Site.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<bool>("LogicalDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("NumDocument")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<DateTime?>("UserEmailConfirm");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Application.IO.Site.Models.Domain.Advogado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateAtualizacao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateInscricaoOAB")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateInsert")
                        .HasColumnType("datetime");

                    b.Property<int>("IdGeoCidade");

                    b.Property<Guid>("IdInsertUser");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NomeMae")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NomePai")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NumOrdem")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("IdGeoCidade");

                    b.HasIndex("IdInsertUser");

                    b.ToTable("Advogado");
                });

            modelBuilder.Entity("Application.IO.Site.Models.Domain.AdvogadoAreaAtuacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateInsert")
                        .HasColumnType("datetime");

                    b.Property<int>("IdAdvogado");

                    b.Property<int>("IdAreaAtuacao");

                    b.Property<Guid>("IdInsertUser");

                    b.HasKey("Id");

                    b.HasIndex("IdAdvogado");

                    b.HasIndex("IdAreaAtuacao");

                    b.HasIndex("IdInsertUser");

                    b.ToTable("AdvogadoAreaAtuacao");
                });

            modelBuilder.Entity("Application.IO.Site.Models.Domain.AdvogadoContato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Contato")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("DateInsert")
                        .HasColumnType("datetime");

                    b.Property<int>("IdAdvogado");

                    b.Property<Guid>("IdInsertUser");

                    b.Property<int>("IdTipoContato");

                    b.HasKey("Id");

                    b.HasIndex("IdAdvogado");

                    b.HasIndex("IdInsertUser");

                    b.HasIndex("IdTipoContato");

                    b.ToTable("AdvogadoContato");
                });

            modelBuilder.Entity("Application.IO.Site.Models.Domain.AdvogadoEndereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("DateInsert")
                        .HasColumnType("datetime");

                    b.Property<int>("IdAdvogado");

                    b.Property<int>("IdGeoCep");

                    b.Property<Guid>("IdInsertUser");

                    b.Property<int>("IdTipoEndereco");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("IdAdvogado");

                    b.HasIndex("IdGeoCep");

                    b.HasIndex("IdInsertUser");

                    b.HasIndex("IdTipoEndereco");

                    b.ToTable("AdvogadoEndereco");
                });

            modelBuilder.Entity("Application.IO.Site.Models.Domain.AdvogadoSituacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateInsert")
                        .HasColumnType("datetime");

                    b.Property<int>("IdAdvogado");

                    b.Property<Guid>("IdInsertUser");

                    b.Property<int>("IdSituacao");

                    b.HasKey("Id");

                    b.HasIndex("IdAdvogado");

                    b.HasIndex("IdInsertUser");

                    b.HasIndex("IdSituacao");

                    b.ToTable("AdvogadoSituacao");
                });

            modelBuilder.Entity("Application.IO.Site.Models.Domain.AreaAtuacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<Guid>("IdUser");

                    b.Property<bool>("LogicalDelete");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("AreaAtuacao");
                });

            modelBuilder.Entity("Application.IO.Site.Models.Domain.GeoCep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<DateTime>("DateInsert")
                        .HasColumnType("datetime");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<Guid>("IdInsertUser");

                    b.HasKey("Id");

                    b.HasIndex("IdInsertUser");

                    b.ToTable("GeoCep");
                });

            modelBuilder.Entity("Application.IO.Site.Models.Domain.GeoCidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdGeoEstado");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("IdGeoEstado");

                    b.ToTable("GeoCidade");
                });

            modelBuilder.Entity("Application.IO.Site.Models.Domain.GeoEstado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.HasKey("Id");

                    b.ToTable("GeoEstado");
                });

            modelBuilder.Entity("Application.IO.Site.Models.Domain.Situacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<Guid>("IdUser");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Situacao");
                });

            modelBuilder.Entity("Application.IO.Site.Models.Domain.TipoContato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateInsert")
                        .HasColumnType("datetime");

                    b.Property<string>("Formato")
                        .HasColumnType("varchar(20)");

                    b.Property<Guid>("IdInsertUser");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdInsertUser");

                    b.ToTable("TipoContato");
                });

            modelBuilder.Entity("Application.IO.Site.Models.Domain.TipoEndereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateInsert")
                        .HasColumnType("datetime");

                    b.Property<Guid>("IdInsertUser");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdInsertUser");

                    b.ToTable("TipoEndereco");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Application.IO.Site.Models.Domain.Advogado", b =>
                {
                    b.HasOne("Application.IO.Site.Models.Domain.GeoCidade", "GeoCidade")
                        .WithMany("Advogado")
                        .HasForeignKey("IdGeoCidade")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Application.IO.Site.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("AdvogadoInsert")
                        .HasForeignKey("IdInsertUser")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Application.IO.Site.Models.Domain.AdvogadoAreaAtuacao", b =>
                {
                    b.HasOne("Application.IO.Site.Models.Domain.Advogado", "Advogado")
                        .WithMany("AdvogadoAreaAtuacao")
                        .HasForeignKey("IdAdvogado")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Application.IO.Site.Models.Domain.AreaAtuacao", "AreaAtuacao")
                        .WithMany("AdvogadoAreaAtuacao")
                        .HasForeignKey("IdAreaAtuacao")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Application.IO.Site.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("AdvogadoAreaAtuacao")
                        .HasForeignKey("IdInsertUser")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Application.IO.Site.Models.Domain.AdvogadoContato", b =>
                {
                    b.HasOne("Application.IO.Site.Models.Domain.Advogado", "Advogado")
                        .WithMany("AdvogadoContato")
                        .HasForeignKey("IdAdvogado")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Application.IO.Site.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("AdvogadoContato")
                        .HasForeignKey("IdInsertUser")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Application.IO.Site.Models.Domain.TipoContato", "TipoContato")
                        .WithMany("AdvogadoContato")
                        .HasForeignKey("IdTipoContato")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Application.IO.Site.Models.Domain.AdvogadoEndereco", b =>
                {
                    b.HasOne("Application.IO.Site.Models.Domain.Advogado", "Advogado")
                        .WithMany("AdvogadoEndereco")
                        .HasForeignKey("IdAdvogado")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Application.IO.Site.Models.Domain.GeoCep", "GeoCep")
                        .WithMany("AdvogadoEndereco")
                        .HasForeignKey("IdGeoCep")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Application.IO.Site.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("AdvogadoEndereco")
                        .HasForeignKey("IdInsertUser")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Application.IO.Site.Models.Domain.TipoEndereco", "TipoEndereco")
                        .WithMany("AdvogadoEndereco")
                        .HasForeignKey("IdTipoEndereco")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Application.IO.Site.Models.Domain.AdvogadoSituacao", b =>
                {
                    b.HasOne("Application.IO.Site.Models.Domain.Advogado", "Advogado")
                        .WithMany("AdvogadoSituacao")
                        .HasForeignKey("IdAdvogado")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Application.IO.Site.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("AdvogadoSituacao")
                        .HasForeignKey("IdInsertUser")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Application.IO.Site.Models.Domain.Situacao", "Situacao")
                        .WithMany("AdvogadoSituacao")
                        .HasForeignKey("IdSituacao")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Application.IO.Site.Models.Domain.AreaAtuacao", b =>
                {
                    b.HasOne("Application.IO.Site.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("AreaAtuacao")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Application.IO.Site.Models.Domain.GeoCep", b =>
                {
                    b.HasOne("Application.IO.Site.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("GeoCep")
                        .HasForeignKey("IdInsertUser")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Application.IO.Site.Models.Domain.GeoCidade", b =>
                {
                    b.HasOne("Application.IO.Site.Models.Domain.GeoEstado", "GeoEstado")
                        .WithMany("GeoCidade")
                        .HasForeignKey("IdGeoEstado")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Application.IO.Site.Models.Domain.Situacao", b =>
                {
                    b.HasOne("Application.IO.Site.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Situacao")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Application.IO.Site.Models.Domain.TipoContato", b =>
                {
                    b.HasOne("Application.IO.Site.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("TipoContato")
                        .HasForeignKey("IdInsertUser")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Application.IO.Site.Models.Domain.TipoEndereco", b =>
                {
                    b.HasOne("Application.IO.Site.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("TipoEndereco")
                        .HasForeignKey("IdInsertUser")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Application.IO.Site.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Application.IO.Site.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Application.IO.Site.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Application.IO.Site.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
