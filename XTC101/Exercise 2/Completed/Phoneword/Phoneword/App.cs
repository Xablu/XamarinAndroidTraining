using Phoneword.Core;
using Xamarin.Forms;
using Phoneword.UI.XamForms.Views;

namespace Phoneword.UI.XamForms
{
    public class App : Application
    {
        public static MainViewModel AppViewModel = null;

        public App()
        {
            var dialer = DependencyService.Get<IDialer>();
            AppViewModel = new MainViewModel(dialer);
            MainPage = new NavigationPage(new PhoneTranslatePage());
        }
    }
}
