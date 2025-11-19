using Microsoft.UI.Xaml;
using Mapsui.Utilities;

namespace WinUI.Quickstart
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            MyMap.Map.Layers.Add(OpenStreetMap.CreateTileLayer());
        }
    }
}
