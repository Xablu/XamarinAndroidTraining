using Android.App;
using Android.Widget;
using Android.OS;

namespace ColorViewer
{
    [Activity(Label = "ColorViewer", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Android.Support.V4.App.FragmentActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView (Resource.Layout.Main);

            FindViewById<Button>(Resource.Id.buttonSliders).Click += ButtonSlidersClick;
            FindViewById<Button>(Resource.Id.buttonEditText).Click += ButtonEditTextClick;
        }

        void ButtonEditTextClick(object sender, System.EventArgs e)
        {
        }

        void ButtonSlidersClick(object sender, System.EventArgs e)
        {
        }
    }
}