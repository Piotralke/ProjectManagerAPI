﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjectManagerAPI.Data;

#nullable disable

namespace ProjectManagerAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProjectManagerAPI.Models.Project", b =>
                {
                    b.Property<Guid>("uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("gitLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isPrivate")
                        .HasColumnType("boolean");

                    b.Property<Guid>("ownerUuid")
                        .HasColumnType("uuid");

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("uuid");

                    b.HasIndex("ownerUuid")
                        .IsUnique();

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.ProjectEvents", b =>
                {
                    b.Property<Guid>("uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("dueTo")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("projectUuid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("startTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("uuid");

                    b.HasIndex("projectUuid");

                    b.ToTable("ProjectEvents");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.ProjectMembers", b =>
                {
                    b.Property<Guid>("uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("projectUuid")
                        .HasColumnType("uuid");

                    b.Property<Guid>("userUuid")
                        .HasColumnType("uuid");

                    b.HasKey("uuid");

                    b.HasIndex("projectUuid");

                    b.HasIndex("userUuid");

                    b.ToTable("ProjectMembers");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.User", b =>
                {
                    b.Property<Guid>("uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("role")
                        .HasColumnType("integer");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("uuid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.UserEvents", b =>
                {
                    b.Property<Guid>("uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserEventsuuid")
                        .HasColumnType("uuid");

                    b.Property<Guid>("eventUuid")
                        .HasColumnType("uuid");

                    b.Property<Guid>("userUuid")
                        .HasColumnType("uuid");

                    b.HasKey("uuid");

                    b.HasIndex("UserEventsuuid");

                    b.HasIndex("eventUuid");

                    b.HasIndex("userUuid");

                    b.ToTable("UserEvents");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.Project", b =>
                {
                    b.HasOne("ProjectManagerAPI.Models.User", "owner")
                        .WithOne("project")
                        .HasForeignKey("ProjectManagerAPI.Models.Project", "ownerUuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("owner");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.ProjectEvents", b =>
                {
                    b.HasOne("ProjectManagerAPI.Models.Project", "project")
                        .WithMany("events")
                        .HasForeignKey("projectUuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("project");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.ProjectMembers", b =>
                {
                    b.HasOne("ProjectManagerAPI.Models.Project", "project")
                        .WithMany("members")
                        .HasForeignKey("projectUuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectManagerAPI.Models.User", "user")
                        .WithMany("members")
                        .HasForeignKey("userUuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("project");

                    b.Navigation("user");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.UserEvents", b =>
                {
                    b.HasOne("ProjectManagerAPI.Models.UserEvents", null)
                        .WithMany("events")
                        .HasForeignKey("UserEventsuuid");

                    b.HasOne("ProjectManagerAPI.Models.ProjectEvents", "projectEvents")
                        .WithMany("userEvents")
                        .HasForeignKey("eventUuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectManagerAPI.Models.User", "user")
                        .WithMany("events")
                        .HasForeignKey("userUuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("projectEvents");

                    b.Navigation("user");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.Project", b =>
                {
                    b.Navigation("events");

                    b.Navigation("members");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.ProjectEvents", b =>
                {
                    b.Navigation("userEvents");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.User", b =>
                {
                    b.Navigation("events");

                    b.Navigation("members");

                    b.Navigation("project");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.UserEvents", b =>
                {
                    b.Navigation("events");
                });
#pragma warning restore 612, 618
        }
    }
}
