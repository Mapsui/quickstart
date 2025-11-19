# How to Apply MAUI Documentation Improvements to Mapsui Repository

This document explains how to apply the MAUI quick start documentation improvements to the Mapsui/Mapsui repository.

## Summary of Changes

The patch file `0001-Improve-MAUI-quick-start-documentation.patch` contains improvements to the MAUI quick start guide in the Mapsui documentation based on validation testing:

### Changes Made:
1. ✅ **Updated .NET version from 7.0 to 9.0** (critical - .NET 7 is out of support)
2. ✅ **Added Prerequisites section** with MAUI workload installation instructions
3. ✅ **Added command-line alternatives** for all Visual Studio-specific commands
4. ✅ **Added CLI project creation option** using `dotnet new maui`
5. ✅ **Enhanced Step 5 description** with expected behavior (OpenStreetMap tiles, pan/zoom)
6. ✅ **Added platform requirements note** about macOS/Windows build constraints

## Option 1: Apply the Patch Manually (Recommended)

### Steps:

1. **Clone or navigate to the Mapsui repository:**
   ```bash
   git clone https://github.com/Mapsui/Mapsui.git
   cd Mapsui
   ```

2. **Create a new branch:**
   ```bash
   git checkout -b improve-maui-quickstart-docs
   ```

3. **Apply the patch:**
   ```bash
   git apply /path/to/0001-Improve-MAUI-quick-start-documentation.patch
   ```
   
   Or if the patch file is in the current directory:
   ```bash
   git apply 0001-Improve-MAUI-quick-start-documentation.patch
   ```

4. **Review the changes:**
   ```bash
   git diff docs/general/markdown/index.md
   ```

5. **Commit the changes:**
   ```bash
   git add docs/general/markdown/index.md
   git commit -m "Improve MAUI quick start documentation

- Update .NET version from 7.0 to 9.0 (7.0 is out of support)
- Add Prerequisites section with MAUI workload installation
- Add command-line alternatives for Visual Studio commands
- Provide both Visual Studio and CLI project creation options
- Add command-line package installation option
- Enhance Step 5 description with expected behavior
- Add note about platform-specific build requirements

Based on validation testing in Mapsui/quickstart repository."
   ```

6. **Push the branch:**
   ```bash
   git push origin improve-maui-quickstart-docs
   ```

7. **Create a Pull Request:**
   - Go to https://github.com/Mapsui/Mapsui/pulls
   - Click "New pull request"
   - Select your branch `improve-maui-quickstart-docs`
   - Add title: "Improve MAUI quick start documentation"
   - Add description (see below)

## Option 2: Manual Edit

If you prefer to make the changes manually, edit `docs/general/markdown/index.md` in the Mapsui repository and apply the changes shown in the patch file.

### File to Edit:
- `docs/general/markdown/index.md` (lines 22-64, the MAUI section)

### Key Changes:
- Line 24: Change `.NET 7.0` to `.NET 9.0`
- Add Prerequisites section before Step 1
- Add CLI alternatives for project creation (Step 1)
- Add CLI alternative for package installation (Step 2)
- Enhance Step 5 with detailed expected behavior
- Add platform requirements note after Step 5

## Suggested PR Description

```markdown
## Summary
Improves the MAUI quick start documentation based on validation testing performed in the Mapsui/quickstart repository.

## Changes Made

### Critical Fix
- **Updated .NET version from 7.0 to 9.0** - .NET 7 is out of support and causes build errors/warnings

### Improvements
- **Added Prerequisites section** with MAUI workload installation instructions
- **Added command-line alternatives** for Visual Studio commands (benefits CLI users)
- **Added CLI project creation option** using `dotnet new maui`
- **Added CLI package installation** using `dotnet add package`
- **Enhanced Step 5 description** with expected behavior details
- **Added platform requirements note** about macOS/Windows build constraints

## Validation
All changes have been validated by:
1. Creating a working MAUI application following the updated guide
2. Successfully building the application with .NET 9.0
3. Verifying all code examples work as documented

See validation results: https://github.com/Mapsui/quickstart

## Impact
- Makes the guide accessible to both Visual Studio and CLI users
- Prevents issues with out-of-support .NET versions
- Clarifies prerequisites to reduce setup confusion
- Improves user experience with clearer expected outcomes
```

## Testing the Documentation

After applying the patch, you can verify the documentation renders correctly by:

1. Building the documentation site locally (if available)
2. Reviewing the markdown in a markdown viewer
3. Following the updated steps to create a new MAUI application

## Patch File Location

The patch file is located in this repository:
- `0001-Improve-MAUI-quick-start-documentation.patch`

## Questions or Issues?

If you encounter any issues applying the patch or have questions about the changes, please refer to:
- Validation findings: `MAUI_QUICKSTART_FINDINGS.md` in this repository
- Working implementation: `maui-quickstart/MapsuiMauiQuickStart/` in this repository
