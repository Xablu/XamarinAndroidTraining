using Android.App;
using Android.OS;
using Android.Views;

namespace Clock
{
	[Activity(Label = "Clock", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Android.Support.V7.App.AppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);

			var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
			base.SetSupportActionBar(toolbar);
			SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu_white_24dp);
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);

			Navigate(new TimeFragment());
		}

		void Navigate(Android.Support.V4.App.Fragment fragment)
		{
			var transaction = base.SupportFragmentManager.BeginTransaction();
			transaction.Replace(Resource.Id.contentFrame, fragment);
			transaction.Commit();
		}
	}
}