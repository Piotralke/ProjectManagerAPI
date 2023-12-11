﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjectManagerAPI.Data;

#nullable disable

namespace ProjectManagerAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231210120553_nullableStartTime")]
    partial class nullableStartTime
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.GanntPreviousTask", b =>
                {
                    b.Property<Guid>("uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("previousTaskId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("taskId")
                        .HasColumnType("uuid");

                    b.HasKey("uuid");

                    b.HasIndex("previousTaskId");

                    b.HasIndex("taskId");

                    b.ToTable("GanntPreviousTasks");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.GanntTasks", b =>
                {
                    b.Property<Guid>("uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("projectUuid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("uuid");

                    b.HasIndex("projectUuid");

                    b.ToTable("GanntTasks");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.Message", b =>
                {
                    b.Property<Guid>("uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("hasAttachment")
                        .HasColumnType("boolean");

                    b.Property<Guid>("projectUuid")
                        .HasColumnType("uuid");

                    b.Property<Guid>("senderUuid")
                        .HasColumnType("uuid");

                    b.HasKey("uuid");

                    b.HasIndex("UserId");

                    b.HasIndex("projectUuid");

                    b.HasIndex("senderUuid")
                        .IsUnique();

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.MessageAttachment", b =>
                {
                    b.Property<Guid>("uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("fileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("filePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("fileType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("messageUuid")
                        .HasColumnType("uuid");

                    b.HasKey("uuid");

                    b.HasIndex("messageUuid");

                    b.ToTable("MessageAttachments");
                });

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

                    b.HasIndex("ownerUuid");

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

                    b.Property<DateTime?>("startTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("type")
                        .HasColumnType("integer");

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

            modelBuilder.Entity("ProjectManagerAPI.Models.UserProjectNote", b =>
                {
                    b.Property<Guid>("uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("projectUuid")
                        .HasColumnType("uuid");

                    b.Property<Guid>("userUuid")
                        .HasColumnType("uuid");

                    b.Property<string>("value")
                        .HasColumnType("text");

                    b.HasKey("uuid");

                    b.HasIndex("projectUuid");

                    b.HasIndex("userUuid");

                    b.ToTable("ProjectNotes");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("ProfilePicturePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("pinnedProjectUuid")
                        .HasColumnType("uuid");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("pinnedProjectUuid");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.GanntPreviousTask", b =>
                {
                    b.HasOne("ProjectManagerAPI.Models.GanntTasks", "previousTask")
                        .WithMany("previousTasks")
                        .HasForeignKey("previousTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectManagerAPI.Models.GanntTasks", "task")
                        .WithMany()
                        .HasForeignKey("taskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("previousTask");

                    b.Navigation("task");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.GanntTasks", b =>
                {
                    b.HasOne("ProjectManagerAPI.Models.Project", "project")
                        .WithMany("tasks")
                        .HasForeignKey("projectUuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("project");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.Message", b =>
                {
                    b.HasOne("User", null)
                        .WithMany("messages")
                        .HasForeignKey("UserId");

                    b.HasOne("ProjectManagerAPI.Models.Project", "project")
                        .WithMany("messages")
                        .HasForeignKey("projectUuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "sender")
                        .WithOne("message")
                        .HasForeignKey("ProjectManagerAPI.Models.Message", "senderUuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("project");

                    b.Navigation("sender");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.MessageAttachment", b =>
                {
                    b.HasOne("ProjectManagerAPI.Models.Message", "message")
                        .WithMany("messageAttachment")
                        .HasForeignKey("messageUuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("message");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.Project", b =>
                {
                    b.HasOne("User", "owner")
                        .WithMany("projects")
                        .HasForeignKey("ownerUuid")
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

                    b.HasOne("User", "user")
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

                    b.HasOne("User", "user")
                        .WithMany("events")
                        .HasForeignKey("userUuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("projectEvents");

                    b.Navigation("user");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.UserProjectNote", b =>
                {
                    b.HasOne("ProjectManagerAPI.Models.Project", "project")
                        .WithMany("notes")
                        .HasForeignKey("projectUuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "user")
                        .WithMany("projectNotes")
                        .HasForeignKey("userUuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("project");

                    b.Navigation("user");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.HasOne("ProjectManagerAPI.Models.Project", "pinnedProject")
                        .WithMany("pinnedUsers")
                        .HasForeignKey("pinnedProjectUuid");

                    b.Navigation("pinnedProject");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.GanntTasks", b =>
                {
                    b.Navigation("previousTasks");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.Message", b =>
                {
                    b.Navigation("messageAttachment");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.Project", b =>
                {
                    b.Navigation("events");

                    b.Navigation("members");

                    b.Navigation("messages");

                    b.Navigation("notes");

                    b.Navigation("pinnedUsers");

                    b.Navigation("tasks");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.ProjectEvents", b =>
                {
                    b.Navigation("userEvents");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.UserEvents", b =>
                {
                    b.Navigation("events");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Navigation("events");

                    b.Navigation("members");

                    b.Navigation("message");

                    b.Navigation("messages");

                    b.Navigation("projectNotes");

                    b.Navigation("projects");
                });
#pragma warning restore 612, 618
        }
    }
}
