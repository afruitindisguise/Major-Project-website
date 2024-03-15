﻿// <auto-generated />
using Major_Project.repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Major_project.Migrations
{
    [DbContext(typeof(PlayerDbContext))]
    partial class PlayerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataPlayer", b =>
                {
                    b.Property<int>("DatasId")
                        .HasColumnType("int");

                    b.Property<int>("PlayersId")
                        .HasColumnType("int");

                    b.HasKey("DatasId", "PlayersId");

                    b.HasIndex("PlayersId");

                    b.ToTable("DataPlayer");
                });

            modelBuilder.Entity("ItemPlayer", b =>
                {
                    b.Property<int>("itemsId")
                        .HasColumnType("int");

                    b.Property<int>("playersId")
                        .HasColumnType("int");

                    b.HasKey("itemsId", "playersId");

                    b.HasIndex("playersId");

                    b.ToTable("ItemPlayer");
                });

            modelBuilder.Entity("Major_Project.models.Data", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AR")
                        .HasColumnType("int");

                    b.Property<int>("HP")
                        .HasColumnType("int");

                    b.Property<int>("MP")
                        .HasColumnType("int");

                    b.Property<int>("cordsx")
                        .HasColumnType("int");

                    b.Property<int>("cordsy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Datas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AR = 0,
                            HP = 100,
                            MP = 100,
                            cordsx = 0,
                            cordsy = 0
                        });
                });

            modelBuilder.Entity("Major_Project.models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Major_Project.models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(6)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Major_Project.models.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(6)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ScoreAmount")
                        .HasColumnType("int");

                    b.Property<string>("Scores")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("Major_Project.models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("applied")
                        .HasColumnType("bit");

                    b.Property<int>("dmgPturn")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("PlayerScore", b =>
                {
                    b.Property<int>("PlayersId")
                        .HasColumnType("int");

                    b.Property<int>("ScoresId")
                        .HasColumnType("int");

                    b.HasKey("PlayersId", "ScoresId");

                    b.HasIndex("ScoresId");

                    b.ToTable("PlayerScore");
                });

            modelBuilder.Entity("PlayerStatus", b =>
                {
                    b.Property<int>("StatusesId")
                        .HasColumnType("int");

                    b.Property<int>("playersId")
                        .HasColumnType("int");

                    b.HasKey("StatusesId", "playersId");

                    b.HasIndex("playersId");

                    b.ToTable("PlayerStatus");
                });

            modelBuilder.Entity("DataPlayer", b =>
                {
                    b.HasOne("Major_Project.models.Data", null)
                        .WithMany()
                        .HasForeignKey("DatasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Major_Project.models.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ItemPlayer", b =>
                {
                    b.HasOne("Major_Project.models.Item", null)
                        .WithMany()
                        .HasForeignKey("itemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Major_Project.models.Player", null)
                        .WithMany()
                        .HasForeignKey("playersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlayerScore", b =>
                {
                    b.HasOne("Major_Project.models.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Major_Project.models.Score", null)
                        .WithMany()
                        .HasForeignKey("ScoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlayerStatus", b =>
                {
                    b.HasOne("Major_Project.models.Status", null)
                        .WithMany()
                        .HasForeignKey("StatusesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Major_Project.models.Player", null)
                        .WithMany()
                        .HasForeignKey("playersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
