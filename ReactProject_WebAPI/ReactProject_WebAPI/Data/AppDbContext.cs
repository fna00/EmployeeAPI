using Microsoft.EntityFrameworkCore;
using ReactProject_WebAPI.Models;

namespace ReactProject_WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Employee tablosu için yapılandırma
            modelBuilder.Entity<Employee>(entity =>
            {
                // Tablo adı
                entity.ToTable("Employees");
                // Primary key
                entity.HasKey(e => e.EmployeeId);
                // EmployeeId (Primary key)
                entity.Property(e => e.EmployeeId)
                      .ValueGeneratedOnAdd(); // Otomatik artan kimlik alanı
                // FirstName
                entity.Property(e => e.FirstName)
                      .IsRequired()
                      .HasMaxLength(50);
                // LastName
                entity.Property(e => e.LastName)
                      .IsRequired()
                      .HasMaxLength(50);
                // DateOfBirth 
                entity.Property(e => e.DateOfBirth)
                      .HasColumnType("date") // (gün, ay, yıl) tersiymiş
                      .IsRequired();
                // PhoneNumber
                entity.Property(e => e.PhoneNumber)
                     .IsRequired();
                // Email
                entity.Property(e => e.Email)
                      .IsRequired();
                // Address
                entity.Property(e => e.Address)
                      .IsRequired();
                // DepartmentId
                entity.Property(e => e.DepartmentId)
                      .IsRequired();
                // Position
                entity.Property(e => e.Position)
                      .IsRequired();
                // Salary
                entity.Property(e => e.Salary)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();
                // StartDate (
                entity.Property(e => e.StartDate)
                      .HasColumnType("date")
                      .IsRequired();
            });
        }
    }
}
