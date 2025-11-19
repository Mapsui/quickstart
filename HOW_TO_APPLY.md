# How to Apply the Improved WPF Quickstart to Mapsui Documentation

This guide explains how to apply the improved WPF quickstart section to the Mapsui/Mapsui repository.

## Target Repository
**Repository**: Mapsui/Mapsui  
**Branch**: main  
**File**: `docs/general/markdown/index.md`

## Steps to Apply

### 1. Locate the WPF Section
In the file `docs/general/markdown/index.md`, find the section that starts with:
```markdown
=== "WPF"
```

This is around line 235 in the current version of the file.

### 2. Replace the Section
Replace the entire WPF section (from `=== "WPF"` to the next `===` section) with the improved version below.

### 3. New WPF Section Content

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

## What This Changes

### Old Version (4 steps, VS-only)
- Step 1: Start a new WPF application in Visual Studio
- Step 2: PM> Install-Package Mapsui.Wpf
- Step 3: Add code to MainWindow.xaml.cs
- Step 4: Run it

### New Version (4 steps, CLI-first)
- Prerequisites: .NET SDK 6.0+
- Step 1: `dotnet new wpf -n MyMapsuiApp`
- Step 2: `dotnet add package Mapsui.Wpf`
- Step 3: Add code to MainWindow.xaml.cs (same as before)
- Step 4: `dotnet build` and `dotnet run`
- Bonus: Collapsible Visual Studio alternative

## Benefits of This Change

1. ✅ **Universal Access**: Works with VS Code, Rider, Visual Studio, or CLI
2. ✅ **Modern Practices**: Uses .NET CLI (standard for .NET 6+)
3. ✅ **Automation Friendly**: Easy to script and automate
4. ✅ **Consistency**: Matches Avalonia guide style
5. ✅ **Tested**: Verified to work correctly in this PR

## Testing
This improved guide has been thoroughly tested:
- Created test project in `MapsuiWpfQuickstart/`
- Build succeeded with no errors
- All commands verified to work
- CodeQL security scan passed

## Commit Message Suggestion
```
Improve WPF quickstart guide with CLI-first approach

- Replace Visual Studio-only instructions with dotnet CLI commands
- Add prerequisites section (.NET SDK 6.0+)
- Add explicit build and run commands
- Move Visual Studio option to collapsible note
- Align with Avalonia guide style for consistency
- Improves accessibility for developers using different tools

Tested in Mapsui/quickstart#[PR_NUMBER]
```

## Questions?
If you have questions about these changes, please refer to:
- **WPF_QUICKSTART_TESTING.md**: Detailed testing and analysis
- **IMPROVED_WPF_QUICKSTART.md**: Full explanation of improvements
- **SUMMARY.md**: Comprehensive overview
