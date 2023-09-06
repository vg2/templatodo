using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace api_templatodo.DataAccess;

public partial class TemplatodoContext : DbContext
{
    private readonly string connectionString;

    public TemplatodoContext(string connectionString) => this.connectionString = connectionString;

    public TemplatodoContext(DbContextOptions<TemplatodoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<InstanceItem> InstanceItems { get; set; }

    public virtual DbSet<Template> Templates { get; set; }

    public virtual DbSet<TemplateCycleSlot> TemplateCycleSlots { get; set; }

    public virtual DbSet<TemplateInstance> TemplateInstances { get; set; }

    public virtual DbSet<TemplateTodoItem> TemplateTodoItems { get; set; }

    public virtual DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(this.connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InstanceItem>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Comment).HasMaxLength(400);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.TemplateInstance).WithMany(p => p.InstanceItems)
                .HasForeignKey(d => d.TemplateInstanceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TemplateInstance_InstanceItems");
        });

        modelBuilder.Entity<Template>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Template");

            entity.Property(e => e.Description).HasMaxLength(400);
            entity.Property(e => e.Frequency).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<TemplateCycleSlot>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("TemplateCycleSlot");

            entity.Property(e => e.Description).HasMaxLength(400);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Template).WithMany(p => p.TemplateCycleSlots)
                .HasForeignKey(d => d.TemplateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TemplateCycleSlot_Template");
        });

        modelBuilder.Entity<TemplateInstance>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("TemplateInstance");

            entity.HasOne(d => d.TemplateTodoItem).WithMany(p => p.TemplateInstances)
                .HasForeignKey(d => d.TemplateTodoItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TemplateTodoItem_TemplateInstance");
        });

        modelBuilder.Entity<TemplateTodoItem>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("TemplateTodoItem");

            entity.Property(e => e.Note).HasMaxLength(100);

            entity.HasOne(d => d.TemplateCycleSlot).WithMany(p => p.TemplateTodoItems)
                .HasForeignKey(d => d.TemplateCycleSlotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TemplateCycleSlot_TemplateTodoItem");

            entity.HasOne(d => d.TodoItem).WithMany(p => p.TemplateTodoItems)
                .HasForeignKey(d => d.TodoItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TodoItem_TemplateTodoItem");
        });

        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("TodoItem");

            entity.Property(e => e.Description).HasMaxLength(400);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
