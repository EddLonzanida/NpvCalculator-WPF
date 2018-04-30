using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using FirstFloor.ModernUI.Windows;
using NpvCalculator.Core.Attributes;
using NpvCalculator.Core.Extensions;

namespace NpvCalculator.Core.Mef
{
    [Export]
    public class MefContentLoader : DefaultContentLoader
    {
        private readonly IEnumerable<Lazy<IContent, IContentMetadata>> contents;

        public MefContentLoader()
        {
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;
           
            //Service locator style.
            contents = App.classFactory.GetLazyExports<IContent, IContentMetadata>();
        }

        protected override object LoadContent(Uri uri)
        {
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return base.LoadContent(uri);

            // lookup the content based on the content uri in the content metadata
            var content = contents?.Where(r => r.Metadata.ContentUri.IsEqualTo(uri.OriginalString, ".xaml"))
            .Select(r => r.Value)
            .FirstOrDefault();

            Console.WriteLine($"LoadContent: {uri}");

            if (content == null)
            {
                throw new ArgumentException("Invalid uri: " + uri);
            }

            return content;
        }
    }
}
