# Improved WinUI Quickstart Guide

This is an improved version of the WinUI quickstart guide with command-line instructions.

## Prerequisites

- Windows 10 version 1809 (build 17763) or later
- .NET 8.0 SDK or later ([download](https://dotnet.microsoft.com/download))
- Visual Studio 2022 17.8 or later (for IDE approach) with:
  - .NET Desktop Development workload
  - Windows App SDK C# Templates component
- Windows App SDK ([documentation](https://learn.microsoft.com/windows/apps/windows-app-sdk/))

## Approach 1: Using Visual Studio (Original Method)

**Step 1:** Create new 'Blank App. Packaged (WinUI 3 in Desktop)' in Visual Studio

**Step 2:** In the Package Manager Console, type:

```console
PM> Install-Package Mapsui.WinUI
```

**Step 3:** Open `MainWindow.xaml` and add namespace:

```xml
xmlns:winui="using:Mapsui.UI.WinUI"
```

Add MapControl to the Grid:

```xml
<Grid>
    <winui:MapControl x:Name="MyMap" VerticalAlignment="Stretch" HorizontalAlignment="Stretch" />
</Grid>
```

In `MainWindow.xaml.cs`, add namespace:

```csharp
using Mapsui.Utilities;
```

Add code to the constructor:

```csharp
public MainWindow()
{
    this.InitializeComponent();
    MyMap.Map.Layers.Add(OpenStreetMap.CreateTileLayer());
}
```

**Step 4:** Run it and you should see a map of the world.

---

## Approach 2: Using Command Line (Recommended for Automation)

### Option A: Using WinUI Project Template

**Step 1:** Install the Windows App SDK project templates (if not already installed):

```console
dotnet new install Microsoft.WindowsAppSDK.Templates
```

**Step 2:** Create a new WinUI 3 project:

```console
dotnet new winui -n MyMapsuiApp
cd MyMapsuiApp
```

**Step 3:** Add the Mapsui.WinUI NuGet package:

```console
dotnet add package Mapsui.WinUI
```

**Step 4:** Edit `MainWindow.xaml` to add the Mapsui namespace and control:

Add to the `<Window>` tag:
```xml
xmlns:winui="using:Mapsui.UI.WinUI"
```

Replace the Grid content:
```xml
<Grid>
    <winui:MapControl x:Name="MyMap" VerticalAlignment="Stretch" HorizontalAlignment="Stretch" />
</Grid>
```

**Step 5:** Edit `MainWindow.xaml.cs` to initialize the map:

Add using statement at the top:
```csharp
using Mapsui.Utilities;
```

Modify the constructor:
```csharp
public MainWindow()
{
    this.InitializeComponent();
    MyMap.Map.Layers.Add(OpenStreetMap.CreateTileLayer());
}
```

**Step 6:** Build and run the application:

```console
dotnet build
dotnet run
```

Or to run with a specific framework:
```console
dotnet run --framework net8.0-windows10.0.19041.0
```

### Option B: Manual Project Creation (For Advanced Users)

If the WinUI templates are not available, you can create the project manually:

**Step 1:** Create project directory and navigate to it:

```console
mkdir MyMapsuiApp
cd MyMapsuiApp
```

**Step 2:** Create the project file `MyMapsuiApp.csproj`:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>net8.0-windows10.0.19041.0</TargetFramework>
    <TargetPlatformMinVersion>10.0.17763.0</TargetPlatformMinVersion>
    <UseWinUI>true</UseWinUI>
    <EnableMsixTooling>true</EnableMsixTooling>
    <Platforms>x86;x64;ARM64</Platforms>
    <RuntimeIdentifiers>win-x86;win-x64;win-arm64</RuntimeIdentifiers>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.WindowsAppSDK" Version="1.6.*" />
    <PackageReference Include="Microsoft.Windows.SDK.BuildTools" Version="10.0.*" />
    <PackageReference Include="Mapsui.WinUI" Version="5.0.*" />
  </ItemGroup>

  <ItemGroup>
    <Manifest Include="app.manifest" />
  </ItemGroup>
</Project>
```

**Step 3:** Create `App.xaml`:

```xml
<Application
    x:Class="MyMapsuiApp.App"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <XamlControlsResources xmlns="using:Microsoft.UI.Xaml.Controls" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</Application>
```

**Step 4:** Create `App.xaml.cs`:

```csharp
using Microsoft.UI.Xaml;

namespace MyMapsuiApp
{
    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
        }

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            m_window.Activate();
        }

        private Window? m_window;
    }
}
```

**Step 5:** Create `MainWindow.xaml`:

```xml
<Window
    x:Class="MyMapsuiApp.MainWindow"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:winui="using:Mapsui.UI.WinUI">
    
    <Grid>
        <winui:MapControl x:Name="MyMap" VerticalAlignment="Stretch" HorizontalAlignment="Stretch" />
    </Grid>
</Window>
```

**Step 6:** Create `MainWindow.xaml.cs`:

```csharp
using Microsoft.UI.Xaml;
using Mapsui.Utilities;

namespace MyMapsuiApp
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            MyMap.Map.Layers.Add(OpenStreetMap.CreateTileLayer());
        }
    }
}
```

**Step 7:** Create `app.manifest`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<assembly manifestVersion="1.0" xmlns="urn:schemas-microsoft-com:asm.v1">
  <assemblyIdentity version="1.0.0.0" name="MyMapsuiApp.app"/>
  <compatibility xmlns="urn:schemas-microsoft-com:compatibility.v1">
    <application>
      <maxversiontested Id="10.0.19041.0"/>
      <supportedOS Id="{8e0f7a12-bfb3-4fe8-b9a5-48fd50a15a9a}" />
    </application>
  </compatibility>
</assembly>
```

