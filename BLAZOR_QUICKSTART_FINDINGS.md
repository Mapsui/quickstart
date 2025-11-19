# Blazor Quickstart Testing and Improvement Findings

## Test Date
2025-11-19

## Current Instructions Testing

### Issues Found with Current Blazor Quickstart

1. **File Name Issue**: Instructions reference `Index.razor`, but in .NET 8 Blazor WebAssembly template, the home page is `Home.razor` (changed from .NET 7).

2. **Native Library Loading Error**: When following the instructions exactly, the application fails with:
   ```
   System.DllNotFoundException: libSkiaSharp
   ```
   This occurs because the native WebAssembly libraries for SkiaSharp and HarfBuzzSharp aren't properly linked.

3. **Step Numbering Error**: Steps jump from Step 3 directly to Step 6, skipping Steps 4 and 5.

4. **Overly Complex**: Compared to other platforms (especially WPF), the Blazor instructions are unnecessarily complex:
   - Requires HTML container structure with Bootstrap classes
   - Requires custom CSS styling
   - Uses component reference pattern
   - Requires OnAfterRender lifecycle method
   
   Compare with WPF (simple and elegant):
   ```csharp
   var mapControl = new Mapsui.UI.Wpf.MapControl();
   mapControl.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
   Content = mapControl;
   ```

5. **Troubleshooting Section is Outdated**: The workaround mentions `HarfBuzzSharp.NativeAssets.WebAssembly` version 2.8.2.3, but the current version is 8.3.1.2, and the paths have changed. The workaround as documented doesn't work without enabling `WasmBuildNative`, which requires installing additional workloads.

6. **.NET Version**: References .NET 7.0 which is out of support. Should use .NET 8.0 or later.

7. **No CLI Instructions**: Uses IDE-specific instructions ("package manager console") instead of cross-platform CLI commands.

## Improved Quickstart Proposal

### Goals
1. Use `dotnet` CLI commands like the Avalonia quickstart
2. Simplify the code to match other platforms where possible
3. Fix the native library issue with clear, working instructions
4. Update to current .NET versions
5. Match the simplicity of the WPF pattern

### Proposed New Instructions

**Step 1:** Create a new Blazor WebAssembly project:
```bash
dotnet new blazorwasm -n MyMapApp -f net8.0
cd MyMapApp
```

**Step 2:** Add the Mapsui.Blazor package:
```bash
dotnet add package Mapsui.Blazor
```

**Step 3:** Replace the content in `Pages/Home.razor` with:
```razor
@page "/"
@using Mapsui.UI.Blazor

<PageTitle>Map</PageTitle>

<MapControlComponent @ref="_mapControl" style="width: 100%; height: 100vh;" />

@code {
    private MapControl? _mapControl;

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
        if (firstRender && _mapControl != null)
        {
            _mapControl.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
        }
    }
}
```

**Step 4:** Run the application:
```bash
dotnet run
```

Navigate to the URL shown (typically http://localhost:5000) and you should see a map of the world.

### Key Improvements
1. CLI-based approach (no IDE required)
2. Simplified HTML - no unnecessary container divs
3. Inline styling instead of separate style block
4. Clearer code with simpler component reference
5. Updated to .NET 8.0
6. Correct file name (Home.razor)
7. Fixed step numbering
8. More concise and similar to other platform quickstarts

### Known Issues
- The native library loading issue still exists in development mode
- This may require publishing the app or additional configuration for full functionality
- Consider adding a troubleshooting note if the map doesn't render

### Alternative Consideration
The native library loading issue was successfully resolved by:
1. Installing the wasm-tools-net8 workload
2. Setting WasmBuildNative=true in the project file
3. This enables native compilation during build, properly linking SkiaSharp and HarfBuzzSharp libraries

The solution has been tested and confirmed working with a screenshot showing the successfully rendered map.
