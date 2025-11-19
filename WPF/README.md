# Mapsui WPF Quickstart Test

This project tests the [Mapsui WPF quickstart guide](https://mapsui.com).

## Steps Followed

This project was created following these steps from the official guide:

**Step 1:** Create a new WPF application:
```bash
dotnet new wpf -o MapsuiQuickstart
```

**Step 2:** Add the Mapsui.Wpf package:
```bash
dotnet add package Mapsui.Wpf
```

**Step 3:** Modified `MainWindow.xaml.cs` to add the MapControl in the constructor **after** `InitializeComponent()`:
```csharp
var mapControl = new Mapsui.UI.Wpf.MapControl();
mapControl.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
Content = mapControl;
```

## Building

To build this project on Linux/macOS (cross-platform build):

```bash
cd MapsuiQuickstart
dotnet build
```

Note: The project includes `<EnableWindowsTargeting>true</EnableWindowsTargeting>` to allow building on non-Windows platforms.

## Running

This project requires Windows to run. On Windows:

```bash
cd MapsuiQuickstart
dotnet run
```

You should see a map of the world using OpenStreetMap tiles.

## Expected Result

The application should launch and display an interactive map showing OpenStreetMap tiles that you can pan and zoom.
