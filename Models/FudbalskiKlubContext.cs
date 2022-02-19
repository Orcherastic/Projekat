using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class FudbalskiKlubContext : DbContext
    {
        public DbSet<Igrac> Igraci { get; set; }

        public DbSet<TimFC> Timovi { get; set; }

        public DbSet<Menadzer> Menadzeri { get; set; }

        public DbSet<Pozicija> Pozicije { get; set; }

        public DbSet<Nacionalnost> Nacionalnostsi { get; set; }

        public FudbalskiKlubContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}