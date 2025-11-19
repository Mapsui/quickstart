# Mapsui Quickstart Tests

This repository contains test implementations of the Mapsui quickstart guides to ensure they work correctly. Each subdirectory contains a minimal working example following the official quickstart guide for that platform.

## Purpose

This repository validates that:
- All quickstart guides in the [Mapsui documentation](https://mapsui.com) work correctly
- New users can successfully follow the guides to integrate Mapsui
- Breaking changes are caught early before release

## Tested Platforms

The following platforms are tested in this repository:

- **WPF** - Windows Presentation Foundation
- **Avalonia** - Cross-platform UI framework
- **Windows Forms** - Classic Windows desktop apps

## Platforms Requiring Manual Testing

Some platforms require specific environments or IDEs and are documented but not automatically tested:

- **MAUI** - Requires Visual Studio with MAUI workload
- **Uno Platform** - Requires Visual Studio with Uno templates
- **Blazor** - WebAssembly application
- **WinUI** - Requires Windows 11 SDK
- **Eto Forms** - Cross-platform desktop
- **.NET for Android** - Requires Android SDK
- **.NET for iOS** - Requires macOS with Xcode

## Structure

```
/
├── WPF/                    # WPF quickstart test
├── Avalonia/               # Avalonia quickstart test
├── WindowsForms/           # Windows Forms quickstart test
└── README.md               # This file
```

## Running the Tests

Each platform subdirectory contains a complete .NET solution that can be built and run:

```bash
# Build all projects
dotnet build

# Build specific platform
cd WPF && dotnet build
cd Avalonia && dotnet build
cd WindowsForms && dotnet build
```

## Contributing

When updating quickstart guides in the main Mapsui repository, please also update the corresponding test project here to ensure the guide remains accurate.

## License

This repository follows the same license as [Mapsui](https://github.com/Mapsui/Mapsui).