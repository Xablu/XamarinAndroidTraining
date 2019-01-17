using Android.OS;
using Android.Views;
using Android.Widget;

namespace ColorViewer
{
    public class ColorsEditTextFragment : Android.Support.V4.App.Fragment
    {
        EditText textRed, textGreen, textBlue;
        View colorDisplay;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.ColorEditText, null);

			colorDisplay = view.FindViewById<View>(Resource.Id.colorDisplay);

            textRed   = view.FindViewById<EditText>(Resource.Id.editTextRed);
            textGreen = view.FindViewById<EditText>(Resource.Id.editTextGreen);
            textBlue  = view.FindViewById<EditText>(Resource.Id.editTextBlue);

            textRed.TextChanged   += ColorTextChanged;
            textGreen.TextChanged += ColorTextChanged;
            textBlue.TextChanged  += ColorTextChanged;

            return view;
        }

		void ColorTextChanged(object sender, Android.Text.TextChangedEventArgs e)
		{
			int r, g, b;

			int.TryParse(textRed.Text, out r);
			int.TryParse(textGreen.Text, out g);
			int.TryParse(textBlue.Text, out b);

			r = SetColorInRange(r);
			g = SetColorInRange(g);
			b = SetColorInRange(b);

			if (textRed.Text   != r.ToString()) textRed.Text   = r.ToString();
			if (textGreen.Text != g.ToString()) textGreen.Text = g.ToString();
			if (textBlue.Text  != b.ToString()) textBlue.Text  = b.ToString();

			colorDisplay.SetBackgroundColor(new Android.Graphics.Color(r, g, b));
		}

        int SetColorInRange(int value)
        {
            value = System.Math.Min(255, value);
            value = System.Math.Max(0, value);

            return value;
        }
    }
}