using Avalonia.Controls;

namespace MapsuiQuickstart;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        // Following the Mapsui Avalonia quickstart guide
        var mapControl = new Mapsui.UI.Avalonia.MapControl();
        mapControl.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
        Content = mapControl;
    }
}