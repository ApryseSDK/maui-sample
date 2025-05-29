namespace DocumentViewer.Models;

internal class DefaultDocument
{
    public string Uri { get; set; }
    public string Password { get; set; }

    public DefaultDocument()
    {
        Uri = "https://pdftron.s3.amazonaws.com/downloads/pl/PDFTRON_mobile_about.pdf";
        Password = "";
    }
}