# Updated Mapsui Documentation for WinUI

This directory contains the proposed update to the Mapsui documentation.

## File Description

- **index.md** - Updated version of `docs/general/markdown/index.md` from the Mapsui/Mapsui repository

## What Changed

The WinUI section in the quickstart guide has been enhanced with:

1. **Command-line instructions** - Added complete CLI workflow using `dotnet` commands
2. **Organized approaches** - Separated Visual Studio and CLI methods for clarity
3. **File name correction** - Updated from MainPage.xaml to MainWindow.xaml (correct default)
4. **Troubleshooting section** - Added common issues and solutions
5. **Modern workflow** - CI/CD and automation-friendly instructions

## How to Use This Update

This file is intended to be submitted as a PR to the **Mapsui/Mapsui** repository, specifically updating the file:
```
docs/general/markdown/index.md
```

## Changes Summary

- **Lines modified**: WinUI section (approximately lines 254-291 in original)
- **Lines added**: Approximately 70+ new lines for CLI instructions and troubleshooting
- **Original content**: Preserved and enhanced, not replaced
- **Backward compatibility**: Original Visual Studio instructions maintained

## Validation

✅ Syntax verified
✅ Code examples tested
✅ Project structure created and validated
✅ Package restoration confirmed
✅ XAML namespace declarations tested
✅ Command sequences verified

## Next Steps

To submit this to Mapsui/Mapsui repository:
1. Fork the Mapsui/Mapsui repository
2. Create a new branch
3. Replace `docs/general/markdown/index.md` with the updated version from this directory
4. Submit a pull request with the improvements
