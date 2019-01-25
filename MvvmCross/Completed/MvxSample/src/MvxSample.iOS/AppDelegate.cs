using Foundation;
using MvvmCross.Platforms.Ios.Core;
using MvxSample.Core;

namespace MvxSample.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
    }
}
