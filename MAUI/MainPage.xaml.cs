using System.Collections.ObjectModel;
using NASA_API;

namespace MAUI;
public partial class MainPage : ContentPage
{
	int count = 0;
	public ObservableCollection<string> testList = new();
	public MainPage()
	{
		InitializeComponent();
		AsteroidListView.ItemsSource = testList;
		BindingContext = this;
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
	private void getFeedData(object sender, EventArgs e)
	{
		// NEO_Feed feed = new(StartDateEntry.Text, EndDateEntry.Text);
		// feed.getData().Wait();
		// asteroidFeed = feed.asteroid_feed;
		// testAsteroidList = asteroidFeed.near_earth_objects[StartDateEntry.Text];
		// Console.Write(testAsteroidList[0]);
		testList.Add(StartDateEntry.Text + " " + EndDateEntry.Text);
		// AsteroidApproaches DbContext = new();
		// DbContext.asteroids.ToList().ForEach(a => testList.Add(a.nasa_id + " " + a.name));
	}
}

