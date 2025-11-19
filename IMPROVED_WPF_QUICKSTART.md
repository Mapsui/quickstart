# Improved WPF Quickstart Section for Mapsui Documentation

This is the improved WPF section to replace the existing one in the Mapsui documentation at:
https://github.com/Mapsui/Mapsui/blob/main/docs/general/markdown/index.md

## Replacement Section (for the === "WPF" tab)

```markdown
=== "WPF"
        
    **Prerequisites:** .NET SDK 6.0 or higher

    **Step 1:** Create a new WPF application

    ```console
    dotnet new wpf -n MyMapsuiApp
    cd MyMapsuiApp
    ```

    **Step 2:** Add the Mapsui.Wpf package

    ```console
    dotnet add package Mapsui.Wpf
    ```

    **Step 3:** Open MainWindow.xaml.cs and add the following code to the constructor **after** InitializeComponent():

    ```csharp
    var mapControl = new Mapsui.UI.Wpf.MapControl();
    mapControl.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
    Content = mapControl;
    ```

    **Step 4:** Build and run

    ```console
    dotnet build
    dotnet run
    ```

    You should see a map of the world.

    ??? note "Using Visual Studio"
        If you prefer using Visual Studio:
        
        1. Create a new WPF App (.NET) project
        2. In the Package Manager Console type: `Install-Package Mapsui.Wpf`
        3. Follow steps 3-4 above
```

## Key Changes from Original

### What Was Changed
1. **Added Prerequisites**: Explicitly states .NET SDK 6.0 or higher requirement
2. **Command-line First**: All main instructions use `dotnet` CLI commands
3. **Replaced Visual Studio Steps**: 
   - Old: "Start a new WPF application in Visual Studio"
   - New: "dotnet new wpf -n MyMapsuiApp"
4. **Package Installation**:
   - Old: "PM> Install-Package Mapsui.Wpf" (Visual Studio Package Manager Console)
   - New: "dotnet add package Mapsui.Wpf" (Universal CLI command)
5. **Added Build Step**: Explicitly shows how to build with "dotnet build"
6. **Run Command**: Shows "dotnet run" instead of implicit "Run it"
7. **Visual Studio Option**: Moved to collapsible note section for those who prefer IDE

### Why These Changes
1. **Accessibility**: Works with any IDE (VS Code, Rider, Visual Studio) or command line
2. **Modern .NET Practices**: Aligns with .NET SDK CLI-first approach
3. **Automation Friendly**: Can be easily scripted or automated
4. **Cross-Platform Development**: More inclusive of developers on different platforms
5. **Consistency**: Matches the style of the Avalonia quickstart guide which already uses CLI commands

### Benefits
- Easier for beginners who may not have Visual Studio
- Better for CI/CD and automated testing
- More maintainable (CLI commands are more stable than IDE instructions)
- Follows the pattern already established in the Avalonia guide
- Visual Studio users still have their option in the expandable note

## Testing Verification
This improved guide was tested and verified to work correctly:
- ✅ Project creation successful
- ✅ Package installation successful  
- ✅ Build completed without errors
- ✅ Code modifications applied correctly
- ✅ All steps can be completed via command line
