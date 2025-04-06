using Microsoft.EntityFrameworkCore;

namespace NASA_API;

class Program
{
	static void Main(string[] args)
	{

		string newAsteroidId = "2474163";
		AsteroidApproaches DbContext = new();

		List<AsteroidDB> asteroidList = DbContext.asteroids.ToList<AsteroidDB>();
		List<ApproachesDB> approachesList = DbContext.approaches.ToList<ApproachesDB>();

		if (DbContext.asteroids.Where(a => a.nasa_id == newAsteroidId).Count() == 0) {
			Console.WriteLine($"There is no asteroid {newAsteroidId} in the DB");
			NEO_Lookup t2 = new(newAsteroidId);
			t2.getData().Wait();
			DbContext.addAsteroid(t2.asteroid);
		}
		else
		{
			Console.WriteLine($"There is asteroid {newAsteroidId} in the DB");
		}

		string startDate = "2025-04-03";
		string endDate = "2025-04-03";
		NEO_Feed t = new(startDate, endDate);
		t.getData().Wait();
		foreach (string date in t.asteroid_feed.near_earth_objects.Keys)
		{
			foreach (Asteroid asteroid in t.asteroid_feed.near_earth_objects[date])
			{
				foreach (Close_approach_data approach in asteroid.close_approach_data)
				{
					string Date = approach.close_approach_date_full;
					if (DbContext.approaches.Where(a => a.date == Date).Count() == 0)
					{
						//Add approach to DB
						if (DbContext.asteroids.Where(a => a.nasa_id == asteroid.id).Count() == 0)
						{
							//Add the asteroid appraoching if not already in the DB
							NEO_Lookup t2 = new(asteroid.id);
							t2.getData().Wait();
							DbContext.addAsteroid(t2.asteroid);
						}
						DbContext.addApproach(approach, asteroid);
					}
				}
			}
		}

		Console.WriteLine("Asteroids");
		asteroidList.ForEach(e => Console.Write(e));

		Console.WriteLine("\nApproaches");
		approachesList.ForEach(e => Console.Write(e));
	}
}
