using System.Text.Json;

namespace NASA_API;

public class NEO_Feed
{
	private HttpClient? client;
	public async Task getData()
	{
		client = new HttpClient();
		string start_date = "2025-03-24";
		string end_date = "2025-03-27";
		string API_KEY = "LGMGVmwQ1RaSZuNwJvp9kEb40Bas0tx8SciSsWUH";
		string call = "https://api.nasa.gov/neo/rest/v1/feed?start_date=" + start_date + "&end_date=" + end_date + "&api_key=" + API_KEY;
		string response = await client.GetStringAsync(call);
		Asteroid_Feed? test = JsonSerializer.Deserialize<Asteroid_Feed>(response);
		Console.WriteLine(test);
	}
}
