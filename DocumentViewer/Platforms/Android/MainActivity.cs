using Android.App;
using Android.Content.PM;
using Android.OS;
using pdftron;

namespace DocumentViewer;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges =
 ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout |
 ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    public static MainActivity? Instance { get; private set; }

    protected override void OnCreate(Bundle? bundle)
    {
        base.OnCreate(bundle);

        Instance = this;

        try
        {
            pdftron.PDF.Tools.Utils.AppUtils.InitializePDFNetApplication(this);
            Console.WriteLine(PDFNet.GetVersionString());
        }
        catch (pdftron.Common.PDFNetException e)
        {
            Console.WriteLine(e.GetMessage());
            return;
        }
    }
}
