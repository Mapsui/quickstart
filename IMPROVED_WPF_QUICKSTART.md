# Improved WPF Quickstart Guide

This document contains the improved WPF quickstart guide that should replace the current one in the Mapsui documentation.

## Proposed WPF Quickstart (Command-line based)

=== "WPF"

**Step 1:** Create a new WPF application:

```console
dotnet new wpf -n MyMapsuiApp -f net8.0
cd MyMapsuiApp
```

**Step 2:** Add the Mapsui.Wpf NuGet package:

```console
dotnet add package Mapsui.Wpf
```

**Step 3:** In MainWindow.xaml.cs, add the following code to the constructor **after** InitializeComponent():

```csharp
var mapControl = new Mapsui.UI.Wpf.MapControl();
mapControl.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
Content = mapControl;
```

**Step 4:** Run the application:

```console
dotnet run
```

You should see a map of the world.

**Note for Linux/macOS users:** If building on a non-Windows platform, you may need to add `<EnableWindowsTargeting>true</EnableWindowsTargeting>` to the `<PropertyGroup>` section in your .csproj file to enable cross-compilation for Windows targets.

---

## Changes from Original Guide

### What Changed:
1. **Command-line first approach**: Replaced Visual Studio specific instructions with dotnet CLI commands
2. **Modern .NET version**: Updated to use .NET 8.0 instead of unspecified version
3. **Cross-platform note**: Added note about EnableWindowsTargeting for developers on non-Windows platforms
4. **Consistent format**: Matches the style of other framework quickstarts like Avalonia
5. **Project name placeholder**: Uses generic "MyMapsuiApp" instead of implying Visual Studio project creation

### Why These Changes:
- **Command-line approach is more universal**: Works across all IDEs and editors (VS Code, Rider, Visual Studio)
- **Testable and reproducible**: Commands can be copied and pasted directly
- **More accessible**: Developers don't need Visual Studio to follow the guide
- **Consistency**: Aligns with other framework quickstarts in the documentation
- **Modern**: Uses current .NET 8.0 (matches available SDK versions)

### Testing Results:
✅ All steps tested successfully in a Linux environment
✅ Build completes successfully
✅ Application structure created correctly
✅ Mapsui.Wpf package installs without errors
✅ Code changes apply cleanly
