using Genealogy.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Genealogy.Database
{
    public class GenealogyDbContext(DbContextOptions<GenealogyDbContext> options) : DbContext(options)
    {
        public DbSet<UserDb> Users { get; set; } = null!;
        public DbSet<FamilyMemberDb> FamilyMembers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureUserDb(modelBuilder);
            ConfigureFamilyMemberDb(modelBuilder);
        }

        private static void ConfigureUserDb(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDb>()
                .ToTable("Users")
                .HasKey(x => x.Id);

            modelBuilder
                .Entity<UserDb>()
                .Property(x => x.UserName)
                .IsRequired(true);
            modelBuilder
                .Entity<UserDb>()
                .Property(x => x.PasswordHash)
                .IsRequired(true);

            modelBuilder
               .Entity<UserDb>()
               .Property(x => x.Active).HasDefaultValue(true);

            modelBuilder
               .Entity<UserDb>()
               .Property(x => x.Role).HasDefaultValue(0);

            modelBuilder.Entity<UserDb>().Property(x => x.Id)
                .ValueGeneratedOnAdd();

        }

        private static void ConfigureFamilyMemberDb(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FamilyMemberDb>()
                .ToTable("FamilyMembers")
                .HasKey(x => x.Id);

            modelBuilder
                .Entity<FamilyMemberDb>()
                .Property(x => x.FirstName)
                .IsRequired(true);
            modelBuilder
                .Entity<FamilyMemberDb>()
                .Property(x => x.LastName)
                .IsRequired(true);

            modelBuilder.Entity<UserDb>().Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<FamilyMemberDb>()
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP") // PostgreSQL
                .ValueGeneratedOnAdd();

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                if (entry.Entity is FamilyMemberDb familyMember)
                {
                    if (entry.State == EntityState.Added)
                    {
                        familyMember.CreatedAt = DateTime.UtcNow;
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        familyMember.UpdatedAt = DateTime.UtcNow;
                    }
                }

                // Możesz dodać inne encje tutaj
                // if (entry.Entity is UserDb user) { ... }
            }
        }
    }
}
