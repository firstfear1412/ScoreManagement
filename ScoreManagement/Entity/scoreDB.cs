﻿using Microsoft.EntityFrameworkCore;
using ScoreManagement.Model.Table;

namespace ScoreManagement.Entity
{
    public class scoreDB : DbContext
    {
        public scoreDB() { }
        public scoreDB(DbContextOptions<scoreDB> options):base(options){ }

        //***** DbSet *****//
        public DbSet<User> Users { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<SystemParam> SystemParams { get; set; }
        public DbSet<WebEvent_Logs> WebEvent_Logs { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<SubjectScore> SubjectScores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<User>()
               .ToTable("User")
               .HasKey(a => new { a.row_id });
            modelBuilder
                .Entity<Language>()
                .ToTable("Language")
                .HasKey(a => new { a.row_id });
            modelBuilder
                .Entity<SystemParam>()
                .ToTable("SystemParam")
                .HasKey(a => new { a.row_id });
            modelBuilder
                .Entity<WebEvent_Logs>()
                .ToTable("WebEvent_Logs")
                .HasKey(a => new { a.event_id });
            modelBuilder
                .Entity<Subject>()
                .ToTable("Subject")
                .HasKey(a => new { a.row_id });
            modelBuilder
                .Entity<Student>()
                .ToTable("Student")
                .HasKey(a => new { a.row_id });
            modelBuilder
                .Entity<SubjectScore>()
                .ToTable("SubjectScore")
                .HasKey(a => new { a.row_id });
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(true, cancellationToken);
        }
    }
}