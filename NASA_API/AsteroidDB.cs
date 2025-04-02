namespace NASA_API;

internal class AsteroidDB
{
	public int Id { get; set; }
	public required string nasa_id { get; set; }
	public required string name { get; set; }
	public required double magnitude { get; set; }
	public required Diameter diameter { get; set; }
	public required bool is_potentially_hazardous { get; set; }
	public required bool is_sentry_object { get; set; }
    public override string ToString()
    {
        return $"Id: {Id},\t name: {name}";
    }
}
