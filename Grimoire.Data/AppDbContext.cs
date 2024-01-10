using Grimoire.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Grimoire.Data;

public class AppDbContext : IdentityDbContext<UserEntity, IdentityRole<int>, int>
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options)
        : base(options) {}

    public DbSet<UserEntity> Users {get; set;}
    public DbSet<CorrespondenceEntity> Correspondences {get; set;}
    public DbSet<DeityEntity> Deities { get; set; }
    public DbSet<NoteEntity> Notes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserEntity>().ToTable("Users");
        
        modelBuilder.Entity<NoteEntity>()
            .HasOne(n => n.User)
            .WithMany(u => u.Notes)
            .HasForeignKey(n => n.Owner)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<NoteEntity>()
            .HasOne(n => n.Deity)
            .WithMany(d => d.Notes)
            .HasForeignKey(n => n.DeityId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<DeityEntity>()
            .HasOne(d => d.Correspondence)
            .WithMany()
            .HasForeignKey(d => d.CorrespondenceId);
    }
}
