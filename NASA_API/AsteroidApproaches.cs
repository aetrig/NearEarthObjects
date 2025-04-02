using Microsoft.EntityFrameworkCore;

namespace NASA_API;

internal class AsteroidApproaches : DbContext
{
	public DbSet<AsteroidDB> asteroids { get; set; }
	public DbSet<ApproachesDB> approaches { get; set; }
	public AsteroidApproaches()
	{
		Database.EnsureCreated();
	}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=../../../AsteroidApproaches.db");
    }
}
