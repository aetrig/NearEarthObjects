namespace NASA_API;

internal class ApproachesDB
{
	public int Id { get; set; }
	public required string date { get; set; }
	public required Velocity velocity { get; set; }
	public required Distance miss_distance { get; set; }
	public required string orbiting_body { get; set; }
	public required AsteroidDB asteroid { get; set; }
}
