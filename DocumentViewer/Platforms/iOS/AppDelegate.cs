using Foundation;
using UIKit;

namespace DocumentViewer
{
   [Register("AppDelegate")]
   public class AppDelegate : MauiUIApplicationDelegate
   {
      protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

      public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
      {
         pdftron.PDFNet.Initialize("");
         Console.WriteLine(pdftron.PDFNet.GetVersion());

         return base.FinishedLaunching(application, launchOptions);
      }
   }
}