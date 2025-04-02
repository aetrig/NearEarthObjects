using Microsoft.EntityFrameworkCore;

namespace NASA_API;

class Program
{
	static void Main(string[] args)
	{
		// double test1 = 0.0291443905;
		// Console.WriteLine(test1);
		// Dictionary<string,double> test2 = new();
		// test2.Add("emi",0.3214);
		// Dictionary<string,Dictionary<string,double>> test3 = new();
		// test3.Add("luna", new Dictionary<string,double>("emi2", 14.124));
		// Console.WriteLine(test3["luna"]["emi2"]);


		// NEO_Feed t = new();
		// t.getData().Wait();

		// NEO_Lookup t2 = new();
		// t2.getData().Wait();
		AsteroidApproaches DbContext = new();
		// DbContext.asteroids.Add(new AsteroidDB
		// {
		// 	nasa_id = "11111",
		// 	name = "CCC_DDD",
		// 	magnitude = 240.5,
		// 	estimated_diameter = new Estimated_diameterDB {
		// 		estimated_diameter_max_km = 6.6,
		// 		estimated_diameter_min_km = 6.3,
		// 		estimated_diameter_max_m = 6600.0,
		// 		estimated_diameter_min_m = 6300.0,
		// 		estimated_diameter_max_miles = 0.0,
		// 		estimated_diameter_min_miles = 0.0,
		// 		estimated_diameter_max_feet = 0.0,
		// 		estimated_diameter_min_feet = 0.0,
		// 	},
		// 	is_potentially_hazardous = true,
		// 	is_sentry_object = true,
		// });
		
		//asteroidList[0].nasa_id = "22222";
		// DbContext.approaches.Add(new ApproachesDB
		// {
		// 	date = "25-06-2023",
		// 	velocity = new VelocityDB
		// 	{
		// 		kilometers_per_hour = "20",
		// 		kilometers_per_second = "1",
		// 		miles_per_hour = "3.6"
		// 	},
		// 	miss_distance = new DistanceDB
		// 	{
		// 		astronomical = "1",
		// 		lunar = "0.5",
		// 		kilometers = "300",
		// 		miles = "143.4"
		// 	},
		// 	orbiting_body = "Earth",
		// 	asteroid = asteroidList[0]
		// });
		
		

		// DbContext.asteroids.RemoveRange(DbContext.asteroids);
		// DbContext.approaches.RemoveRange(DbContext.approaches);
		// DbContext.SaveChanges();

		List<AsteroidDB> asteroidList = DbContext.asteroids.ToList<AsteroidDB>();
		List<ApproachesDB> approachesList = DbContext.approaches.ToList<ApproachesDB>();
		asteroidList.ForEach(e => Console.Write(e));
		approachesList.ForEach(e => Console.Write(e));
		// Console.WriteLine(asteroidList[2]);
	}
}
