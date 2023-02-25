﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Olympiads.DAL;

#nullable disable

namespace Olympiads.DAL.Migrations
{
    [DbContext(typeof(EntityDbContext))]
    [Migration("20230225100930_ChangeAnswerModelv2")]
    partial class ChangeAnswerModelv2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Olympiads.Core.Models.Olympiad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndRegistrationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartRegistrationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Olympiad");
                });

            modelBuilder.Entity("Olympiads.Core.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CountOfScore")
                        .HasColumnType("integer");

                    b.Property<int>("OlympiadId")
                        .HasColumnType("integer");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OlympiadId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("Olympiads.Core.Models.QuestionAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<bool>("RightAnswer")
                        .HasColumnType("boolean");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionAnswers");
                });

            modelBuilder.Entity("Olympiads.Core.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("School")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SchoolClass")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Scores")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("TeamId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Olympiads.Core.Models.StudentAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentAnswers");
                });

            modelBuilder.Entity("Olympiads.Core.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("School")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SchoolClass")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("TeamId")
                        .HasColumnType("integer");

                    b.Property<int>("TeamId1")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TeamId")
                        .IsUnique();

                    b.HasIndex("TeamId1");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Olympiads.Core.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Olympiads.Core.Models.Question", b =>
                {
                    b.HasOne("Olympiads.Core.Models.Olympiad", null)
                        .WithMany("Questions")
                        .HasForeignKey("OlympiadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Olympiads.Core.Models.QuestionAnswer", b =>
                {
                    b.HasOne("Olympiads.Core.Models.Question", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Olympiads.Core.Models.Student", b =>
                {
                    b.HasOne("Olympiads.Core.Models.Team", null)
                        .WithMany("Students")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("Olympiads.Core.Models.StudentAnswer", b =>
                {
                    b.HasOne("Olympiads.Core.Models.Student", null)
                        .WithMany("Answers")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Olympiads.Core.Models.Teacher", b =>
                {
                    b.HasOne("Olympiads.Core.Models.Team", null)
                        .WithOne("Teacher")
                        .HasForeignKey("Olympiads.Core.Models.Teacher", "TeamId");

                    b.HasOne("Olympiads.Core.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Olympiads.Core.Models.Olympiad", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Olympiads.Core.Models.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Olympiads.Core.Models.Student", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Olympiads.Core.Models.Team", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
