using System.Windows.Media;
using FirstFloor.ModernUI.Presentation;

namespace NpvCalculator.Pages.Settings.ViewModels
{
        public interface IAppearanceViewModel
        {
            LinkCollection Themes { get; }

            string[] FontSizes { get; }

            Color[] AccentColors { get; }

            Link SelectedTheme { get; set; }

            string SelectedFontSize { get; set; }

            Color SelectedAccentColor { get; set; }
        }

}
