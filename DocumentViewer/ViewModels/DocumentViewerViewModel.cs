using CommunityToolkit.Mvvm.ComponentModel;

namespace DocumentViewer.ViewModels
{
    internal class DocumentViewerViewModel : ObservableObject
    {

        private Models.DefaultDocument _defaultDocument;

        public string Uri
        {
            get => _defaultDocument.Uri;
            set
            {
                if (_defaultDocument.Uri != value)
                {
                    _defaultDocument.Uri = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get => _defaultDocument.Password;
            set
            {
                if (_defaultDocument.Password != value)
                {
                    _defaultDocument.Password = value;
                    OnPropertyChanged();
                }
            }
        }

        public DocumentViewerViewModel()
        {
            _defaultDocument = new Models.DefaultDocument();

        }
    }
}