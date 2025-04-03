using Microsoft.EntityFrameworkCore;

namespace NASA_API;

class Program
{
	static void Main(string[] args)
	{

		string newAsteroidId = "2474163";
		//Console.WriteLine(t2.asteroid);
		AsteroidApproaches DbContext = new();
		//bool isAsteroidinDB = false;

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
		//Close_approach_data Approach = Asteroid.close_approach_data[0];

		// string Date = Approach.close_approach_date_full;
		//DbContext.approaches.Add(
		// ApproachesDB test = new ApproachesDB
		// {
		// 	date = testApproach.close_approach_date_full,
		// 	velocity = new VelocityDB
		// 	{
		// 		kilometers_per_hour = testApproach.relative_velocity.kilometers_per_hour,
		// 		kilometers_per_second = testApproach.relative_velocity.kilometers_per_second,
		// 		miles_per_hour = testApproach.relative_velocity.miles_per_hour
		// 	},
		// 	miss_distance = new DistanceDB
		// 	{
		// 		astronomical = testApproach.miss_distance.astronomical,
		// 		lunar = testApproach.miss_distance.lunar,
		// 		kilometers = testApproach.miss_distance.kilometers,
		// 		miles = testApproach.miss_distance.miles
		// 	},
		// 	orbiting_body = testApproach.orbiting_body,
		// 	asteroid = DbContext.asteroids.Where(a => a.nasa_id == t.asteroid_feed.near_earth_objects[today][1].id).First()
		// };
		
		// if (DbContext.approaches.Where(a => a.date == testDate).Count() != 0)
		// {
		// 	Console.WriteLine("Approach already in DB");
		// }
		// else
		// {
		// 	//Add to DB
		// 	if (DbContext.asteroids.Where(a => a.nasa_id == testAsteroid.id).Count() == 0)
		// 	{
		// 		NEO_Lookup t2 = new(testAsteroid.id);
		// 		t2.getData().Wait();
		// 		DbContext.addAsteroid(t2.asteroid);
		// 	}
		// 	DbContext.addApproach(testApproach, testAsteroid);
		// }
		//Console.WriteLine(DbContext.approaches.Where(a => a.date == test.date && a.asteroid.Id == test.asteroid.Id ).Count());

		// DbContext.asteroids.RemoveRange(DbContext.asteroids);
		// DbContext.approaches.RemoveRange(DbContext.approaches);
		//DbContext.SaveChanges();

		Console.WriteLine("Asteroids");
		asteroidList.ForEach(e => Console.Write(e));

		Console.WriteLine("\nApproaches");
		approachesList.ForEach(e => Console.Write(e));
	}
}
