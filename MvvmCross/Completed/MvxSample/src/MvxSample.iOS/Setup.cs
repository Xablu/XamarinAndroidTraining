using MvvmCross.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Presenters;
using MvvmCross.Plugin.Sidebar;
using MvxSample.Core;

namespace MvxSample.iOS
{
    public class Setup : MvxIosSetup<App>
    {
        protected override IMvxIosViewPresenter CreateViewPresenter()
            => new MvxSidebarPresenter(ApplicationDelegate, Window);
    }
}
