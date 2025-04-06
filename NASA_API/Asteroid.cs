using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("MAUI")]
namespace NASA_API;

internal record Estimated_diameter(Diameter kilometers, Diameter meters, Diameter miles, Diameter feet);
internal record Diameter(double estimated_diameter_min, double estimated_diameter_max);
internal record Close_approach_data(string close_approach_date, string close_approach_date_full, Velocity relative_velocity, Distance miss_distance, string orbiting_body);
internal record Velocity(string kilometers_per_second, string kilometers_per_hour, string miles_per_hour);
internal record Distance(string astronomical, string lunar, string kilometers, string miles);
internal class Asteroid
{
	required public string id { get; set; }
	required public string name { get; set; }
	public double absolute_magnitude_h { get; set; }
	public bool is_potentially_hazardous_asteroid { get; set; }
	required public Estimated_diameter estimated_diameter { get; set; }
	public bool is_sentry_object { get; set; }
	required public List<Close_approach_data> close_approach_data { get; set; }
	public override string ToString()
	{
		string asteroid = @$"
		id: {id}
		name: {name}
		absolute magnitude h: {absolute_magnitude_h}
		is potentially hazardous: {is_potentially_hazardous_asteroid}
		estimated minimal diameter (km): {estimated_diameter.kilometers.estimated_diameter_min}
		estimated maximum diameter (km): {estimated_diameter.kilometers.estimated_diameter_max}
		estimated minimal diameter (m): {estimated_diameter.meters.estimated_diameter_min}
		estimated maximum diameter (m): {estimated_diameter.meters.estimated_diameter_max}
		is sentry object: {is_sentry_object}";

		close_approach_data.ForEach(item => asteroid += @$"
		close approach date: {item.close_approach_date_full}
		approach velocity (km/s): {item.relative_velocity.kilometers_per_second}
		miss distance (km): {item.miss_distance.kilometers}
		orbiting body: {item.orbiting_body}
		");
		return asteroid;
	}
}
