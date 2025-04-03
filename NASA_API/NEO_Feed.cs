using System.Text.Json;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("MAUI")]

namespace NASA_API;

internal class NEO_Feed
{
	private HttpClient? client;
	private string start_date = "";
	private string end_date = "";
	public Asteroid_Feed? asteroid_feed { get; set; }
	public NEO_Feed(string start_date, string end_date)
	{
		this.start_date = start_date;
		this.end_date = end_date;
	}
	public async Task getData()
	{
		client = new HttpClient();
		string API_KEY = "LGMGVmwQ1RaSZuNwJvp9kEb40Bas0tx8SciSsWUH";
		string call = "https://api.nasa.gov/neo/rest/v1/feed?start_date=" + start_date + "&end_date=" + end_date + "&api_key=" + API_KEY;
		string response = await client.GetStringAsync(call);
		asteroid_feed = JsonSerializer.Deserialize<Asteroid_Feed>(response);
		//Console.WriteLine(test);
	}
}
