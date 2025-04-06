using System.Collections.ObjectModel;
using System.Text.Json;
using NASA_API;

namespace MAUI;
public partial class MainPage : ContentPage
{
	int count = 0;
	private HttpClient client;
	public ObservableCollection<string> ApproachesList = new();
	public MainPage()
	{
		InitializeComponent();
		client = new();
		ApproachesListView.ItemsSource = ApproachesList;
		BindingContext = this;
	}

	private async void getFeedData(object sender, EventArgs e)
	{
		// NEO_Feed feed = new(StartDateEntry.Text, EndDateEntry.Text);
		// feed.getData().Wait();
		// asteroidFeed = feed.asteroid_feed;
		// testApproachesList = asteroidFeed.near_earth_objects[StartDateEntry.Text];
		// Console.Write(testApproachesList[0]);
		// testList.Add(StartDateEntry.Text + " " + EndDateEntry.Text);
		// AsteroidApproaches DbContext = new();
		//DbContext.asteroids.ToList().ForEach(a => testList.Add(a.nasa_id + " " + a.name));
		ApproachesList.Clear();
		string start_date = StartDateEntry.Text;
		string end_date = EndDateEntry.Text;
		string API_KEY = "LGMGVmwQ1RaSZuNwJvp9kEb40Bas0tx8SciSsWUH";
		try
		{
			string call = "https://api.nasa.gov/neo/rest/v1/feed?start_date=" + start_date + "&end_date=" + end_date + "&api_key=" + API_KEY;
			string response = await client.GetStringAsync(call);
			Asteroid_Feed asteroid_feed = JsonSerializer.Deserialize<Asteroid_Feed>(response);
			foreach (string date in asteroid_feed.near_earth_objects.Keys)
			{
				foreach (Asteroid asteroid in asteroid_feed.near_earth_objects[date])
				{
					string entry = "";
					entry += date + ":\n";
					entry += "nasa id: " + asteroid.id + " ";
					entry += "name: " + asteroid.name + "\n";
					ApproachesList.Add(entry);
				}
			}
		}
		catch
		{
			ApproachesList.Add("There was a problem with getting the data, check if the date format is correct");
		}
	}

	private async void getAsteroidData(object sender, EventArgs e)
	{
		string entry = "";
		string id = AsteroidIdEntry.Text;
		string API_KEY = "LGMGVmwQ1RaSZuNwJvp9kEb40Bas0tx8SciSsWUH";
		try
		{
			string call = "https://api.nasa.gov/neo/rest/v1/neo/" + id + "?api_key=" + API_KEY;
			string response = await client.GetStringAsync(call);
			Asteroid asteroid = JsonSerializer.Deserialize<Asteroid>(response);
			entry += "id: " + asteroid.id + " ";
			entry += "name: " + asteroid.name + "\n";
			entry += "magnitude: " + asteroid.absolute_magnitude_h + "\n";
			entry += "is potentially hazardous: " + asteroid.is_potentially_hazardous_asteroid + "\n";
			entry += "is sentry object: " + asteroid.is_sentry_object + "\n";
			entry += "maximal estimated diameter (km): " + asteroid.estimated_diameter.kilometers.estimated_diameter_max + "\n";
			entry += "minimal estimated diameter (km): " + asteroid.estimated_diameter.kilometers.estimated_diameter_min + "\n";
		}
		catch
		{
			entry = "There was a problem with getting the data, check if the asteroid ID is correct";
		}
		AsteroidDetailView.Text = entry;
	}
}

