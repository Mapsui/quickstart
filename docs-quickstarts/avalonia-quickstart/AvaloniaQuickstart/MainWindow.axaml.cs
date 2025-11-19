using Avalonia.Controls;
using Mapsui.Tiling;

namespace AvaloniaQuickstart;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        var mapControl = new Mapsui.UI.Avalonia.MapControl();
        mapControl.Map?.Layers.Add(OpenStreetMap.CreateTileLayer());
        Content = mapControl;
    }
}