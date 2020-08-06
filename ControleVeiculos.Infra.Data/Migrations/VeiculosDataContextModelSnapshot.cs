﻿// <auto-generated />
using System;
using ControleVeiculos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ControleVeiculos.Infra.Data.Migrations
{
    [DbContext(typeof(VeiculosDataContext))]
    partial class VeiculosDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ControleVeiculos.Domain.Entities.Abastecimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Combustivel")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataAbastecimento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("KmAbastecimento")
                        .HasColumnType("numeric");

                    b.Property<decimal>("LitrosAbastecidos")
                        .HasColumnType("numeric");

                    b.Property<string>("PostoAbastecido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ValorPago")
                        .HasColumnType("numeric");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Abastecimentos");
                });

            modelBuilder.Entity("ControleVeiculos.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ControleVeiculos.Domain.Entities.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Ano")
                        .HasColumnType("integer");

                    b.Property<int>("Combustivel")
                        .HasColumnType("integer");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("bytea");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Quilometragem")
                        .HasColumnType("numeric");

                    b.Property<int>("Tipo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("ControleVeiculos.Domain.Entities.Abastecimento", b =>
                {
                    b.HasOne("ControleVeiculos.Domain.Entities.Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
