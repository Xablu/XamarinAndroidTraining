using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvxSample.Core.ViewModels.Main;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvxSample.Core.ViewModels;

namespace MvxSample.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainContainerViewModel), Resource.Id.content_frame)]
    public class CitiesView : BaseFragment<CitiesViewModel>
    {
        protected override int FragmentLayoutId => Resource.Layout.CitiesView;
    }
}
