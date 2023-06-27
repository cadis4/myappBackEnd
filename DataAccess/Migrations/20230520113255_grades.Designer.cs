﻿// <auto-generated />
using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(QuizAppContext))]
    [Migration("20230520113255_grades")]
    partial class grades
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccesLayer.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("AEPassed")
                        .HasColumnType("bit");

                    b.Property<bool?>("BDPassed")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("SCPassed")
                        .HasColumnType("bit");

                    b.Property<bool?>("TBPassed")
                        .HasColumnType("bit");

                    b.Property<bool?>("TUPassed")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("cppPassed")
                        .HasColumnType("bit");

                    b.Property<int?>("lastScoreAE")
                        .HasColumnType("int");

                    b.Property<int?>("lastScoreBD")
                        .HasColumnType("int");

                    b.Property<int?>("lastScoreCpp")
                        .HasColumnType("int");

                    b.Property<int?>("lastScorePseudocod")
                        .HasColumnType("int");

                    b.Property<int?>("lastScoreRec")
                        .HasColumnType("int");

                    b.Property<int?>("lastScoreSC")
                        .HasColumnType("int");

                    b.Property<int?>("lastScoreTB")
                        .HasColumnType("int");

                    b.Property<int?>("lastScoreTU")
                        .HasColumnType("int");

                    b.Property<int?>("maxScoreAE")
                        .HasColumnType("int");

                    b.Property<int?>("maxScoreBD")
                        .HasColumnType("int");

                    b.Property<int?>("maxScoreCpp")
                        .HasColumnType("int");

                    b.Property<int?>("maxScorePseudocod")
                        .HasColumnType("int");

                    b.Property<int?>("maxScoreRec")
                        .HasColumnType("int");

                    b.Property<int?>("maxScoreSC")
                        .HasColumnType("int");

                    b.Property<int?>("maxScoreTB")
                        .HasColumnType("int");

                    b.Property<int?>("maxScoreTU")
                        .HasColumnType("int");

                    b.Property<bool?>("pseudocodPassed")
                        .HasColumnType("bit");

                    b.Property<bool?>("recPassed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataAccess.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionId"));

                    b.Property<string>("AnswerFour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnswerOne")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnswerThree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnswerTwo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.Property<bool>("VerifyAnswer")
                        .HasColumnType("bit");

                    b.HasKey("QuestionId");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("DataAccess.Models.Quiz", b =>
                {
                    b.Property<int>("QuizId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuizId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuizId");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("DataAccess.Models.Question", b =>
                {
                    b.HasOne("DataAccess.Models.Quiz", "Quiz")
                        .WithMany()
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });
#pragma warning restore 612, 618
        }
    }
}