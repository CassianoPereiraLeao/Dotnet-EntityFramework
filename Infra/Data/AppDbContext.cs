using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Admin> Admins { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            var adminId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");

            entity.OwnsOne(a => a.Email, emailOwned =>
            {
                emailOwned.Property(e => e.Value).HasColumnName("Email");
                emailOwned.HasData(new { AdminId = adminId, Value = "admin@teste.com" });
            });

            entity.OwnsOne(a => a.Password, passwordOwned =>
            {
                passwordOwned.Property(p => p.Value).HasColumnName("Password");
                passwordOwned.HasData(new { AdminId = adminId, Value = "$2a$11$IjAKWjqLaxnEgv7HjI7hH.wPT1TmkTQ0S2187qIuXn6wEhdKS7tPK" });
            });

            entity.HasData(new { Id = adminId, Profile = "admin" });
        });
    }
}