using System.Text.Json;

namespace NASA_API;

internal class NEO_Lookup
{
	private HttpClient? client;
	public async Task getData()
	{
		client = new HttpClient();
		//https://api.nasa.gov/neo/rest/v1/neo/3153530?api_key=LGMGVmwQ1RaSZuNwJvp9kEb40Bas0tx8SciSsWUH
		string asteroid_id = "3153530";
		string API_KEY = "LGMGVmwQ1RaSZuNwJvp9kEb40Bas0tx8SciSsWUH";
		string call = "https://api.nasa.gov/neo/rest/v1/neo/" + asteroid_id + "?api_key=" + API_KEY;
		string response = await client.GetStringAsync(call);
		Asteroid? test = JsonSerializer.Deserialize<Asteroid>(response);
		Console.WriteLine(test);
	}
}
