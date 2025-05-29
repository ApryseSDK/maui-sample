using UIKit;
using Uri = Foundation.NSUrl;

using DocumentViewer.Controls;

using pdftron.PDF.Controls;

namespace DocumentViewer.Platforms.iOS
{
    public class DocumentViewerNativeView : UIView
    {
        PTTabbedDocumentViewController mTabViewController;
        DocumentViewerControl _documentViewerControl;

        Uri _uri = new Uri("");
        string _password = "";

        public DocumentViewerNativeView(DocumentViewerControl documentViewerControl)
        {
            _documentViewerControl = documentViewerControl;

            // Create the Mutli-Tab Document View Controller
            mTabViewController = new PTTabbedDocumentViewController();

            // Add to a navigation controller
            UINavigationController navigationController = new UINavigationController(mTabViewController);
            
            // Add the navigation controller to the current view            
            if (navigationController.View != null)
            {
                AddSubview(navigationController.View);

                // Define the layout for the navigation controller's view
                navigationController.View.Frame = Bounds;
                navigationController.View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
            }
        }

        public void UpdateUri()
        {
            if (string.IsNullOrEmpty(_documentViewerControl.Uri) || _uri.ToString() == _documentViewerControl.Uri)
                return;
            _uri = new Uri(_documentViewerControl.Uri);
        }

        public void UpdatePassword()
        {
            if (_password == _documentViewerControl.Password)
                return;
            _password = _documentViewerControl.Password;
        }

        public void OpenDocument()
        {
            mTabViewController.OpenDocumentWithURL(_uri, _password);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}