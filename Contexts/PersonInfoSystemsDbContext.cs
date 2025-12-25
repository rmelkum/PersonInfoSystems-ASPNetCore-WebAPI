using System;
using PersonInfoSystems.Models;
using Microsoft.EntityFrameworkCore;

namespace PersonInfoSystems.Contexts;

public class PersonInfoSystemsDbContext : DbContext
{

    public DbSet<PersonEntity> Persons { get; set; }
    public DbSet<CountryEntity> Countries { get; set; }
    public DbSet<CityEntity> Cities { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<PersonAddressEntity> PersonAddresses { get; set; }

    public PersonInfoSystemsDbContext(DbContextOptions<PersonInfoSystemsDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Country Entity
        modelBuilder.Entity<CountryEntity>(entity =>
        {
            entity.ToTable("Country");
            entity.HasKey(e => e.CountryId);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Continent).HasMaxLength(20);
            entity.Property(e => e.Currency).HasMaxLength(10);

            entity.HasMany(e => e.Cities)
            .WithOne(e => e.CountryNavigation)
            .HasForeignKey(e => e.CountryId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        //City Entity
        modelBuilder.Entity<CityEntity>(entity =>
        {
            entity.ToTable("City");
            entity.HasKey(e => e.CityId);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasMany(e => e.Adressies)
            .WithOne(e => e.CityNavigation)
            .HasForeignKey(e => e.CityId);

        });

        //Address Entity
        modelBuilder.Entity<AddressEntity>(entity =>
        {
            entity.ToTable("Address");
            entity.HasKey(e => e.AdressId);
            entity.Property(e => e.Adress).HasMaxLength(100);
            entity.Property(e => e.ZipCode).HasMaxLength(10);

            entity.HasMany(e => e.PersonAddresses)
            .WithOne(e => e.AddressNavigation)
            .HasForeignKey(e => e.AdressId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        //Person Entity
        modelBuilder.Entity<PersonEntity>(entity =>
        {
            entity.ToTable("Person");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Surname).HasMaxLength(100);
            entity.Property(e => e.Mail).HasMaxLength(100);
            entity.Property(e => e.NationalID).HasMaxLength(20);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);

            entity.HasMany(e => e.PersonAddresses)
            .WithOne(pa => pa.PersonNavigation)
            .HasForeignKey(pa => pa.PersonId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        //PersonAddress Entity
        modelBuilder.Entity<PersonAddressEntity>(entity =>
        {
            entity.HasKey(e => new { e.AdressId, e.PersonId });
            entity.HasOne(e => e.PersonNavigation)
            .WithMany(e => e.PersonAddresses)
            .HasForeignKey(e => e.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.AddressNavigation)
            .WithMany(e => e.PersonAddresses)
            .HasForeignKey(e => e.AdressId)
            .OnDelete(DeleteBehavior.Cascade);
        });
    }

}
