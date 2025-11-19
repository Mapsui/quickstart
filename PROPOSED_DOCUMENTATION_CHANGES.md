# Proposed Changes to Mapsui Documentation - Uno Section

## Location
File: `docs/general/markdown/index.md` in the Mapsui/Mapsui repository

## Changes to the Uno Platform Section

Replace the existing "=== Uno" section with the following improved version:

---

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

---

## Summary of Changes

1. **Added command-line instructions** as the primary method
2. **Fixed OpenStreetMap namespace issue** - Using fully qualified name `Mapsui.Tiling.OpenStreetMap.CreateTileLayer()`
3. **Removed unnecessary using statement** - `using Mapsui.Utilities;` is not needed
4. **Added preparation step** - Installing Uno templates via CLI
5. **Added build and run instructions** - Both CLI and IDE options
6. **Improved troubleshooting** - Added desktop-only target option
7. **Kept IDE instructions** - Maintained compatibility for Visual Studio users
8. **Better structure** - More consistent with other platform sections (like Avalonia)

## Additional Recommended Changes

### Similar fixes needed in other sections:

1. **WinUI Section** - Same OpenStreetMap namespace issue:
   - Currently uses: `using Mapsui.Utilities;` and `OpenStreetMap.CreateTileLayer()`
   - Should use: `Mapsui.Tiling.OpenStreetMap.CreateTileLayer()`

2. **Android Section** - Already correct with `OpenStreetMap.CreateTileLayer()` but without namespace

3. **iOS Section** - Already correct with `OpenStreetMap.CreateTileLayer()` but without namespace

The inconsistency is that some sections import `using Mapsui.Utilities;` expecting `OpenStreetMap` to be available, but it's not in that namespace. The fix is to either:
- Use the fully qualified name (recommended): `Mapsui.Tiling.OpenStreetMap.CreateTileLayer()`
- Or add the correct using: `using Mapsui.Tiling;` and then use `OpenStreetMap.CreateTileLayer()`
