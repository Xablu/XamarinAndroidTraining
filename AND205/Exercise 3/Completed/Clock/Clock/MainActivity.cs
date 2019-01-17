using Android.App;
using Android.OS;

namespace Clock
{
	[Activity(Label = "Clock", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Android.Support.V4.App.FragmentActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);

			var fragments = new Android.Support.V4.App.Fragment[]
			{
				new TimeFragment(),
				new StopwatchFragment(),
				new AboutFragment()
			};

			var adapter = new ClockAdapter(base.SupportFragmentManager, fragments);

			var viewPager = FindViewById<Android.Support.V4.View.ViewPager>(Resource.Id.viewPager);

			viewPager.Adapter = adapter;
		}
	}
}