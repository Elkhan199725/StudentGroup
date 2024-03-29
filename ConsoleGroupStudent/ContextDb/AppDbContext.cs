﻿using ConsoleGroupStudent.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleGroupStudent.ContextDb;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=TITAN03\SQLEXPRESS;Database=StudentGroupProject;Trusted_Connection=true;TrustServerCertificate=true;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentGroup>()
            .HasKey(sg => new { sg.StudentId, sg.GroupId });
        modelBuilder.Entity<Student>()
            .HasMany(s => s.StudentGroups)
            .WithOne(sg => sg.Student)
            .HasForeignKey(sg => sg.StudentId);
        modelBuilder.Entity<Group>()
            .HasMany(g => g.StudentGroups)
            .WithOne(sg => sg.Group)
            .HasForeignKey(sg => sg.GroupId);
        modelBuilder.Entity<Group>()
            .HasIndex(g=>g.Name)
            .IsUnique();
    }
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Group> Groups { get; set; } = null!;
    public DbSet<StudentGroup> StudentGroups { get; set; } = null!;
}
