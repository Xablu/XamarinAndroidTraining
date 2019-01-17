using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace ColorViewer
{
    public class ColorsSliderFragment : Android.Support.V4.App.Fragment, SeekBar.IOnSeekBarChangeListener
    {
        SeekBar seekBarRed, seekBarGreen, seekBarBlue;
        TextView textRed, textGreen, textBlue;
        LinearLayout layout;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.ColorSliders, null);

            layout = view.FindViewById<LinearLayout>(Resource.Id.layoutSliders);

            textRed   = view.FindViewById<TextView>(Resource.Id.textRed);
            textGreen = view.FindViewById<TextView>(Resource.Id.textGreen);
            textBlue  = view.FindViewById<TextView>(Resource.Id.textBlue);

            seekBarRed   = view.FindViewById<SeekBar>(Resource.Id.seekBarRed);
            seekBarGreen = view.FindViewById<SeekBar>(Resource.Id.seekBarGreen);
            seekBarBlue  = view.FindViewById<SeekBar>(Resource.Id.seekBarBlue);

            seekBarRed.SetOnSeekBarChangeListener(this);
            seekBarGreen.SetOnSeekBarChangeListener(this);
            seekBarBlue.SetOnSeekBarChangeListener(this);

            return view;
        }

        public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
        {
            var color = new Color(seekBarRed.Progress, seekBarGreen.Progress, seekBarBlue.Progress);

            textRed.Text   = $"Red: {seekBarRed.Progress}";
            textGreen.Text = $"Green: {seekBarGreen.Progress}";
            textBlue.Text  = $"Blue: {seekBarBlue.Progress}";

            layout.SetBackgroundColor(color);
        }

        public void OnStartTrackingTouch(SeekBar seekBar)
        {
        }

        public void OnStopTrackingTouch(SeekBar seekBar)
        {
        }
    }
}