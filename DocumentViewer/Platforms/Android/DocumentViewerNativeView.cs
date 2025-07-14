using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidX.CoordinatorLayout.Widget;
using AndroidX.Fragment.App;
using pdftron.PDF.Config;
using DocumentViewer.Controls;
using Color = Android.Graphics.Color;
using Uri = Android.Net.Uri;
using pdftron.PDF.Controls;
using pdftron.PDF.Model;

namespace DocumentViewer.Platforms.Android
{
    public class DocumentViewerNativeView : CoordinatorLayout
    {
        DocumentView2 _documentView;
        Context _context;
        DocumentViewerControl _documentViewerControl;

        public DocumentViewerNativeView(Context context, DocumentViewerControl documentViewerControl) : base(context)
        {
            _context = context;
            _documentViewerControl = documentViewerControl;

            SetBackgroundColor(Color.Black);

            // Create a RelativeLayout for sizing the document viewer
            RelativeLayout relativeLayout = new RelativeLayout(_context)
            {
                LayoutParameters = new CoordinatorLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent)
                {
                    Gravity = (int)GravityFlags.Center
                }
            };

            // Create DocumentView and position it in the RelativeLayout
            _documentView = new DocumentView2(context)
            {
                LayoutParameters = new RelativeLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent)
            };

            // Add to the layouts
            relativeLayout.AddView(_documentView);
            AddView(relativeLayout);
        }

        public void UpdateUri()
        {
            if (!string.IsNullOrEmpty(_documentViewerControl.Uri))
            {
                _documentView.SetDocumentUri(Uri.Parse(_documentViewerControl.Uri));
            }
        }

        public void UpdatePassword()
        {
            if (!string.IsNullOrEmpty(_documentViewerControl.Password))
            {
                _documentView.SetPassword(_documentViewerControl.Password);
            }
        }

        public void OpenDocument()
        {
            if (string.IsNullOrEmpty(_documentViewerControl.Uri))
            {
                return;
            }

            _documentView.SetViewerConfig(GetConfig());
            if (Context != null)
                _documentView.SetSupportFragmentManager(GetManager(Context));

            FragmentManager? GetManager(Context context)
            {
                FragmentManager? childManager = null;
                if (context is FragmentActivity)
                {
                    var activity = context as FragmentActivity;
                    var manager = activity?.SupportFragmentManager;

                    var fragments = manager?.Fragments;
                    if (fragments?.Count > 0)
                        childManager = fragments[0].ChildFragmentManager;
                    if (childManager != null)
                        return childManager;
                }
                return childManager;
            }

            ViewerConfig? GetConfig()
            {
                var annotStylePoly = new pdftron.PDF.Model.AnnotStyleProperty(pdftron.PDF.Model.AnnotStyle.CustomAnnotTypePerimeterMeasure)
                    .SetMeasurementPrecisions(new AnnotStyleProperty.MeasurementPrecision[]{
                        AnnotStyleProperty.MeasurementPrecision.Two,
                        AnnotStyleProperty.MeasurementPrecision.Three,
                    })
                    .SetMeasurementFractionPrecisions(new AnnotStyleProperty.MeasurementFractionPrecision[]{
                        AnnotStyleProperty.MeasurementFractionPrecision.Two,
                        AnnotStyleProperty.MeasurementFractionPrecision.Three,
                        AnnotStyleProperty.MeasurementFractionPrecision.Four,
                        AnnotStyleProperty.MeasurementFractionPrecision.Five,
                    })
                    .SetMeasurementBaseUnits(new AnnotStyleProperty.MeasurementBaseUnit[]{
                        AnnotStyleProperty.MeasurementBaseUnit.In,
                    })
                    .SetMeasurementTranslateUnits(new AnnotStyleProperty.MeasurementTranslateUnit[]{
                        AnnotStyleProperty.MeasurementTranslateUnit.M,
                        AnnotStyleProperty.MeasurementTranslateUnit.FractionIn,
                        AnnotStyleProperty.MeasurementTranslateUnit.FractionFtIn,
                    });
                var toolManagerBuilder = ToolManagerBuilder.From().AddAnnotStyleProperty(annotStylePoly);
                var builder = new ViewerConfig.Builder();
                var config = builder
                    ?.MultiTabEnabled(true)
                    ?.FullscreenModeEnabled(false)
                    ?.UseSupportActionBar(false)
                    ?.ToolManagerBuilder(toolManagerBuilder)
                    ?.SaveCopyExportPath(this.Context?.FilesDir?.AbsolutePath)
                    ?.Build();
                return config;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _documentView.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}