# Improved Blazor Quickstart for Mapsui

This is an improved version of the Blazor quickstart instructions that should replace the existing section in the Mapsui documentation at:
https://github.com/Mapsui/Mapsui/blob/main/docs/general/markdown/index.md

## Proposed New Blazor Section

```markdown
=== "Blazor"

    **Preparation:** Ensure you have .NET 8.0 SDK or later installed:

    ```console
    dotnet --version
    ```

    **Step 1:** Create a new Blazor WebAssembly project:

    ```console
    dotnet new blazorwasm -n MyMapApp -f net8.0
    cd MyMapApp
    ```

    **Step 2:** Add the Mapsui.Blazor package:

    ```console
    dotnet add package Mapsui.Blazor
    ```

    **Step 3:** In `Pages/Home.razor`, replace the content with:

    ```razor
    @page "/"
    @using Mapsui.UI.Blazor

    <PageTitle>Map</PageTitle>

    <div style="width: 100%; height: 100vh;">
        <MapControlComponent @ref="_mapControl" />
    </div>

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

    **Step 4:** Install the wasm-tools workload for native library support:

    ```console
    dotnet workload install wasm-tools-net8
    ```

    **Step 5:** Add the following to your `.csproj` file inside the `<PropertyGroup>` section:

    ```xml
    <WasmBuildNative>true</WasmBuildNative>
    ```

    Your PropertyGroup should look like this:
    ```xml
    <PropertyGroup>
      <TargetFramework>net8.0</TargetFramework>
      <Nullable>enable</Nullable>
      <ImplicitUsings>enable</ImplicitUsings>
      <WasmBuildNative>true</WasmBuildNative>
    </PropertyGroup>
    ```

    **Step 6:** Run the application:

    ```console
    dotnet run
    ```

    Navigate to the URL shown (typically http://localhost:5000) and you should see a map of the world.

    **Troubleshooting:**

    - **Build errors about missing workloads:**
      If you get an error like "To build this project, the following workloads must be installed: wasm-tools-net8", run:
      ```console
      dotnet workload install wasm-tools-net8
      ```

    - **Native library errors (DllNotFoundException):**
      This occurs if `WasmBuildNative` is not set to `true` in your `.csproj` file. See Step 5 above.

    - **Text is not displayed:**
      This should be resolved in newer versions of Mapsui (5.0.0+). If you still experience issues, ensure you have the latest version of Mapsui.Blazor.
```

## Summary of Changes

### Improvements Made:
1. **CLI-based approach**: Uses `dotnet` commands instead of IDE-specific Package Manager Console
2. **Correct file name**: Uses `Home.razor` (correct for .NET 8) instead of `Index.razor`
3. **Simplified HTML**: Removed unnecessary Bootstrap container divs, uses a simple wrapper div with inline style
4. **Fixed step numbering**: Sequential steps 1-6 (was 1,2,3,6)
5. **Updated .NET version**: Changed from .NET 7.0 to .NET 8.0
6. **Clearer code**: Simplified the code structure while maintaining functionality
7. **Better troubleshooting**: Updated with tested, working solution for native libraries
8. **Added preparation step**: Verifies .NET SDK is installed
9. **Explicit wasm-tools setup**: Clear instructions on installing workload and enabling native builds
10. **More consistent**: Matches the pattern of other platform quickstarts (especially Avalonia)
11. **Component styling**: Wraps MapControlComponent in a div (component doesn't accept style attribute directly)

### Issues Addressed:
- ✅ **File name error**: Index.razor → Home.razor (for .NET 8+)
- ✅ **Step numbering**: 1,2,3,6 → 1,2,3,4,5,6
- ✅ **Overly complex HTML**: Simplified to single wrapper div with component
- ✅ **IDE dependency**: Removed Package Manager Console requirements
- ✅ **Outdated .NET version**: Updated to .NET 8.0
- ✅ **Native library issues**: Added clear, tested solution with wasm-tools workload
- ✅ **Inconsistent format**: Now matches the CLI-based format of Avalonia quickstart
- ✅ **Component property error**: Fixed by wrapping in div instead of direct style attribute

### Testing Results:
- ✅ Created Blazor WebAssembly application with .NET 8.0
- ✅ Confirmed package installation works correctly
- ✅ Identified and resolved native library loading issue with wasm-tools workload
- ✅ Verified application builds without errors or warnings
- ✅ Tested runtime behavior - **map renders successfully!**
- ✅ Confirmed OpenStreetMap tiles load and display correctly
- ✅ Screenshot captured showing working map application

### Screenshot:
![Working Blazor Map Application](https://github.com/user-attachments/assets/d7304979-8b6a-40c6-9bd0-132d9b7625a9)

The map successfully renders with OpenStreetMap attribution visible.
