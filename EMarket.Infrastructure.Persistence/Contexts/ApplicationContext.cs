using EMarket.Core.Domain.Common;
using EMarket.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EMarket.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<AdvertisesPhotos> AdvertisesPhotos { get; set; }
        public DbSet<Advertise> Advertises { get; set; }
        public DbSet<Category> Categories { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FLUENT API

            #region tables
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Advertise>().ToTable("Advertises");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<AdvertisesPhotos>().ToTable("AdvertisesPhotos");
            #endregion

            #region "primary keys"
            modelBuilder.Entity<User>().HasKey(user => user.Id);
            modelBuilder.Entity<Advertise>().HasKey(ad => ad.Id);
            modelBuilder.Entity<Category>().HasKey(category => category.Id);
            modelBuilder.Entity<AdvertisesPhotos>().HasKey(photo => photo.Id);
            #endregion

            #region relationships
            modelBuilder.Entity<User>()
                .HasMany<Advertise>(user => user.Advertises)
                .WithOne(ad => ad.User)
                .HasForeignKey(user => user.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>()
                .HasMany<Advertise>(category => category.Advertises)
                .WithOne(ad => ad.Category)
                .HasForeignKey(category => category.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Advertise>()
                .HasOne<AdvertisesPhotos>(ad => ad.AdvertisePhotos)
                .WithOne(photo => photo.advertise)
                .HasForeignKey<AdvertisesPhotos>(ad => ad.AdvertiseID)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region "tables properties"

            #region Users

            modelBuilder.Entity<User>()
                .Property(p => p.FirstName).IsRequired();

            modelBuilder.Entity<User>()
                .Property(p => p.LastName).IsRequired();

            modelBuilder.Entity<User>()
                .Property(p => p.Email).IsRequired();

            modelBuilder.Entity<User>()
                .Property(p => p.Phone).IsRequired();

            modelBuilder.Entity<User>()
                .Property(p => p.Username).IsRequired();

            modelBuilder.Entity<User>()
                .Property(p => p.Password).IsRequired();
            #endregion

            #region Advertises
            modelBuilder.Entity<Advertise>().Property(p => p.ProductName).IsRequired();

            modelBuilder.Entity<Advertise>().Property(p => p.Description).IsRequired();

            modelBuilder.Entity<Advertise>().Property(p => p.ImageUrl).IsRequired(false);

            modelBuilder.Entity<Advertise>().Property(p => p.Price).IsRequired();

            modelBuilder.Entity<Advertise>().Property(p => p.CategoryId).IsRequired();


            #endregion

            #region Categories
            modelBuilder.Entity<Category>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Category>().Property(p => p.Description).IsRequired();
            #endregion

            #endregion
        }
    }
}
