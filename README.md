# quickstart

This repository contains test applications and documentation for improving the Mapsui Blazor quickstart guide.

## Purpose

This PR demonstrates testing and improvement of the Blazor quickstart instructions from the [Mapsui documentation](https://github.com/Mapsui/Mapsui/blob/main/docs/general/markdown/index.md).

## What's Included

### Test Applications
- **BlazorMapsuiTest/** - Working Blazor WebAssembly application that successfully renders a map using Mapsui
- **WpfMapsuiTest/** - WPF application template (for reference, cannot build on Linux)

### Documentation
- **BLAZOR_QUICKSTART_FINDINGS.md** - Detailed analysis of 7 major issues found with the current Blazor quickstart
- **IMPROVED_BLAZOR_QUICKSTART.md** - New, improved Blazor quickstart instructions ready for the Mapsui/Mapsui repository

## Key Findings

The current Blazor quickstart has several issues:
1. File name error (Index.razor vs Home.razor)
2. Step numbering error (skips steps 4-5)
3. Overly complex HTML structure
4. Native library loading errors
5. Outdated .NET version reference
6. IDE-specific instead of CLI commands
7. Incomplete troubleshooting

## Solution

The improved quickstart uses:
- .NET CLI commands for cross-platform compatibility
- .NET 8.0 (current LTS)
- Simplified HTML structure
- Clear wasm-tools workload setup
- Tested and verified working solution

**Screenshot of working application:**

![Working Blazor Map](https://github.com/user-attachments/assets/d7304979-8b6a-40c6-9bd0-132d9b7625a9)

## Next Steps

The improved Blazor quickstart instructions in `IMPROVED_BLAZOR_QUICKSTART.md` should be submitted as a PR to the [Mapsui/Mapsui](https://github.com/Mapsui/Mapsui) repository to update the documentation at `docs/general/markdown/index.md`.