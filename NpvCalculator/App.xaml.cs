using System.ComponentModel.Composition;
using System.Windows;
using Eml.ClassFactory.Contracts;
using Eml.Mef;

namespace NpvCalculator
{
    [Export]
    public partial class App
    {
        public static IClassFactory classFactory { get; private set; }

        public App()
        {
            classFactory = Bootstrapper.Init(new[] { "NpvCalculator*.exe", "NpvCalculator*.dll" });
        }

        protected override void OnExit(ExitEventArgs e)
        {
            var container = classFactory.Container;

            classFactory = null;
            container.Dispose();

            base.OnExit(e);
        }
    }
}
