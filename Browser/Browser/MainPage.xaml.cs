namespace Browser
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            if (!BrowserWebView.CanGoBack)
                BackBtn.IsEnabled = false;
            if (!BrowserWebView.CanGoForward)
                ForwardBtn.IsEnabled = false;
        }

        private void Navigate()
        {
            BrowserWebView.Source = new UrlWebViewSource()
            {
                Url = UrlEntry.Text
            };
        }

        private void BrowserWebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            if (BrowserWebView.CanGoBack)
                BackBtn.IsEnabled = true;
            else
                BackBtn.IsEnabled = false;

            if (BrowserWebView.CanGoForward)
                ForwardBtn.IsEnabled = true;
            else
                ForwardBtn.IsEnabled = false;
        }

        private void BackBtn_Pressed(object sender, EventArgs e)
            => BrowserWebView.GoBack();

        private void ForwardBtn_Pressed(object sender, EventArgs e)
            => BrowserWebView.GoForward();

        private void RefreshBtn_Pressed(object sender, EventArgs e)
            => BrowserWebView.Reload();

        private void GoBtn_Pressed(object sender, EventArgs e)
            => Navigate();

        private void UrlEntry_Completed(object sender, EventArgs e)
            => Navigate();
    }
}