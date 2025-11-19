# Documentation Update for Mapsui/Mapsui Repository

This document contains the exact changes to be made to `docs/general/markdown/index.md` in the Mapsui/Mapsui repository.

## Background

After implementing the Uno Platform quickstart guide from the Mapsui documentation, several issues were identified:

1. **OpenStreetMap namespace error**: The guide uses `using Mapsui.Utilities;` with `OpenStreetMap.CreateTileLayer()`, but `Mapsui.Utilities` doesn't export `OpenStreetMap`
2. **Lack of command-line instructions**: Only Visual Studio/IDE instructions are provided
3. **Inconsistency across platforms**: Different platforms handle the namespace differently

## Changes Required

### Change 1: Update the Uno Platform Section

**Location**: Line ~100 in `docs/general/markdown/index.md` (the "=== Uno" section)

**Replace the entire Uno section with:**

```markdown
    === "Uno"

        **Preparation:** 
        
        Install the Uno Platform templates if not already installed:

        ```console
        dotnet new install Uno.Templates
        ```

        Or see the [Uno Platform getting started guide](https://platform.uno/docs/articles/get-started.html) for IDE-based setup.

        **Step 1:** Create a new Uno Platform App

        Using command line:
        ```console
        dotnet new unoapp -n MyMapsuiApp
        cd MyMapsuiApp/MyMapsuiApp
        ```

        Or in Visual Studio: File → New → Project → "Uno Platform App"

        **Step 2:** Add the Mapsui.Uno.WinUI package

        Using command line (from the project directory where the .csproj file is):
        ```console
        dotnet add package Mapsui.Uno.WinUI
        ```

        Or in Visual Studio Package Manager Console:
        ```console
        PM> Install-Package Mapsui.Uno.WinUI
        ```

        Note: If you have multiple platform targets, you may need to repeat this for each target project.

        **Step 3:** Open MainPage.xaml and add namespace:

        ```xml
        xmlns:mapsui="clr-namespace:Mapsui.UI.WinUI;assembly=Mapsui.UI.Uno.WinUI"
        ```

        Add MapControl to the Grid:

        ```xml
        <Grid>
            <mapsui:MapControl x:Name="MyMap" VerticalAlignment="Stretch" HorizontalAlignment="Stretch" />
        </Grid>
        ```

        In MainPage.xaml.cs, add code to the constructor:

        ```csharp
        public MainPage()
        {
            this.InitializeComponent();
            MyMap.Map.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
        }
        ```

        **Step 4:** Build and run

        Using command line (from the solution directory):
        ```console
        cd ..
        dotnet build
        dotnet run --project MyMapsuiApp
        ```

        Or in Visual Studio: Press F5 to run.

        You should see a map of the world.

        **Troubleshooting:**

        - **Simplifying to desktop-only targets:** If you want to avoid installing mobile workloads for quick testing, modify the `<TargetFrameworks>` in the .csproj file:
        
        ```xml
        <TargetFrameworks>net10.0-desktop</TargetFrameworks>
        ```

        - **Unable to resolve the .NET SDK version:** If you get an error about the .NET SDK version in global.json, update the version to match what's installed on your computer (e.g., "8.0.100").

        - **Duplicate Attribute errors:** Add the following to your .csproj file:

        ```xml
        <!-- Work around https://github.com/dotnet/wpf/issues/6792 -->
        <Target Name="RemoveDuplicateAnalyzers" BeforeTargets="CoreCompile">
            <ItemGroup>
                <FilteredAnalyzer Include="@(Analyzer->Distinct())" />
                <Analyzer Remove="@(Analyzer)" />
                <Analyzer Include="@(FilteredAnalyzer)" />
            </ItemGroup>
        </Target>
        ```
        
        - **System.MissingMethodException:** See solution at https://github.com/unoplatform/uno/issues/9297
        
        Upgrading to the latest Uno.UI version should help too.
```

### Change 2: Update the WinUI Section (Same OpenStreetMap Issue)

**Location**: Around line 200 in the "=== WinUI" section

**Find this code block:**
```csharp
        In MainPage.xaml.cs, add namespace:

        ```csharp
        using Mapsui.Utilities;
        ```

        Add code to the constructor:

        ```csharp
        public MainPage()
        {
            this.InitializeComponent();
            MyMap.Map.Layers.Add(OpenStreetMap.CreateTileLayer());
        }
        ```
```

**Replace with:**
```csharp
        In MainPage.xaml.cs, add code to the constructor:

        ```csharp
        public MainPage()
        {
            this.InitializeComponent();
            MyMap.Map.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
        }
        ```
```

## Summary of Changes

1. **Fixed OpenStreetMap namespace issue** in both Uno and WinUI sections
   - Changed from: `using Mapsui.Utilities;` + `OpenStreetMap.CreateTileLayer()`
   - Changed to: `Mapsui.Tiling.OpenStreetMap.CreateTileLayer()`

2. **Added command-line instructions** to Uno section
   - `dotnet new install Uno.Templates`
   - `dotnet new unoapp -n MyMapsuiApp`
   - `dotnet add package Mapsui.Uno.WinUI`
   - `dotnet build` and `dotnet run`

3. **Improved troubleshooting** in Uno section
   - Added desktop-only target option
   - Clarified SDK version issue
   - Fixed XML snippet for duplicate analyzer workaround

4. **Maintained backward compatibility**
   - Kept IDE instructions alongside CLI instructions
   - Preserved all existing troubleshooting tips

## Testing

These changes have been validated by:
1. Creating a working Uno Platform app following the new instructions
2. Successfully building and running the app
3. Confirming the OpenStreetMap namespace fix works correctly

See the reference implementation in: https://github.com/Mapsui/quickstart
