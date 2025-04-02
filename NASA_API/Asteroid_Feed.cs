namespace NASA_API;

internal class Asteroid_Feed
{
	public int element_count { get; set; }
	required public Dictionary<string, List<Asteroid>> near_earth_objects { get; set; }

    public override string ToString()
    {
        string output = "";
		output += $"Number of entries: {element_count}\n\n";
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
