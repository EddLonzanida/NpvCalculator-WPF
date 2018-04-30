using System.ComponentModel.Composition;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
using NpvCalculator.Core.Attributes;
using NpvCalculator.Pages.Home.ViewModels;

namespace NpvCalculator.Pages.Home
{
    [ContentExport("/Pages/Home/Home")]
    public partial class Home : IContent
    {
        [ImportingConstructor]
        public Home(INpvCalculatorViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }


        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
        }
    }
}
