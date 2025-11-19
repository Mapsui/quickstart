# Mapsui Avalonia Quick-start

This sample implements the Mapsui Avalonia quick-start guide from the [Mapsui v5 documentation](https://mapsui.com/v5/#__tabbed_1_2).

## Implementation Overview

This quick-start demonstrates how to create a minimal Avalonia application with Mapsui map functionality. The implementation follows the v5 documentation steps:

### Files and Their Purpose

- **AvaloniaQuickstart.csproj**: Project file targeting .NET 9.0 with Mapsui.Avalonia package reference
- **MainWindow.axaml.cs**: Contains the MapControl initialization and OpenStreetMap tile layer setup
- **MainWindow.axaml**: Main window XAML definition
- **App.axaml** & **App.axaml.cs**: Application entry point and configuration
- **Program.cs**: Application startup code

### Mapping to v5 Quick-start Steps

1. **Create Avalonia Application**: Created using `dotnet new avalonia.app`
2. **Add Mapsui.Avalonia Package**: Added via `dotnet add package Mapsui.Avalonia` (version 5.0.0)
3. **Initialize MapControl**: Implemented in `MainWindow.axaml.cs` constructor
4. **Add OpenStreetMap Layer**: Using `OpenStreetMap.CreateTileLayer()` from `Mapsui.Tiling`
5. **Assign to Content**: Set `Content = mapControl` to display the map

### Key Code (MainWindow.axaml.cs)

```csharp
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
```

## Target Framework Choice

**Important Note**: The Mapsui v5 Avalonia quick-start documentation **does not specify a recommended .NET version**. 

For this implementation, we have explicitly chosen **.NET 9** for the following reasons:
- Consistency with other framework examples in this repository
- Latest stable .NET version available at the time of implementation
- Full compatibility with Mapsui.Avalonia 5.0.0
- Modern C# language features and performance improvements

## Build Instructions (Linux)

### Prerequisites

- .NET 9 SDK or later
- Linux environment (tested on Ubuntu)

### Build Steps

1. Navigate to the project directory:
```bash
cd docs-quickstarts/avalonia-quickstart/AvaloniaQuickstart
```

2. Restore dependencies (if not already done):
```bash
dotnet restore
```

3. Build the project:
```bash
dotnet build
```

4. Run the application:
```bash
dotnet run
```

### Expected Behavior

When run on a Linux desktop environment with X11 or Wayland:
- A window titled "AvaloniaQuickstart" should appear
- The window should display an interactive map with OpenStreetMap tiles
- You should be able to pan and zoom the map

### CI/Headless Limitations

Note: In CI environments or headless Linux systems without a display server, the application will fail to launch with display-related errors. This is expected behavior for GUI applications. See `RESULTS.md` for actual build and run logs.

## Package Versions

- Avalonia: 11.3.9
- Mapsui.Avalonia: 5.0.0
- .NET: 9.0

## Documentation Improvement Suggestions

As documented in `RESULTS.md`, we recommend that the Mapsui v5 documentation be updated to include:
1. A recommended target framework version (e.g., .NET 9)
2. Clear minimum .NET version requirements
3. Any platform-specific considerations for running the sample
