namespace NASA_API;

public class Asteroid_Feed
{
	required public Dictionary<string, List<Asteroid>> near_earth_objects { get; set; }

    public override string ToString()
    {
        string output = "";
		foreach (KeyValuePair<string, List<Asteroid>> item in near_earth_objects)
		{
			output += "==================\n";
			output += item.Key + ":\n";
			output += "==================\n";
			foreach (Asteroid asteroid in item.Value)
			{
				output += asteroid;
			}
			output += "\n";
		}
		return output;
    }
}
