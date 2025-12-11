using Genealogy.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Genealogy.Database
{
    public class GenealogyDbContext(DbContextOptions<GenealogyDbContext> options) : DbContext(options)
    {
        public DbSet<UserDb> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            ConfigureUserDb(modelBuilder);

            // Tutaj dodasz konfiguracje relacji i encji
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

    }
}
