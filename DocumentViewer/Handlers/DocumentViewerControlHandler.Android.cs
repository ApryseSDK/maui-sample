#nullable enable
using Microsoft.Maui.Handlers;
using DocumentViewer.Controls;
using DocumentViewer.Platforms.Android;

namespace DocumentViewer.Handlers
{
    public partial class DocumentViewerControlHandler : ViewHandler<DocumentViewerControl, DocumentViewerNativeView>
    {
        protected override DocumentViewerNativeView CreatePlatformView() => new DocumentViewerNativeView(Context, VirtualView);

        protected override void ConnectHandler(DocumentViewerNativeView platformView)
        {
            base.ConnectHandler(platformView);

            // Perform any additional setup or event subscriptions here
            platformView.OpenDocument();
        }

        protected override void DisconnectHandler(DocumentViewerNativeView platformView)
        {
            platformView.Dispose();
            base.DisconnectHandler(platformView);
        }

        public static void MapUri(DocumentViewerControlHandler handler, DocumentViewerControl documentViewerControl)
        {
            handler.PlatformView?.UpdateUri();
        }

        public static void MapPassword(DocumentViewerControlHandler handler, DocumentViewerControl documentViewerControl)
        {
            handler.PlatformView?.UpdatePassword();
        }

        public static void MapOpenDocument(DocumentViewerControlHandler handler, DocumentViewerControl documentViewerControl, object? args)
        {
            handler?.PlatformView?.OpenDocument();
        }
    }
}