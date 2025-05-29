namespace DocumentViewer.Views;

public partial class DocumentViewerPage : ContentPage
{
    public DocumentViewerPage()
    {
        InitializeComponent();
    }

    void OnPageUnloaded(object sender, EventArgs e)
    {
        documentViewer.Handler?.DisconnectHandler();
    }
}
