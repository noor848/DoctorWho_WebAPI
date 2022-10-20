﻿// <auto-generated />
using System;
using EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoctrWho.Db.Migrations
{
    [DbContext(typeof(DoctorWhoContext))]
    [Migration("20220924162921_creatTables")]
    partial class creatTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CompanionEpisod", b =>
                {
                    b.Property<int>("CompanionId")
                        .HasColumnType("int");

                    b.Property<int>("EpisodId")
                        .HasColumnType("int");

                    b.HasKey("CompanionId", "EpisodId");

                    b.HasIndex("EpisodId");

                    b.ToTable("CompanionEpisod");
                });

            modelBuilder.Entity("DoctorWho.Db.CompanionEpisod", b =>
                {
                    b.Property<int>("EpisodId")
                        .HasColumnType("int");

                    b.Property<int>("CompanionId")
                        .HasColumnType("int");

                    b.HasKey("EpisodId", "CompanionId");

                    b.ToTable("CompanionEpisods");
                });

            modelBuilder.Entity("DoctorWho.Db.DoctorView", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoctorNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DoctorViews");
                });

            modelBuilder.Entity("DoctorWho.Db.EnemyEpisod", b =>
                {
                    b.Property<int>("EpisodId")
                        .HasColumnType("int");

                    b.Property<int>("EnemyId")
                        .HasColumnType("int");

                    b.HasKey("EpisodId", "EnemyId");

                    b.ToTable("EnemyEpisods");
                });

            modelBuilder.Entity("EfDoctorWho.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("EfDoctorWho.Companion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ComapnionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhoPlayed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companions");
                });

            modelBuilder.Entity("EfDoctorWho.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoctorNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("FirstEpisodDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastEpisodDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("EfDoctorWho.Enemy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnemyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Enemys");
                });

            modelBuilder.Entity("EfDoctorWho.Episod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EpisodDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EpisodNumber")
                        .HasColumnType("int");

                    b.Property<string>("EpisodType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeriesNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("Episods");
                });

            modelBuilder.Entity("EnemyEpisod", b =>
                {
                    b.Property<int>("EnemyId")
                        .HasColumnType("int");

                    b.Property<int>("EpisodId")
                        .HasColumnType("int");

                    b.HasKey("EnemyId", "EpisodId");

                    b.HasIndex("EpisodId");

                    b.ToTable("EnemyEpisod");
                });

            modelBuilder.Entity("CompanionEpisod", b =>
                {
                    b.HasOne("EfDoctorWho.Companion", null)
                        .WithMany()
                        .HasForeignKey("CompanionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfDoctorWho.Episod", null)
                        .WithMany()
                        .HasForeignKey("EpisodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EfDoctorWho.Episod", b =>
                {
                    b.HasOne("EfDoctorWho.Author", null)
                        .WithMany("Episod")
                        .HasForeignKey("AuthorId");

                    b.HasOne("EfDoctorWho.Doctor", null)
                        .WithMany("Episod")
                        .HasForeignKey("DoctorId");
                });

            modelBuilder.Entity("EnemyEpisod", b =>
                {
                    b.HasOne("EfDoctorWho.Enemy", null)
                        .WithMany()
                        .HasForeignKey("EnemyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfDoctorWho.Episod", null)
                        .WithMany()
                        .HasForeignKey("EpisodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EfDoctorWho.Author", b =>
                {
                    b.Navigation("Episod");
                });

            modelBuilder.Entity("EfDoctorWho.Doctor", b =>
                {
                    b.Navigation("Episod");
                });
#pragma warning restore 612, 618
        }
    }
}
