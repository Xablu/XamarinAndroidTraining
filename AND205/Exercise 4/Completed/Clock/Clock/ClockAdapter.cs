using Java.Lang;

namespace Clock
{
	public class ClockAdapter : Android.Support.V4.App.FragmentPagerAdapter
	{
		Android.Support.V4.App.Fragment[] fragments;
		ICharSequence[] titles;

		public ClockAdapter(Android.Support.V4.App.FragmentManager fm, Android.Support.V4.App.Fragment[] fragments, ICharSequence[] titles)
			: base(fm)
		{
			this.fragments = fragments;
			this.titles    = titles;
		}

		public override int Count
		{
			get { return fragments.Length; }
		}

		public override Android.Support.V4.App.Fragment GetItem(int position)
		{
			return fragments[position];
		}

		public override ICharSequence GetPageTitleFormatted(int position)
		{
			return titles[position];
		}
	}
}