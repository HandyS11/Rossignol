using EF_Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_Model
{
    public class RossignolContextLocal : DbContext
    {
        public DbSet<LocalUserEntity> LocalUser { get; set; }
        public DbSet<EntryEntity> EncryptedEntriesSet { get; set; }

        public RossignolContextLocal()
        { }

        public RossignolContextLocal(DbContextOptions<RossignolContextLocal> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source=Rossignol.bd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntryEntity>().HasKey(n => n.Uid);
            modelBuilder.Entity<LocalUserEntity>().HasKey(n => n.Uid);
            //modelBuilder.Entity<ConnectedUserEntity>().HasKey(n => n.Uid);
            modelBuilder.Entity<ConnectedUserEntity>().HasBaseType(typeof(LocalUserEntity));    //Entity tyoe hierarchy mapping
            base.OnModelCreating(modelBuilder);
        }
    }
}