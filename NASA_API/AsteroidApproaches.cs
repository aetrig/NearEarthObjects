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
        optionsBuilder.UseSqlite(@"Data Source=AsteroidApproaches.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AsteroidDB>().ComplexProperty(e => e.estimated_diameter);
		modelBuilder.Entity<ApproachesDB>(b => {
			b.ComplexProperty(e => e.velocity);
			b.ComplexProperty(e => e.miss_distance);
			});
	}
	public void addAsteroid(Asteroid asteroid)
	{
		asteroids.Add(new AsteroidDB
		{
			nasa_id = asteroid.id,
			name = asteroid.name,
			magnitude = asteroid.absolute_magnitude_h,
			estimated_diameter = new Estimated_diameterDB
			{
				estimated_diameter_max_km = asteroid.estimated_diameter.kilometers.estimated_diameter_max,
				estimated_diameter_min_km = asteroid.estimated_diameter.kilometers.estimated_diameter_min,
				estimated_diameter_max_m = asteroid.estimated_diameter.meters.estimated_diameter_max,
				estimated_diameter_min_m = asteroid.estimated_diameter.meters.estimated_diameter_min,
				estimated_diameter_max_miles = asteroid.estimated_diameter.miles.estimated_diameter_max,
				estimated_diameter_min_miles = asteroid.estimated_diameter.miles.estimated_diameter_min,
				estimated_diameter_max_feet = asteroid.estimated_diameter.feet.estimated_diameter_max,
				estimated_diameter_min_feet = asteroid.estimated_diameter.feet.estimated_diameter_min,
			},
			is_potentially_hazardous = asteroid.is_potentially_hazardous_asteroid,
			is_sentry_object = asteroid.is_sentry_object,
		});
		SaveChanges();
	}
	public void addApproach(Close_approach_data approach, Asteroid asteroid)
	{
		approaches.Add(new ApproachesDB
		{
			date = approach.close_approach_date_full,
			velocity = new VelocityDB
			{
				kilometers_per_hour = approach.relative_velocity.kilometers_per_hour,
				kilometers_per_second = approach.relative_velocity.kilometers_per_second,
				miles_per_hour = approach.relative_velocity.miles_per_hour
			},
			miss_distance = new DistanceDB
			{
				astronomical = approach.miss_distance.astronomical,
				lunar = approach.miss_distance.lunar,
				kilometers = approach.miss_distance.kilometers,
				miles = approach.miss_distance.miles
			},
			orbiting_body = approach.orbiting_body,
			asteroid = asteroids.Where(a => a.nasa_id == asteroid.id).First()
		});
		SaveChanges();
	}
}
