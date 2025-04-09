﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Exam.ExamEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("examListId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("examListId");

                    b.ToTable("ExamEvent", "dbo");
                });

            modelBuilder.Entity("Domain.Exam.ExamList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ExamList", "dbo");
                });

            modelBuilder.Entity("Domain.Exam.ExamResultFinal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descript")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<string>("FinalResult")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.ToTable("ExamResultFinals", "dbo");
                });

            modelBuilder.Entity("Domain.Exam.JobGroupIndex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobGroupIndex", "dbo");
                });

            modelBuilder.Entity("Domain.Exam.JobOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("JobQuestionId")
                        .HasColumnType("int");

                    b.Property<string>("TItle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.Property<int>("jobGroupIndexId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobQuestionId");

                    b.HasIndex("jobGroupIndexId");

                    b.ToTable("JobOptions", "dbo");
                });

            modelBuilder.Entity("Domain.Exam.JobQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobQuestions", "dbo");
                });

            modelBuilder.Entity("Domain.Exam.JobUserAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("JobQuestionId")
                        .HasColumnType("int");

                    b.Property<int>("OptionId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobQuestionId");

                    b.HasIndex("OptionId");

                    b.HasIndex("UserId");

                    b.ToTable("JobUserAnswers", "dbo");
                });

            modelBuilder.Entity("Domain.Exam.NinOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NinOptions", "dbo");
                });

            modelBuilder.Entity("Domain.Exam.NinQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("seriId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("seriId");

                    b.ToTable("NinQuestions", "dbo");
                });

            modelBuilder.Entity("Domain.Exam.NinUserAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("ItUserId")
                        .HasColumnType("int");

                    b.Property<int>("ninOptionId")
                        .HasColumnType("int");

                    b.Property<int>("ninQuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItUserId");

                    b.HasIndex("ninOptionId");

                    b.HasIndex("ninQuestionId");

                    b.ToTable("NinUserAnswers", "dbo");
                });

            modelBuilder.Entity("Domain.Exam.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Options", "dbo");
                });

            modelBuilder.Entity("Domain.Exam.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descript")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Questions", "dbo");
                });

            modelBuilder.Entity("Domain.Exam.Seri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Seri", "dbo");
                });

            modelBuilder.Entity("Domain.Exam.SubOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("OptionId")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OptionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("SubOptions", "dbo");
                });

            modelBuilder.Entity("Domain.Exam.UserAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("ItUserId")
                        .HasColumnType("int");

                    b.Property<int>("OptionId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("SubOptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserAnswers", "dbo");
                });

            modelBuilder.Entity("Domain.Exam.UserExam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("UserId");

                    b.ToTable("UserExams", "dbo");
                });

            modelBuilder.Entity("Domain.User.MyUser", b =>
                {
                    b.Property<int>("ItUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ActiveCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserAvatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ItUserId");

                    b.ToTable("MyUser", "dbo");
                });

            modelBuilder.Entity("Domain.User.Permission.PermissionList", b =>
                {
                    b.Property<int>("PermissionListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PermissionListId"));

                    b.Property<string>("ActionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ControllerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descript")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("Radif")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("PermissionListId");

                    b.ToTable("PermissionList", "dbo");
                });

            modelBuilder.Entity("Domain.User.Permission.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Role", "dbo");
                });

            modelBuilder.Entity("Domain.User.Permission.RolePermission", b =>
                {
                    b.Property<int>("RP_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RP_Id"));

                    b.Property<int>("PermissionListId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("RP_Id");

                    b.HasIndex("PermissionListId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermission", "dbo");
                });

            modelBuilder.Entity("Domain.User.UserRole", b =>
                {
                    b.Property<int>("UR_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UR_Id"));

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UR_Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole", "dbo");
                });

            modelBuilder.Entity("Domain.Exam.ExamEvent", b =>
                {
                    b.HasOne("Domain.User.MyUser", "myUser")
                        .WithMany("ExamEvents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Exam.ExamList", "examList")
                        .WithMany("ExamEvents")
                        .HasForeignKey("examListId");

                    b.Navigation("examList");

                    b.Navigation("myUser");
                });

            modelBuilder.Entity("Domain.Exam.ExamResultFinal", b =>
                {
                    b.HasOne("Domain.Exam.ExamList", "examList")
                        .WithMany("ExamResultFinals")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("examList");
                });

            modelBuilder.Entity("Domain.Exam.JobOption", b =>
                {
                    b.HasOne("Domain.Exam.JobQuestion", "jobQuestion")
                        .WithMany("JobOptions")
                        .HasForeignKey("JobQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Exam.JobGroupIndex", "jopGroupIndex")
                        .WithMany("JobOptions")
                        .HasForeignKey("jobGroupIndexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("jobQuestion");

                    b.Navigation("jopGroupIndex");
                });

            modelBuilder.Entity("Domain.Exam.JobUserAnswer", b =>
                {
                    b.HasOne("Domain.Exam.JobQuestion", "JobQuestion")
                        .WithMany("JobUserAnswers")
                        .HasForeignKey("JobQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Exam.JobOption", "jobOption")
                        .WithMany("JobUserAnswers")
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.User.MyUser", "MyUser")
                        .WithMany("JobUserAnswers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobQuestion");

                    b.Navigation("MyUser");

                    b.Navigation("jobOption");
                });

            modelBuilder.Entity("Domain.Exam.NinQuestion", b =>
                {
                    b.HasOne("Domain.Exam.Seri", "seri")
                        .WithMany("NinQuestions")
                        .HasForeignKey("seriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("seri");
                });

            modelBuilder.Entity("Domain.Exam.NinUserAnswer", b =>
                {
                    b.HasOne("Domain.User.MyUser", "users")
                        .WithMany("NinUserAnswers")
                        .HasForeignKey("ItUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Exam.NinOption", "ninOption")
                        .WithMany("NinUserAnswers")
                        .HasForeignKey("ninOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Exam.NinQuestion", "ninQuestion")
                        .WithMany("NinUserAnswers")
                        .HasForeignKey("ninQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ninOption");

                    b.Navigation("ninQuestion");

                    b.Navigation("users");
                });

            modelBuilder.Entity("Domain.Exam.Option", b =>
                {
                    b.HasOne("Domain.Exam.Question", "Question")
                        .WithMany("options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Domain.Exam.SubOption", b =>
                {
                    b.HasOne("Domain.Exam.Option", "Option")
                        .WithMany("SubOptions")
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Exam.Question", "Question")
                        .WithMany("subOptions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Option");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Domain.Exam.UserExam", b =>
                {
                    b.HasOne("Domain.Exam.ExamList", "examList")
                        .WithMany("UserExams")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.User.MyUser", "myUser")
                        .WithMany("UserExams")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("examList");

                    b.Navigation("myUser");
                });

            modelBuilder.Entity("Domain.User.MyUser", b =>
                {
                    b.HasOne("Domain.Exam.UserAnswer", null)
                        .WithMany("users")
                        .HasForeignKey("ItUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.User.Permission.RolePermission", b =>
                {
                    b.HasOne("Domain.User.Permission.PermissionList", "PermissionList")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.User.Permission.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PermissionList");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.User.UserRole", b =>
                {
                    b.HasOne("Domain.User.Permission.Role", "Role")
                        .WithMany("userRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.User.MyUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Exam.ExamList", b =>
                {
                    b.Navigation("ExamEvents");

                    b.Navigation("ExamResultFinals");

                    b.Navigation("UserExams");
                });

            modelBuilder.Entity("Domain.Exam.JobGroupIndex", b =>
                {
                    b.Navigation("JobOptions");
                });

            modelBuilder.Entity("Domain.Exam.JobOption", b =>
                {
                    b.Navigation("JobUserAnswers");
                });

            modelBuilder.Entity("Domain.Exam.JobQuestion", b =>
                {
                    b.Navigation("JobOptions");

                    b.Navigation("JobUserAnswers");
                });

            modelBuilder.Entity("Domain.Exam.NinOption", b =>
                {
                    b.Navigation("NinUserAnswers");
                });

            modelBuilder.Entity("Domain.Exam.NinQuestion", b =>
                {
                    b.Navigation("NinUserAnswers");
                });

            modelBuilder.Entity("Domain.Exam.Option", b =>
                {
                    b.Navigation("SubOptions");
                });

            modelBuilder.Entity("Domain.Exam.Question", b =>
                {
                    b.Navigation("options");

                    b.Navigation("subOptions");
                });

            modelBuilder.Entity("Domain.Exam.Seri", b =>
                {
                    b.Navigation("NinQuestions");
                });

            modelBuilder.Entity("Domain.Exam.UserAnswer", b =>
                {
                    b.Navigation("users");
                });

            modelBuilder.Entity("Domain.User.MyUser", b =>
                {
                    b.Navigation("ExamEvents");

                    b.Navigation("JobUserAnswers");

                    b.Navigation("NinUserAnswers");

                    b.Navigation("UserExams");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Domain.User.Permission.PermissionList", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("Domain.User.Permission.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("userRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
