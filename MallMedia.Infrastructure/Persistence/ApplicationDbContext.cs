using MallMedia.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MallMedia.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions options) : IdentityDbContext<User>(options)
{
    public DbSet<Device> Devices { get; set; }
    public DbSet<Content> Contents { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Media> Medias { get; set; }
    public DbSet<DeviceType> DeviceTypes { get; set; }
    public DbSet<Device_Schedule> Device_Schedules { get; set; }
    public DbSet<Calender_Detail> Calender_Details { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Calendar_Detail
        modelBuilder.Entity<Calender_Detail>()
            .HasOne(cd => cd.Device_Schedule)
            .WithMany(ds => ds.Calender_Device_Schedule)
            .HasForeignKey(cd => cd.DeviceScheduleId)
            .OnDelete(DeleteBehavior.Cascade);

        // Category and Content (1-n)
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Contents)
            .WithOne(c => c.Category)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Content and CreatedByUser (optional relationship)
        modelBuilder.Entity<Content>()
            .HasOne(c => c.CreatedByUser)
            .WithMany()
            .HasForeignKey(c => c.CreatedBy)
            .OnDelete(DeleteBehavior.SetNull);

        // Media and Content (1-n)
        modelBuilder.Entity<Media>()
            .HasOne(m => m.Content)
            .WithMany(c => c.Media)
            .HasForeignKey(m => m.ContentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Device and Location (1-n)
        modelBuilder.Entity<Device>()
            .HasOne(d => d.Location)
            .WithMany()
            .HasForeignKey(d => d.LocationId)
            .OnDelete(DeleteBehavior.Cascade);

        // Device and DeviceType (1-n)
        modelBuilder.Entity<Device>()
            .HasOne(d => d.DeviceType)
            .WithMany()
            .HasForeignKey(d => d.DeviceTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Device and User (1-n)
        modelBuilder.Entity<Device>()
            .HasOne(d => d.User)
            .WithMany()
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Device_Schedule and Device (1-n)
        modelBuilder.Entity<Device_Schedule>()
            .HasOne(ds => ds.Device)
            .WithMany(d => d.DeviceSchedule)
            .HasForeignKey(ds => ds.DeviceId)
            .OnDelete(DeleteBehavior.Cascade);

        // Device_Schedule and Schedule (1-n)
        modelBuilder.Entity<Device_Schedule>()
            .HasOne(ds => ds.Schedule)
            .WithMany(s => s.DeviceSchedule)
            .HasForeignKey(ds => ds.ScheduleId)
            .OnDelete(DeleteBehavior.Cascade);

        // Schedule and Content (1-n)
        modelBuilder.Entity<Schedule>()
            .HasOne(s => s.Content)
            .WithMany()
            .HasForeignKey(s => s.ContentId)
            .OnDelete(DeleteBehavior.Cascade);

    }


}
