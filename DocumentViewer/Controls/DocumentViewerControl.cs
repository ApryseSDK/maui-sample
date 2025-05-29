namespace DocumentViewer.Controls
{
    public class DocumentViewerControl : View
    {
        public static readonly BindableProperty UriProperty =
            BindableProperty.Create(nameof(Uri), typeof(string), typeof(DocumentViewerControl), "");

        public static readonly BindableProperty PasswordProperty =
            BindableProperty.Create(nameof(Password), typeof(string), typeof(DocumentViewerControl), "");

        public string Uri
        {
            get => (string)GetValue(UriProperty);
            set => SetValue(UriProperty, value);
        }

        public string Password
        {
            get => (string)GetValue(PasswordProperty);
            set => SetValue(PasswordProperty, value);
        }

        public event EventHandler? OpenDocument = delegate { };

        public DocumentViewerControl()
        {
        }

        public void Open()
        {
            OpenDocument?.Invoke(this, EventArgs.Empty);
            Handler?.Invoke(nameof(DocumentViewerControl.OpenDocument));
        }

        public void Open(string uri, string password)
        {
            if (Uri != uri)
                Uri = uri;
            if (Password != password)
                Password = password;

            Open();
        }
    }
}