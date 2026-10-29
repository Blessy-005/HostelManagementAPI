using HostelManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HostelManagementAPI.Data;

public class HostelDbContext : DbContext
{
    public HostelDbContext(DbContextOptions<HostelDbContext> options) : base(options) { }

    public DbSet<Hostel> Hostels => Set<Hostel>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Allocation> Allocations => Set<Allocation>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Hostel>(e =>
        {
            e.Property(x => x.Name).IsRequired().HasMaxLength(100);
            e.Property(x => x.Address).IsRequired().HasMaxLength(250);
            e.Property(x => x.Type).HasConversion<string>().HasMaxLength(10);
            e.HasIndex(x => x.Name).IsUnique();
        });

        b.Entity<Room>(e =>
        {
            e.Property(x => x.RoomNumber).IsRequired().HasMaxLength(10);
            e.HasIndex(x => new { x.HostelId, x.RoomNumber }).IsUnique();
            e.HasOne(x => x.Hostel).WithMany(h => h.Rooms)
             .HasForeignKey(x => x.HostelId).OnDelete(DeleteBehavior.Restrict);
        });

        b.Entity<Student>(e =>
        {
            e.Property(x => x.Name).IsRequired().HasMaxLength(100);
            e.Property(x => x.Email).IsRequired().HasMaxLength(150);
            e.Property(x => x.Phone).IsRequired().HasMaxLength(15);
            e.HasIndex(x => x.Email).IsUnique();
        });

        b.Entity<Allocation>(e =>
        {
            e.HasOne(x => x.Student).WithMany(s => s.Allocations)
             .HasForeignKey(x => x.StudentId).OnDelete(DeleteBehavior.Restrict);
            e.HasOne(x => x.Room).WithMany(r => r.Allocations)
             .HasForeignKey(x => x.RoomId).OnDelete(DeleteBehavior.Restrict);
        });
    }
}
