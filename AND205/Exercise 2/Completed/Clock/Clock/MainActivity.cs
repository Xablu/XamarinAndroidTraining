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
		
			var tabLayout = FindViewById<Android.Support.Design.Widget.TabLayout>(Resource.Id.tabLayout);

			tabLayout.TabSelected += OnTabSelected;

			Navigate(new TimeFragment());
		}

		void OnTabSelected(object sender, Android.Support.Design.Widget.TabLayout.TabSelectedEventArgs e)
		{
			switch (e.Tab.Position)
			{
				case 0: Navigate(new TimeFragment());      break;
				case 1: Navigate(new StopwatchFragment()); break;
				case 2: Navigate(new AboutFragment());     break;
			}
		}

		void Navigate(Android.Support.V4.App.Fragment fragment)
		{
			var transaction = base.SupportFragmentManager.BeginTransaction();
			transaction.Replace(Resource.Id.contentFrame, fragment);
			transaction.Commit();
		}
	}
}