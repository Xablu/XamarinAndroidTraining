using System.Threading.Tasks;
using MvvmCross.ViewModels;
using MvxSample.Core.Models;

namespace MvxSample.Core.ViewModels
{
    public class CitiesViewModel : MvxViewModel
    {
        public override Task Initialize()
        {
            Cities.Add(new City { Name = "Paris", IsCapital = true });
            Cities.Add(new City { Name = "Amsterdam", IsCapital = true });
            Cities.Add(new City { Name = "Frankfurt", IsCapital = false });
            Cities.Add(new City { Name = "New York", IsCapital = false });
            Cities.Add(new City { Name = "Buenos Aires", IsCapital = true });
            Cities.Add(new City { Name = "Barcelona", IsCapital = false });
            Cities.Add(new City { Name = "Washington DC", IsCapital = true });
            Cities.Add(new City { Name = "Tokio", IsCapital = true });
            Cities.Add(new City { Name = "Vancouver", IsCapital = false });

            return base.Initialize();
        }

        public MvxObservableCollection<City> Cities { get; set; } = new MvxObservableCollection<City>();
    }
}
