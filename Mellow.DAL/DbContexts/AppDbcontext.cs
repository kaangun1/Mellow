using Mellow.Entites.Entities.Abstract;
using Mellow.Entites.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mellow.DAL.DbContexts
{
    public class AppDbcontext:IdentityDbContext<AppUser,IdentityRole,string>
    {
        public DbSet<Oda> Odalar { get; set; }
        public DbSet<OdaFiyatlar> OdaFiyatlari { get; set; }
        public DbSet<OdaFotograf> OdaFotograflari { get; set; }
        public DbSet<Rezervasyon> Rezervasyonlar { get; set; }
        public DbSet<RezervasyonDetay> RezervasyonDetaylari { get; set; }


        public AppDbcontext()
        {
            
        }
        public AppDbcontext(DbContextOptions<AppDbcontext> options):base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"server=127.0.0.1;User Id=postgres;password=1234;Database=Mellow");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // Burasi calismak zorunda. Cunku Identity'nin ihtiyac dusdugu tablolar olusmazs 

            builder.ApplyConfigurationsFromAssembly(Assembly.Load("Mellow.Entites"));

        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified)
                .ToList();

            foreach (var entity in entities)
            {
                if (entity.Entity is BaseEntity baseEntity)
                {
                    var now = DateTime.UtcNow;
                    if (entity.State == EntityState.Added)
                    {
                        baseEntity.CreatedAt = now;
                    }
                    else
                    {
                        baseEntity.UpdateAt = now;
                    }
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified)
                .ToList();
           
            foreach (var entity in entities)
            {
                if (entity.Entity is BaseEntity baseEntity)
                {
                    var now = DateTime.UtcNow;
                    if (entity.State == EntityState.Added)
                    {
                        baseEntity.CreatedAt = now;
                    }
                    else
                    {
                        baseEntity.UpdateAt = now;
                    }
                }
            }


            return base.SaveChanges();

        }

    }
}
