# Git Patch for Mapsui Documentation Update

This patch file can be applied to the Mapsui/Mapsui repository to update the quickstart documentation.

## Instructions

1. Clone the Mapsui/Mapsui repository
2. Save this patch content (the section below) to a file named `quickstart-improvements.patch`
3. Apply the patch with: `git apply quickstart-improvements.patch`
4. Review changes, commit, and create a PR

## What This Patch Does

- Fixes OpenStreetMap namespace bug in Uno section (line 103-127)
- Adds command-line instructions to Uno section
- Improves troubleshooting section
- Fixes similar issue in WinUI section

## Manual Changes Required

Due to the complexity of the Uno section update, here are the exact text replacements needed:

### Change 1: Uno Section (Starting at line 101)

**FIND:** (The entire Uno section from line 101 to approximately line 155)
```markdown
    === "Uno"

        **Preparation:** [See Uno Platform getting started](https://platform.uno/docs/articles/get-started-vs.html)

        **Step 1:** Create new 'Uno Platform App' in Visual Studio

        **Step 2:** In the package manager console type:

        ```console
        PM> Install-Package Mapsui.Uno.WinUI
        ```

        Repeat this for all the targets you are using (Change the default Project in the Package Manager Console)

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

        **Step 4:** Run it and you should see a map of the world.
```

**REPLACE WITH:**
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
```

### Change 2: Uno Troubleshooting Section

**FIND:** (After the "Step 4" in Uno section)
```markdown
        **Troubleshooting:**

        - Unable to resolve the .NET SDK version as specified in the global.json.
        global.json (change the version to "6.0.400" or what is installed on the Computer)

        - Duplicate Attribute errors:
        Add following line to the ...Wpf.csproj.

        ```xml
            <!-- Work around https://github.com/dotnet/wpf/issues/6792 -->
            <ItemGroup>
            <FilteredAnalyzer Include="@(Analyzer->Distinct())" />
            <Analyzer Remove="@(Analyzer)" />
            <Analyzer Include="@(FilteredAnalyzer)" />
            </ItemGroup>
        </Target>
        ```
```

**REPLACE WITH:**
```markdown
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
```

### Change 3: WinUI Section (Around line 210)

**FIND:**
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

**REPLACE WITH:**
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

## Testing

These changes have been validated in the Mapsui/quickstart repository:
- Working implementation: https://github.com/Mapsui/quickstart
- Build succeeds with: `dotnet build`
- OpenStreetMap namespace fix confirmed working

## Commit Message Suggestion

```
Improve Uno quickstart guide with CLI instructions and namespace fixes

- Fix OpenStreetMap namespace bug (use Mapsui.Tiling.OpenStreetMap)
- Add command-line instructions using dotnet CLI
- Improve troubleshooting section with desktop-only option
- Fix XML snippet in duplicate analyzer workaround
- Apply same namespace fix to WinUI section
- Make guide accessible to non-Visual Studio users

Fixes issue where users following the guide would get compiler error
"OpenStreetMap does not exist in the current context"

Reference: https://github.com/Mapsui/quickstart
```
