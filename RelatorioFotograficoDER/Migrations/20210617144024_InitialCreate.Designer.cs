// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RelatorioFotograficoDER.Data;

namespace RelatorioFotograficoDER.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210617144024_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RelatorioFotograficoDER.Models.Coordenacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataEnvio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrcamentoeletronicoId")
                        .HasColumnType("int");

                    b.Property<int>("RelacaoOrcamentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Coordenacaos");
                });

            modelBuilder.Entity("RelatorioFotograficoDER.Models.OrcamentoEletronico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Empresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PdfAnexoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PdfAnexoId");

                    b.ToTable("OrcamentoEletronicos");
                });

            modelBuilder.Entity("RelatorioFotograficoDER.Models.PdfAnexo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caminho")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PdfAnexos");
                });

            modelBuilder.Entity("RelatorioFotograficoDER.Models.ProcessoManutencao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoordenacaoId")
                        .HasColumnType("int");

                    b.Property<int>("RelatorioAtesteId")
                        .HasColumnType("int");

                    b.Property<int>("RelatoriofotograficoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProcessoManutencaos");
                });

            modelBuilder.Entity("RelatorioFotograficoDER.Models.RelacaoOrcamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Empresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PdfAnexoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PdfAnexoId");

                    b.ToTable("RelacaoOrcamentos");
                });

            modelBuilder.Entity("RelatorioFotograficoDER.Models.RelatorioAteste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAprovacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Empresa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RelatorioAtestes");
                });

            modelBuilder.Entity("RelatorioFotograficoDER.Models.RelatorioAtesteAnexo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caminho")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RelatorioAtesteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RelatorioAtesteAnexos");
                });

            modelBuilder.Entity("RelatorioFotograficoDER.Models.RelatorioFotografico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<string>("Cartao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataEnvio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kmh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Matricula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumOrcamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patrimonio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Responsavel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Setor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Veiculo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RelatorioFotograficos");
                });

            modelBuilder.Entity("RelatorioFotograficoDER.Models.RelatorioFotograficoAnexo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caminho")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RelatorioAtesteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RelatorioFotograficoAnexos");
                });

            modelBuilder.Entity("RelatorioFotograficoDER.Models.OrcamentoEletronico", b =>
                {
                    b.HasOne("RelatorioFotograficoDER.Models.PdfAnexo", "PdfAnexo")
                        .WithMany()
                        .HasForeignKey("PdfAnexoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PdfAnexo");
                });

            modelBuilder.Entity("RelatorioFotograficoDER.Models.RelacaoOrcamento", b =>
                {
                    b.HasOne("RelatorioFotograficoDER.Models.PdfAnexo", "PdfAnexo")
                        .WithMany()
                        .HasForeignKey("PdfAnexoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PdfAnexo");
                });
#pragma warning restore 612, 618
        }
    }
}
