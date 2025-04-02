using System.ComponentModel.DataAnnotations.Schema;

namespace NASA_API;

[ComplexType]
internal class Estimated_diameterDB
{
	public double estimated_diameter_min_km { get; set; }
	public double estimated_diameter_max_km { get; set; }
	public double estimated_diameter_min_m { get; set; }
	public double estimated_diameter_max_m { get; set; }
	public double estimated_diameter_min_miles { get; set; }
	public double estimated_diameter_max_miles { get; set; }
	public double estimated_diameter_min_feet { get; set; }
	public double estimated_diameter_max_feet { get; set; }

}
internal class AsteroidDB
{
	public int Id { get; set; }
	public required string nasa_id { get; set; }
	public required string name { get; set; }
	public required double magnitude { get; set; }
	public required Estimated_diameterDB estimated_diameter { get; set; }
	public required bool is_potentially_hazardous { get; set; }
	public required bool is_sentry_object { get; set; }
    public override string ToString()
    {
        return @$"
		Id: {Id},
		nasa id: {nasa_id},
		name: {name},
		magnitude: {magnitude},
		estimated diameter max (km): {estimated_diameter.estimated_diameter_max_km},
		estimated diameter min (km): {estimated_diameter.estimated_diameter_min_km},
		is potentially hazardous: {is_potentially_hazardous},
		is sentry object: {is_sentry_object}
		";
    }
}
