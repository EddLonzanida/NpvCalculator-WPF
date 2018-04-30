using System.Windows.Controls;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
using NpvCalculator.Core.Attributes;

namespace NpvCalculator.Pages.Settings.UserControls
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    [ContentExport("/Pages/Settings/UserControls/About")]
    public partial class About : UserControl, IContent
    {
        public About()
        {
            InitializeComponent();
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
