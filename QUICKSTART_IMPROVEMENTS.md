# Mapsui Uno Quickstart - Improvements and Findings

## Summary
This document captures the experience of implementing the Uno Platform quickstart guide from the Mapsui documentation and proposes improvements.

## What Worked
1. The overall structure of the quickstart guide is clear
2. The steps are in a logical order
3. The XAML and code snippets are accurate

## Issues Found

### 1. OpenStreetMap Namespace Issue
**Problem:** The guide states to add `using Mapsui.Utilities;` and then use `OpenStreetMap.CreateTileLayer()`, but this doesn't work. The `Mapsui.Utilities` namespace doesn't export the `OpenStreetMap` class.

**Solution:** Use the fully qualified name `Mapsui.Tiling.OpenStreetMap.CreateTileLayer()` instead.

**Current Guide Code:**
```csharp
using Mapsui.Utilities;
...
MyMap.Map.Layers.Add(OpenStreetMap.CreateTileLayer());
```

**Should be:**
```csharp
MyMap.Map.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
```

Note: The `Mapsui.Utilities` namespace is not needed if using the fully qualified name.

### 2. Lack of Command-Line Instructions
**Problem:** The guide assumes users have Visual Studio and uses IDE-specific instructions (Package Manager Console).

**Proposed Improvement:** Provide command-line alternatives using .NET CLI:

## Improved Uno Quickstart Guide (Command-Line Focus)

### Prerequisites
- [.NET SDK 8.0 or later](https://dotnet.microsoft.com/download)
- [Uno Platform templates](https://platform.uno/docs/articles/get-started-cli.html)

### Step 1: Install Uno Platform Templates

```bash
dotnet new install Uno.Templates
```

### Step 2: Create a New Uno Platform App

```bash
dotnet new unoapp -n MyMapsuiApp
cd MyMapsuiApp
```

### Step 3: Add the Mapsui Package

Navigate to your main project directory (where the .csproj file is located):

```bash
cd MyMapsuiApp
dotnet add package Mapsui.Uno.WinUI
```

### Step 4: Update MainPage.xaml

Open `MainPage.xaml` and:

1. Add the Mapsui namespace to the Page element:
```xml
xmlns:mapsui="clr-namespace:Mapsui.UI.WinUI;assembly=Mapsui.UI.Uno.WinUI"
```

2. Replace the Grid content with:
```xml
<Grid>
    <mapsui:MapControl x:Name="MyMap" VerticalAlignment="Stretch" HorizontalAlignment="Stretch" />
</Grid>
```

### Step 5: Update MainPage.xaml.cs

Replace the MainPage constructor with:

```csharp
public MainPage()
{
    this.InitializeComponent();
    MyMap.Map.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
}
```

### Step 6: Build and Run

```bash
cd ..  # Back to solution directory
dotnet build
dotnet run --project MyMapsuiApp
```

You should see a map of the world.

## Additional Notes

### Target Framework Considerations
- The default Uno template targets multiple platforms: Android, iOS, WebAssembly, and Desktop
- If you only want to test on desktop to avoid installing mobile workloads, modify the `<TargetFrameworks>` in the .csproj file:

```xml
<TargetFrameworks>net10.0-desktop</TargetFrameworks>
```

### Troubleshooting

#### Missing Workloads
If you get errors about missing workloads (Android, iOS, etc.), you have two options:

1. Install the required workloads:
```bash
dotnet workload install android ios maccatalyst
```

2. Or simplify to desktop-only as noted above.

#### Build Errors with OpenStreetMap
If you get a build error about `OpenStreetMap` not existing, ensure you're using the fully qualified name:
```csharp
Mapsui.Tiling.OpenStreetMap.CreateTileLayer()
```

## Recommendations for Documentation Update

1. **Fix the OpenStreetMap namespace issue** - Use fully qualified name consistently
2. **Add command-line instructions** - Include `dotnet` CLI commands as the primary method
3. **Keep IDE instructions as alternative** - Move Visual Studio instructions to a collapsible section or note
4. **Add desktop-only option** - Include a note about simplifying to desktop-only targets for quick testing
5. **Update the namespace import** - Remove `using Mapsui.Utilities;` if not needed
6. **Consistency across platforms** - Apply the same OpenStreetMap fix to WinUI and other platforms

## Files Modified in This Implementation

- `MapsuiQuickstart/MapsuiQuickstart/MapsuiQuickstart.csproj` - Simplified to desktop-only target
- `MapsuiQuickstart/MapsuiQuickstart/MainPage.xaml` - Added Mapsui namespace and MapControl
- `MapsuiQuickstart/MapsuiQuickstart/MainPage.xaml.cs` - Added Mapsui initialization with correct namespace
