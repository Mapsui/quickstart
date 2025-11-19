namespace MapsuiQuickstart;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        
        // Following the Mapsui Windows Forms quickstart guide
        var mapControl = new Mapsui.UI.WindowsForms.MapControl();
        mapControl.Map.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
        Controls.Add(mapControl);
    }
}
