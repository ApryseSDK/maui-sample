#if IOS
using PlatformView = DocumentViewer.Platforms.iOS.DocumentViewerNativeView;
#elif ANDROID
using PlatformView = DocumentViewer.Platforms.Android.DocumentViewerNativeView;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID)
using PlatformView = System.Object;
#endif
using DocumentViewer.Controls;
using Microsoft.Maui.Handlers;

namespace DocumentViewer.Handlers
{
    public partial class DocumentViewerControlHandler
    {
        public static IPropertyMapper<DocumentViewerControl, DocumentViewerControlHandler> PropertyMapper = new PropertyMapper<DocumentViewerControl, DocumentViewerControlHandler>(ViewHandler.ViewMapper)
        {
            [nameof(DocumentViewerControl.Uri)] = MapUri,
            [nameof(DocumentViewerControl.Password)] = MapPassword
        };

        public static CommandMapper<DocumentViewerControl, DocumentViewerControlHandler> CommandMapper = new(ViewCommandMapper)
        {
            [nameof(DocumentViewerControl.OpenDocument)] = MapOpenDocument
        };

        public DocumentViewerControlHandler() : base(PropertyMapper, CommandMapper)
        {
        }
    }
}