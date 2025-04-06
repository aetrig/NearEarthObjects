using System.Text.Json;

namespace NASA_API;

internal class NEO_Lookup
{
	private HttpClient? client;
	private string asteroid_id = "";
	public Asteroid? asteroid { get; set; }
	public NEO_Lookup(string asteroid_id)
	{
		this.asteroid_id = asteroid_id;
	}
	public async Task getData()
	{
		client = new HttpClient();
		string API_KEY = "LGMGVmwQ1RaSZuNwJvp9kEb40Bas0tx8SciSsWUH";
		string call = "https://api.nasa.gov/neo/rest/v1/neo/" + asteroid_id + "?api_key=" + API_KEY;
		string response = await client.GetStringAsync(call);
		asteroid = JsonSerializer.Deserialize<Asteroid>(response);
	}
}