**Step 8:** Create `Package.appxmanifest` (for packaged deployment):

```xml
<?xml version="1.0" encoding="utf-8"?>
<Package
  xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10"
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"
  IgnorableNamespaces="uap rescap">

  <Identity Name="MyMapsuiApp" Publisher="CN=YourName" Version="1.0.0.0" />

  <Properties>
    <DisplayName>My Mapsui App</DisplayName>
    <PublisherDisplayName>Your Name</PublisherDisplayName>
    <Logo>Assets\StoreLogo.png</Logo>
  </Properties>

  <Dependencies>
    <TargetDeviceFamily Name="Windows.Desktop" MinVersion="10.0.17763.0" MaxVersionTested="10.0.19041.0" />
  </Dependencies>

  <Resources>
    <Resource Language="x-generate" />
  </Resources>

  <Applications>
    <Application Id="App" Executable="$targetnametoken$.exe" EntryPoint="$targetentrypoint$">
      <uap:VisualElements
        DisplayName="My Mapsui App"
        Description="Mapsui WinUI Application"
        BackgroundColor="transparent"
        Square150x150Logo="Assets\Square150x150Logo.png"
        Square44x44Logo="Assets\Square44x44Logo.png">
        <uap:DefaultTile Wide310x150Logo="Assets\Wide310x150Logo.png" />
      </uap:VisualElements>
    </Application>
  </Applications>

  <Capabilities>
    <rescap:Capability Name="runFullTrust" />
  </Capabilities>
</Package>
```

**Step 9:** Restore packages and build:

```console
dotnet restore
dotnet build
```

**Step 10:** Run the application:

```console
dotnet run
```

---

## Troubleshooting

### Template Not Found Error

If you get an error when installing templates:
```
Microsoft.WindowsAppSDK.Templates could not be installed
```

**Solution:** Ensure you have Visual Studio 2022 17.8+ installed with the Windows App SDK component, or use the manual project creation method (Option B).

### XAML Compilation Errors

If you see errors related to XAML compilation:
- Ensure you're building on Windows (WinUI 3 requires Windows to build)
- Check that Windows 10 SDK is installed
- Verify your .NET SDK version is 8.0 or later

### Package Version Conflicts

If you encounter package version conflicts:
```console
dotnet list package --outdated
dotnet add package Microsoft.WindowsAppSDK --version [latest-version]
```

### Runtime Initialization Errors

If the map doesn't appear:
- Verify the namespace declaration in XAML: `xmlns:winui="using:Mapsui.UI.WinUI"`
- Check that `OpenStreetMap.CreateTileLayer()` is called after `InitializeComponent()`
- Ensure you have internet connectivity (needed to download map tiles)

### NullReferenceException on MyMap.Map

If you get a null reference error:
- Verify the `x:Name="MyMap"` attribute is set in XAML
- Ensure the control is properly initialized before accessing `MyMap.Map`

---

## Next Steps

After you have a basic map running:

1. **Customize the map**: Explore different tile layers and data sources
2. **Add interactivity**: Implement click handlers and gestures
3. **Add layers**: Display your own data on the map
4. **Style the map**: Customize colors, symbols, and labels

See the [Mapsui documentation](https://mapsui.com) for more information.

---

## Comparison: IDE vs CLI Approach

| Aspect | Visual Studio (IDE) | Command Line (CLI) |
|--------|--------------------|--------------------|
| **Ease of Use** | Easier for beginners | Better for experienced developers |
| **Automation** | Limited | Excellent (CI/CD friendly) |
| **Speed** | Slower (GUI overhead) | Faster (direct commands) |
| **Flexibility** | Template-driven | Full control over project structure |
| **Prerequisites** | Visual Studio required | Only .NET SDK required |
| **Learning Curve** | Lower | Higher |
| **Scriptability** | Not scriptable | Fully scriptable |

**Recommendation:** Use Visual Studio for learning and prototyping, CLI for production and automated workflows.
