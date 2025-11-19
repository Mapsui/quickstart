# INSTRUCTIONS FOR CREATING PR TO MAPSUI/MAPSUI

## Overview
This document provides the exact changes needed to update the WPF quickstart guide in the Mapsui/Mapsui repository.

## Repository and File
- **Repository**: https://github.com/Mapsui/Mapsui
- **File to modify**: `docs/general/markdown/index.md`
- **Section**: WPF quickstart (around line 235-252)

## How to Apply These Changes

### Option 1: Manual Edit via GitHub Web Interface
1. Navigate to https://github.com/Mapsui/Mapsui
2. Open `docs/general/markdown/index.md`
3. Click the edit (pencil) icon
4. Find the WPF section (search for `=== "WPF"`)
5. Replace the content as shown below
6. Create a pull request with title: "Improve WPF quickstart guide with command-line instructions"

### Option 2: Using Git Command Line
```bash
# Clone the repository
git clone https://github.com/Mapsui/Mapsui.git
cd Mapsui

# Create a new branch
git checkout -b improve-wpf-quickstart-cli

# Edit the file (use your preferred editor)
# Replace the WPF section as shown below

# Commit and push
git add docs/general/markdown/index.md
git commit -m "Improve WPF quickstart guide with command-line instructions

- Replace Visual Studio-centric instructions with dotnet CLI commands
- Add explicit .NET 8.0 target framework
- Include cross-platform note for EnableWindowsTargeting
- Make guide consistent with other framework quickstarts (e.g., Avalonia)
- Improve accessibility for developers using any IDE/editor"

git push origin improve-wpf-quickstart-cli

# Then create a PR via GitHub web interface
```

## EXACT CHANGES TO MAKE

### FIND THIS (Lines ~235-252):
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

### REPLACE WITH THIS:
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

## PR Description Template

```markdown
# Improve WPF Quickstart Guide

## Summary
This PR improves the WPF quickstart guide by using command-line based instructions instead of Visual Studio-specific ones, making it more accessible to developers using any IDE or editor.

## Changes
- Replace Visual Studio-specific instructions with `dotnet` CLI commands
- Add explicit .NET 8.0 target framework specification
- Include cross-platform note about `EnableWindowsTargeting` property
- Improve consistency with other framework quickstart guides (e.g., Avalonia)
- Make instructions more accessible and testable

## Benefits
1. **Universal accessibility**: Works with any IDE/editor (VS Code, Rider, Visual Studio, etc.)
2. **Modern .NET**: Uses current .NET 8.0 framework
3. **Testable**: Commands can be copy-pasted and tested directly
4. **Consistent**: Matches the style of other framework guides
5. **Cross-platform aware**: Includes notes for developers on non-Windows platforms

## Testing
Both the original and improved instructions have been tested in the Mapsui/quickstart repository:
- ✅ Original guide tested and working
- ✅ Improved guide tested and working
- ✅ Successfully builds with .NET 8.0
- ✅ Application runs and displays map correctly

See the verification at: https://github.com/Mapsui/quickstart/pull/[PR_NUMBER]

## Related
- Testing PR: https://github.com/Mapsui/quickstart/pull/[PR_NUMBER]
```

## Verification Reference
The changes have been tested and verified in the Mapsui/quickstart repository:
- Test of current guide: MapsuiWpfQuickstart folder
- Test of improved guide: MyMapsuiApp folder
- See: https://github.com/Mapsui/quickstart

## Contact
If you need assistance applying these changes, please refer to the testing PR in Mapsui/quickstart repository which demonstrates both approaches working successfully.
