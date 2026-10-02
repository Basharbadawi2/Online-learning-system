using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Online_learning_system.Models;

namespace Online_learning_system.Data;

public partial class OnlineLearningDbContext : DbContext
{
    public OnlineLearningDbContext()
    {
    }

    public OnlineLearningDbContext(DbContextOptions<OnlineLearningDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnswerOption> AnswerOptions { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Certificate> Certificates { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<QuizAttempt> QuizAttempts { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnswerOption>(entity =>
        {
            entity.HasKey(e => e.AnswerOptionId).HasName("PK__AnswerOp__CEB739B6FE5B013B");

            entity.HasOne(d => d.Question).WithMany(p => p.AnswerOptions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__AnswerOpt__Quest__6754599E");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A0B1CE1873C");
        });

        modelBuilder.Entity<Certificate>(entity =>
        {
            entity.HasKey(e => e.CertificateId).HasName("PK__Certific__BBF8A7C1D1D27406");

            entity.Property(e => e.IssuedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Enrollment).WithOne(p => p.Certificate)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__Certifica__Enrol__72C60C4A");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__C92D71A76F1B1020");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Category).WithMany(p => p.Courses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__Course__Category__47DBAE45");

            entity.HasOne(d => d.Instructor).WithMany(p => p.Courses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__Course__Instruct__46E78A0C");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK__Enrollme__7F68771B71497D71");

            entity.Property(e => e.EnrolledAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ProgressPercent).HasDefaultValue(0m);

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__Enrollmen__Cours__5441852A");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__Enrollmen__Stude__534D60F1");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.InstructorId).HasName("PK__Instruct__9D010A9B0DF40905");

            entity.HasOne(d => d.User).WithOne(p => p.Instructor)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Instructor_User");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.LessonId).HasName("PK__Lesson__B084ACD0210DDA55");

            entity.HasOne(d => d.Module).WithMany(p => p.Lessons)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__Lesson__ModuleId__4D94879B");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.ModuleId).HasName("PK__Module__2B7477A783E0AAEC");

            entity.HasOne(d => d.Course).WithMany(p => p.Modules)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__Module__CourseId__4AB81AF0");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__9B556A3853895750");

            entity.HasOne(d => d.Course).WithMany(p => p.Payments)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__Payment__CourseI__76969D2E");

            entity.HasOne(d => d.Student).WithMany(p => p.Payments)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__Payment__Student__75A278F5");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__Question__0DC06FAC7D000125");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Questions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__Question__QuizId__6477ECF3");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.QuizId).HasName("PK__Quiz__8B42AE8E235F5ABF");

            entity.HasOne(d => d.Module).WithOne(p => p.Quiz)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__Quiz__ModuleId__619B8048");
        });

        modelBuilder.Entity<QuizAttempt>(entity =>
        {
            entity.HasKey(e => e.AttemptId).HasName("PK__QuizAtte__891A68E6BBE39A86");

            entity.Property(e => e.AttemptedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Quiz).WithMany(p => p.QuizAttempts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__QuizAttem__QuizI__6B24EA82");

            entity.HasOne(d => d.Student).WithMany(p => p.QuizAttempts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__QuizAttem__Stude__6C190EBB");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE1A943A0BAF");

            entity.HasData(
                new Role { RoleId = 1, Name = "Student" },
                new Role { RoleId = 2, Name = "Instructor" },
                new Role { RoleId = 3, Name = "Admin" }
            );
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4C3B7C1D4C");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
