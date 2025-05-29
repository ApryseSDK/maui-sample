using DocumentViewer.Handlers;
using DocumentViewer.Controls;
using Microsoft.Extensions.Logging;

namespace DocumentViewer;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
           .UseMauiApp<App>()
           .ConfigureFonts(fonts =>
           {
               fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
               fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
           })
           .ConfigureMauiHandlers(handlers =>
           {
               handlers.AddHandler(typeof(DocumentViewerControl), typeof(DocumentViewerControlHandler));
           });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}
