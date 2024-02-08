using Microsoft.EntityFrameworkCore;
using Tridenta.Model;

namespace Tridenta.DAL
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public virtual DbSet<TblUserRegistration> TblUserRegistrations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TblUserRegistration>(entity =>
            {

                entity.ToTable("TblUserRegistration");
                entity.Property(e => e.UserId).ValueGeneratedOnAdd();
                entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .HasMaxLength(50)
                .IsUnicode(false);
                entity.Property(e => e.Name)
               .HasMaxLength(50)
               .HasMaxLength(50)
               .IsUnicode(false);
                entity.Property(e => e.Email)
               .HasMaxLength(50)
               .HasMaxLength(50)
               .IsUnicode(false);
                entity.Property(e => e.Password)
               .HasMaxLength(50)
               .HasMaxLength(50)
               .IsUnicode(false);
                entity.Property(e => e.Phone)
               .HasMaxLength(50)
               .HasMaxLength(50)
               .IsUnicode(false);
                entity.Property(e => e.Gender)
               .HasMaxLength(50)
               .HasMaxLength(50)
               .IsUnicode(false);
                entity.Property(e => e.Address)
             .HasMaxLength(50)
             .HasMaxLength(50)
             .IsUnicode(false);
                entity.Property(e => e.City)
             .HasMaxLength(50)
             .HasMaxLength(50)
             .IsUnicode(false);
                entity.Property(e => e.ProfileImage)
             .HasMaxLength(50)
             .HasMaxLength(50)
             .IsUnicode(false);
                entity.Property(e => e.IsDeleted)
             .HasMaxLength(50)
             .HasMaxLength(50)
             .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
                entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
