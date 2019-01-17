using Android.App;
using Android.OS;
using Android.Runtime;

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

			var titles = CharSequence.ArrayFromStringArray(new [] { "Time", "Stopwatch", "About" }); 

			var adapter = new ClockAdapter(base.SupportFragmentManager, fragments, titles);

			var viewPager = FindViewById<Android.Support.V4.View.ViewPager>(Resource.Id.viewPager);

			viewPager.Adapter = adapter;

			var tabLayout = FindViewById<Android.Support.Design.Widget.TabLayout>(Resource.Id.tabLayout);
			tabLayout.SetupWithViewPager(viewPager);

			tabLayout.GetTabAt(0).SetIcon(Resource.Drawable.ic_access_time_white_24dp);
			tabLayout.GetTabAt(1).SetIcon(Resource.Drawable.ic_timer_white_24dp);
			tabLayout.GetTabAt(2).SetIcon(Resource.Drawable.ic_info_outline_white_24dp);
		}
	}
}