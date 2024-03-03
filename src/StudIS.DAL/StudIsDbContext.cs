﻿using Microsoft.EntityFrameworkCore;
using StudIS.DAL.Entities;

namespace StudIS.DAL;

public class StudIsDbContext(DbContextOptions contextOptions, bool seedDemoData = false) : DbContext(contextOptions)
{
    public DbSet<ActivityEntity> Activities => Set<ActivityEntity>();
    public DbSet<EvaluationEntity> Evaluations => Set<EvaluationEntity>();
    public DbSet<StudentEntity> Students => Set<StudentEntity>();
    public DbSet<SubjectEntity> Subjects => Set<SubjectEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //Activity
        modelBuilder.Entity<ActivityEntity>()
            .HasMany(i => i.Evaluations)
            .WithOne(i => i.Activity)
            .OnDelete(DeleteBehavior.Cascade);
        
        //Evaluation?
        
        //Subject
        modelBuilder.Entity<SubjectEntity>()
            .HasMany(i => i.Activities)
            .WithOne(i => i.Subject)
            .OnDelete(DeleteBehavior.Cascade);
        
        //Student?
        modelBuilder.Entity<StudentEntity>()
            .HasMany<EvaluationEntity>()
            .WithOne(i => i.Student)
            .OnDelete(DeleteBehavior.Cascade);

        if (seedDemoData)
        {
            //Add later for tests
        }
    }
}