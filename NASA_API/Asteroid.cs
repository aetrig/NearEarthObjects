namespace NASA_API;

public class Asteroid
{
	required public string id { get; set; }
	required public string name { get; set; }
	public bool is_potentially_hazardous_asteroid { get; set; }
	required public Dictionary<string,Dictionary<string,double>> estimated_diameter { get; set; }
	public override string ToString()
	{
		double estimated_diameter_kilometers_min = estimated_diameter["kilometers"]["estimated_diameter_min"];
		return $"id: {id}\nname: {name}\nIs potentially hazardous: {is_potentially_hazardous_asteroid}\nestimated minimal diameter: {estimated_diameter}\n\n";
	}
}
