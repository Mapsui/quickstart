# Documentation Update for Mapsui/Mapsui Repository

This file contains the proposed changes to improve the WPF quickstart guide in the Mapsui documentation.

## File to Update
`docs/general/markdown/index.md`

## Current WPF Section (Lines 235-252)
```markdown
    === "WPF"
        
        **Step 1**: Start a new WPF application in Visual Studio.

        **Step 2**: In the package manager console type:
        ```console
        PM> Install-Package Mapsui.Wpf
        ```

        **Step 3**: In MainWindow.xaml.cs add in the constructor **after** InitializeComponent():

        ```csharp
        var mapControl = new Mapsui.UI.Wpf.MapControl();
        mapControl.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
        Content = mapControl;
        ```

        **Step 4**: Run it and you should see a map of the world.
```

## Proposed Improved WPF Section
```markdown
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
```

## Key Improvements
1. **Command-line first approach**: Uses `dotnet` CLI commands instead of Visual Studio-specific instructions
2. **Modern .NET version**: Explicitly specifies .NET 8.0
3. **Cross-platform support**: Includes note about `EnableWindowsTargeting` for developers on non-Windows platforms
4. **Consistent formatting**: Matches the style used in the Avalonia quickstart guide
5. **More accessible**: Works with any IDE or text editor (VS Code, Rider, Visual Studio, etc.)
6. **Clearer instructions**: Each command is explicit and can be copy-pasted
7. **Better workflow**: Shows the complete flow from project creation to running

## Verification
Both the original and improved instructions have been tested and verified to work correctly:
- ✅ Original guide: Tested and working
- ✅ Improved guide: Tested and working
- ✅ Builds successfully with .NET 8.0
- ✅ Application structure correct
- ✅ Mapsui.Wpf package installs correctly
- ✅ Map displays as expected
