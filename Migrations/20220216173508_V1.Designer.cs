// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace Projekat.Migrations
{
    [DbContext(typeof(FudbalskiKlubContext))]
    [Migration("20220216173508_V1")]
    partial class V1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Igrac", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojDresa")
                        .HasColumnType("int");

                    b.Property<int>("BrojGodina")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Kvalitet")
                        .HasColumnType("int");

                    b.Property<int?>("NacionalnostID")
                        .HasColumnType("int");

                    b.Property<int?>("PozicijaID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("TimID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("NacionalnostID");

                    b.HasIndex("PozicijaID");

                    b.HasIndex("TimID");

                    b.ToTable("Igraci");
                });

            modelBuilder.Entity("Models.Menadzer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojGodina")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("TimID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TimID");

                    b.ToTable("Menadzeri");
                });

            modelBuilder.Entity("Models.Nacionalnost", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Drzavljanstvo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Nacionalnosti");
                });

            modelBuilder.Entity("Models.Pozicija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("Pozicije");
                });

            modelBuilder.Entity("Models.TimFC", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Kvalitet")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Timovi");
                });

            modelBuilder.Entity("Models.Igrac", b =>
                {
                    b.HasOne("Models.Nacionalnost", "Nacionalnost")
                        .WithMany()
                        .HasForeignKey("NacionalnostID");

                    b.HasOne("Models.Pozicija", "Pozicija")
                        .WithMany()
                        .HasForeignKey("PozicijaID");

                    b.HasOne("Models.TimFC", "Tim")
                        .WithMany("Igraci")
                        .HasForeignKey("TimID");

                    b.Navigation("Nacionalnost");

                    b.Navigation("Pozicija");

                    b.Navigation("Tim");
                });

            modelBuilder.Entity("Models.Menadzer", b =>
                {
                    b.HasOne("Models.TimFC", "Tim")
                        .WithMany()
                        .HasForeignKey("TimID");

                    b.Navigation("Tim");
                });

            modelBuilder.Entity("Models.TimFC", b =>
                {
                    b.Navigation("Igraci");
                });
#pragma warning restore 612, 618
        }
    }
}
