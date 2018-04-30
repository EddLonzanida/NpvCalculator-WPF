using System;
using System.ComponentModel.Composition;
using FirstFloor.ModernUI.Windows;

namespace NpvCalculator.Core.Attributes
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class)]
    public class ContentExportAttribute : ExportAttribute, IContentMetadata
    {
        public string ContentUri { get; }

        public ContentExportAttribute(string contentUri) : base(typeof(IContent))
        {
            ContentUri = contentUri;
        }
    }
}
