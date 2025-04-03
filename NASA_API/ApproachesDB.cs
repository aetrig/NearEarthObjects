using System.ComponentModel.DataAnnotations.Schema;

namespace NASA_API;

[ComplexType]
internal class VelocityDB
{
	public required string kilometers_per_second { get; set; }
	public required string kilometers_per_hour { get; set; }
	public required string miles_per_hour { get; set; }
}

[ComplexType]
internal class DistanceDB
{
	public required string astronomical { get; set; }
	public required string lunar { get; set; }
	public required string kilometers { get; set; }
	public required string miles { get; set; }
}

internal class ApproachesDB
{
	public int Id { get; set; }
	public required string date { get; set; }
	public required VelocityDB velocity { get; set; }
	public required DistanceDB miss_distance { get; set; }
	public required string orbiting_body { get; set; }
	public required AsteroidDB asteroid { get; set; }

    public override string ToString()
    {
        return @$"
		Id: {Id},
		date: {date},
		velocity (km/s): {velocity.kilometers_per_second},
		velocity (km/h): {velocity.kilometers_per_hour},
		velocity (m/h): {velocity.miles_per_hour},
		miss distance (AU): {miss_distance.astronomical},
		miss distance (lunar): {miss_distance.lunar},
		miss distance (miles): {miss_distance.miles},
		miss distance (km): {miss_distance.kilometers},
		orbiting body: {orbiting_body},
		asteroid: {asteroid}
		";
    }
}
