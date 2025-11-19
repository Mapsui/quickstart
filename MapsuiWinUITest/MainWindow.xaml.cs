using Microsoft.UI.Xaml;

namespace MapsuiWinUITest
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            rootFrame.Navigate(typeof(MainPage));
        }
    }
}
