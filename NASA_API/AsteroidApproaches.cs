using Microsoft.EntityFrameworkCore;

namespace NASA_API;

internal class AsteroidApproaches : DbContext
{
	public DbSet<AsteroidDB> asteroids { get; set; }
	//public DbSet<ApproachesDB> approaches { get; set; }
	public AsteroidApproaches()
	{
		Database.EnsureCreated();
	}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=AsteroidApproaches.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Diameter>().HasNoKey();
		modelBuilder.Ignore<Diameter>();

		modelBuilder.Entity<Distance>().HasNoKey();
		modelBuilder.Ignore<Distance>();

		modelBuilder.Entity<Velocity>().HasNoKey();
		modelBuilder.Ignore<Velocity>();
	}
}
