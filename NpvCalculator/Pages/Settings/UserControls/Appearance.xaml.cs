using System.ComponentModel.Composition;
using System.Windows.Controls;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
using NpvCalculator.Core.Attributes;
using NpvCalculator.Pages.Settings.ViewModels;

namespace NpvCalculator.Pages.Settings.UserControls
{
    /// <summary>
    /// Interaction logic for Appearance.xaml
    /// </summary>
    [ContentExport("/Pages/Settings/UserControls/Appearance")]
    public partial class Appearance : UserControl, IContent
    {
        [ImportingConstructor]
        public Appearance(IAppearanceViewModel vm)
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
