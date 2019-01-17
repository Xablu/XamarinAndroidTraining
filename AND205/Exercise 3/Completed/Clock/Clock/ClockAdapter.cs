namespace Clock
{
	public class ClockAdapter : Android.Support.V4.App.FragmentPagerAdapter
	{
		Android.Support.V4.App.Fragment[] fragments;

		public ClockAdapter(Android.Support.V4.App.FragmentManager fm, Android.Support.V4.App.Fragment[] fragments)
			: base(fm)
		{
			this.fragments = fragments;
		}

		public override int Count
		{
			get { return fragments.Length; }
		}

		public override Android.Support.V4.App.Fragment GetItem(int position)
		{
			return fragments[position];
		}
	}
}