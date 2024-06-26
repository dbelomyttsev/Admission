﻿// <auto-generated />
using System;
using Admission.BDHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ApplicationContext = Admission.BDHelper.ApplicationContext;

#nullable disable

namespace Admission.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Admission.BusinessLogic.Abiturient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Education")
                        .HasColumnType("integer");

                    b.Property<string>("EducationalInstitution")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("File")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullNameParent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NumberPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Passport")
                        .HasColumnType("integer");

                    b.Property<int>("Points")
                        .HasColumnType("integer");

                    b.Property<int>("Snils")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Abiturients");
                });

            modelBuilder.Entity("Admission.BusinessLogic.AbiturientDirection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AbiturientId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DirectionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AbiturientId");

                    b.HasIndex("DirectionId");

                    b.ToTable("AbiturientDirections");
                });

            modelBuilder.Entity("Admission.BusinessLogic.Direction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Education")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Directions");
                });

            modelBuilder.Entity("Admission.BusinessLogic.Request", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AbiturientId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AbiturientId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Admission.BusinessLogic.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Admission.BusinessLogic.Abiturient", b =>
                {
                    b.HasOne("Admission.BusinessLogic.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Admission.BusinessLogic.AbiturientDirection", b =>
                {
                    b.HasOne("Admission.BusinessLogic.Abiturient", "Abiturient")
                        .WithMany("Directions")
                        .HasForeignKey("AbiturientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Admission.BusinessLogic.Direction", "Direction")
                        .WithMany()
                        .HasForeignKey("DirectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Abiturient");

                    b.Navigation("Direction");
                });

            modelBuilder.Entity("Admission.BusinessLogic.Request", b =>
                {
                    b.HasOne("Admission.BusinessLogic.Abiturient", "Abiturient")
                        .WithMany()
                        .HasForeignKey("AbiturientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Abiturient");
                });

            modelBuilder.Entity("Admission.BusinessLogic.Abiturient", b =>
                {
                    b.Navigation("Directions");
                });
#pragma warning restore 612, 618
        }
    }
}
