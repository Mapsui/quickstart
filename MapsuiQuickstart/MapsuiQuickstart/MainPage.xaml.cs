using Mapsui.Utilities;

namespace MapsuiQuickstart;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
        MyMap.Map.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
    }
}
