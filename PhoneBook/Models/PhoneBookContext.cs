using Microsoft.EntityFrameworkCore;

namespace PhoneBook.Models;

public partial class PhoneBookContext : DbContext
{
    public PhoneBookContext()
    {
    }

    public PhoneBookContext(DbContextOptions<PhoneBookContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DbPhoneBookEntry> PhoneBookEntries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbPhoneBookEntry>(entity =>
        {
            entity.ToTable("PhoneBookEntry");
            entity.HasKey("PhoneBookEntryId");
            entity.Property(e => e.Firstname).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
