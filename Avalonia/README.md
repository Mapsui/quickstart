# Mapsui Avalonia Quickstart Test

This project tests the [Mapsui Avalonia quickstart guide](https://mapsui.com).

## Steps Followed

This project was created following these steps from the official guide:

**Step 1:** Install the Avalonia templates:
```bash
dotnet new install Avalonia.Templates
```

**Step 2:** Create a new Avalonia project:
```bash
dotnet new avalonia.app -o MapsuiQuickstart
```

**Step 3:** Add the Mapsui.Avalonia nuget package:
```bash
dotnet add MapsuiQuickstart package Mapsui.Avalonia
```

**Step 4:** Modified `MainWindow.axaml.cs` to add the MapControl after `InitializeComponent()`:
```csharp
var mapControl = new Mapsui.UI.Avalonia.MapControl();
mapControl.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
Content = mapControl;
```

## Running

To build and run this project:

```bash
cd MapsuiQuickstart
dotnet build
dotnet run
```

You should see a map of the world using OpenStreetMap tiles.

## Expected Result

The application should launch and display an interactive map showing OpenStreetMap tiles that you can pan and zoom.
