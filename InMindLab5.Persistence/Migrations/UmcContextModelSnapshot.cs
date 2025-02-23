﻿// <auto-generated />
using System;
using InMindLab5.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InMindLab5.Persistence.Migrations
{
    [DbContext(typeof(UmcContext))]
    partial class UmcContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("InMindLab5.Domain.Entities.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AdminId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("InMindLab5.Domain.Entities.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CourseId"));

                    b.Property<int>("AdminId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EnrollEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("EnrollStart")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("MaxNb")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CourseId");

                    b.HasIndex("AdminId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("InMindLab5.Domain.Entities.Enroll", b =>
                {
                    b.Property<int>("EnrollId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EnrollId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float?>("Grade")
                        .HasColumnType("real");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.HasKey("EnrollId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("InMindLab5.Domain.Entities.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StudentId"));

                    b.Property<float?>("GradePointAverage")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("canApplyToFrance")
                        .HasColumnType("boolean");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("InMindLab5.Domain.Entities.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeOnly>("ScheduleEnd")
                        .HasColumnType("time without time zone");

                    b.Property<TimeOnly>("ScheduleStart")
                        .HasColumnType("time without time zone");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("InMindLab5.Domain.Entities.TeacherCourse", b =>
                {
                    b.Property<int>("TeacherCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TeacherCourseId"));

                    b.Property<TimeOnly>("ClassEnd")
                        .HasColumnType("time without time zone");

                    b.Property<TimeOnly>("ClassStart")
                        .HasColumnType("time without time zone");

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<int>("TeacherId")
                        .HasColumnType("integer");

                    b.HasKey("TeacherCourseId");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherCourses");
                });

            modelBuilder.Entity("InMindLab5.Domain.Entities.Course", b =>
                {
                    b.HasOne("InMindLab5.Domain.Entities.Admin", "Admin")
                        .WithMany("Courses")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("InMindLab5.Domain.Entities.Enroll", b =>
                {
                    b.HasOne("InMindLab5.Domain.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InMindLab5.Domain.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("InMindLab5.Domain.Entities.TeacherCourse", b =>
                {
                    b.HasOne("InMindLab5.Domain.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InMindLab5.Domain.Entities.Teacher", "Teacher")
                        .WithMany("TeacherCourses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("InMindLab5.Domain.Entities.Admin", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("InMindLab5.Domain.Entities.Teacher", b =>
                {
                    b.Navigation("TeacherCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
