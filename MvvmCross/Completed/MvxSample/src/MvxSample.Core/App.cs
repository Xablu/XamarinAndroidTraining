using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MvxSample.Core.ViewModels.Main;

namespace MvxSample.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<MainViewModel>();
        }   
    }
}
