# Instructions for Second PR to Mapsui/Mapsui

## Overview
This file contains instructions for creating the second PR to update the Blazor quickstart in the main Mapsui documentation repository.

## Repository
The second PR should be created in: **https://github.com/Mapsui/Mapsui**

## File to Update
Path: `docs/general/markdown/index.md`

## What to Change
Replace the existing Blazor section (starting with `=== "Blazor"`) with the improved version from `IMPROVED_BLAZOR_QUICKSTART.md` in this repository.

### Current Section Location
The Blazor section is located after the Uno Platform section and before the WPF section in the tabbed quickstart guides.

### Changes Summary
The new section includes:
1. Updated to .NET 8.0
2. CLI-based commands (dotnet new, dotnet add, dotnet run)
3. Correct file name (Home.razor for .NET 8)
4. Simplified HTML structure
5. Clear wasm-tools workload setup instructions
6. Working solution for native library linking
7. Fixed step numbering (1-6 sequential)
8. Updated troubleshooting section

## Testing Evidence
This solution has been tested and verified working:
- Application builds without errors
- Map renders successfully
- Screenshot: https://github.com/user-attachments/assets/d7304979-8b6a-40c6-9bd0-132d9b7625a9

## PR Title Suggestion
"Improve Blazor quickstart guide with CLI commands and fixed native library setup"

## PR Description Suggestion
```markdown
## Overview
This PR improves the Blazor quickstart guide to make it more reliable and consistent with other platform quickstarts.

## Issues Fixed
- ✅ Updated file name from Index.razor to Home.razor (correct for .NET 8)
- ✅ Fixed step numbering (was 1,2,3,6 → now 1,2,3,4,5,6)
- ✅ Replaced IDE-specific commands with CLI commands
- ✅ Updated from .NET 7.0 to .NET 8.0
- ✅ Simplified HTML structure (removed unnecessary Bootstrap containers)
- ✅ Fixed native library loading with clear wasm-tools setup
- ✅ Updated troubleshooting section

## Testing
Created and tested a working Blazor application following these new instructions.

![Working Blazor Map](https://github.com/user-attachments/assets/d7304979-8b6a-40c6-9bd0-132d9b7625a9)

## Changes
- More consistent with other platform quickstarts (especially Avalonia)
- Uses dotnet CLI throughout for cross-platform compatibility
- Includes clear, tested solution for native library requirements
- Simplified code while maintaining all functionality
```

## Reference PR
The testing and development work for these improvements is in: https://github.com/Mapsui/quickstart/pull/[PR_NUMBER]
