using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvxSample.Core.ViewModels.Main;
using MvxSample.Core.ViewModels.Settings;

namespace MvxSample.Core.ViewModels.Menu
{
    public class MenuViewModel : BaseViewModel
    {
        readonly IMvxNavigationService _navigationService;

        public IMvxAsyncCommand ShowHomeCommand { get; private set; }
        public IMvxAsyncCommand ShowSettingsCommand { get; private set; }
        public IMvxAsyncCommand ShowCitiesCommand { get; private set; }

        public MenuViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowHomeCommand = new MvxAsyncCommand(NavigateToHomeAsync);
            ShowSettingsCommand = new MvxAsyncCommand(NavigateToSettingsAsync);
            ShowCitiesCommand = new MvxAsyncCommand(NavigateToCitiesAsync);
        }

        private Task NavigateToHomeAsync()
        {
            return _navigationService.Navigate<MainViewModel>();
        }

        private Task NavigateToSettingsAsync()
        {
            return _navigationService.Navigate<SettingsViewModel>();
        }

        private Task NavigateToCitiesAsync()
        {
            return _navigationService.Navigate<CitiesViewModel>();
        }
    }
}
