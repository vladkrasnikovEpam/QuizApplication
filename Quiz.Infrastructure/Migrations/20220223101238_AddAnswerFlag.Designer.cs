﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quiz.Core.Data;

namespace Quiz.Infrastructure.Migrations
{
    [DbContext(typeof(QuizContext))]
    [Migration("20220223101238_AddAnswerFlag")]
    partial class AddAnswerFlag
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Quiz.Core.Entities.Quiz_App.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnswerName")
                        .IsRequired()
                        .HasColumnName("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Correct")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("Quiz.Core.Entities.Quiz_App.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("QuestionName")
                        .HasColumnName("Question")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("Quiz.Core.Entities.Quiz_App.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Quiz.Core.Entities.Quiz_App.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("Quiz.Core.Entities.Quiz_App.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Quiz.Core.Entities.Quiz_App.Answer", b =>
                {
                    b.HasOne("Quiz.Core.Entities.Quiz_App.Question", "Question")
                        .WithMany("Answer")
                        .HasForeignKey("QuestionId")
                        .HasConstraintName("FK_Answer_Question")
                        .IsRequired();
                });

            modelBuilder.Entity("Quiz.Core.Entities.Quiz_App.Question", b =>
                {
                    b.HasOne("Quiz.Core.Entities.Quiz_App.Topic", "Topic")
                        .WithMany("Question")
                        .HasForeignKey("TopicId")
                        .HasConstraintName("FK_Question_Topic")
                        .IsRequired();
                });

            modelBuilder.Entity("Quiz.Core.Entities.Quiz_App.User", b =>
                {
                    b.HasOne("Quiz.Core.Entities.Quiz_App.Role", "Role")
                        .WithMany("User")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_User_Role")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
