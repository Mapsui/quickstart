# Instructions for Creating the Mapsui/Mapsui PR

## Overview

This document provides step-by-step instructions for creating the second PR to update the official Mapsui documentation in the Mapsui/Mapsui repository.

## Prerequisites

- GitHub account with access to fork repositories
- The file `docs-update/index.md` from this repository

## Step-by-Step Instructions

### 1. Fork the Mapsui/Mapsui Repository

1. Go to https://github.com/Mapsui/Mapsui
2. Click the "Fork" button in the top-right corner
3. Select your GitHub account as the destination

### 2. Clone Your Fork

```bash
git clone https://github.com/YOUR-USERNAME/Mapsui.git
cd Mapsui
```

### 3. Create a Feature Branch

```bash
git checkout -b feature/improve-winui-quickstart-cli
```

### 4. Update the Documentation File

Replace the existing quickstart documentation:

```bash
# Backup the original (optional)
cp docs/general/markdown/index.md docs/general/markdown/index.md.backup

# Copy the updated version from the quickstart repo
# (You'll need to have the updated file available)
# Replace the file at: docs/general/markdown/index.md
```

**Important**: Copy the contents from `docs-update/index.md` in the `Mapsui/quickstart` repository to `docs/general/markdown/index.md` in the `Mapsui/Mapsui` repository.

### 5. Review the Changes

```bash
# See what changed
git diff docs/general/markdown/index.md

# Or use a more readable format
git diff --color-words docs/general/markdown/index.md | less -R
```

Key changes to verify:
- WinUI section has both Visual Studio and CLI instructions
- MainPage.xaml corrected to MainWindow.xaml
- Troubleshooting section added
- All other sections remain unchanged

### 6. Commit the Changes

```bash
git add docs/general/markdown/index.md
git commit -m "Improve WinUI quickstart guide with CLI instructions

- Add command-line workflow using dotnet CLI
- Fix MainPage.xaml to MainWindow.xaml (correct default)
- Add troubleshooting section for common issues
- Maintain backward compatibility with VS instructions
- Enable CI/CD and automation workflows

Testing and validation documented in: Mapsui/quickstart PR #[NUMBER]"
```

### 7. Push to Your Fork

```bash
git push origin feature/improve-winui-quickstart-cli
```

### 8. Create the Pull Request

1. Go to your fork on GitHub: https://github.com/YOUR-USERNAME/Mapsui
2. Click "Pull requests" tab
3. Click "New pull request"
4. Set base repository: `Mapsui/Mapsui` base: `main`
5. Set compare: your fork, branch: `feature/improve-winui-quickstart-cli`
6. Click "Create pull request"

### 9. Fill Out the PR Description

Use this template:

```markdown
## Improve WinUI Quickstart Guide with CLI Instructions

### Summary
This PR enhances the WinUI quickstart guide by adding command-line instructions for modern development workflows while maintaining backward compatibility with the original Visual Studio approach.

### Changes Made
- ✅ Added complete CLI workflow using `dotnet` commands
- ✅ Fixed file name: MainPage.xaml → MainWindow.xaml (correct default in templates)
- ✅ Added troubleshooting section with common issues and solutions
- ✅ Organized into "Visual Studio" and "Command Line" subsections
- ✅ Maintained all original functionality and instructions

### Benefits
- **CI/CD Friendly**: Scriptable commands for automated pipelines
- **Modern Workflow**: Follows current .NET CLI best practices
- **Beginner Friendly**: Original Visual Studio instructions preserved
- **Better Support**: Troubleshooting section reduces common questions

### Testing
- Validated in Mapsui/quickstart repository PR #[NUMBER]
- Complete working WinUI project created
- Package restoration confirmed
- All code snippets syntax-verified
- Project structure validated

### Backward Compatibility
✅ All original Visual Studio instructions maintained
✅ No breaking changes
✅ Only additions and corrections

### Files Changed
- `docs/general/markdown/index.md` - Enhanced WinUI section only

### Lines Changed
- Approximately 70 lines added
- WinUI section updated (lines ~254-291 in original)
- No other sections modified

### Related Work
Testing and validation PR: Mapsui/quickstart#[NUMBER]

### Screenshots (if applicable)
[Add screenshots of the rendered documentation if you can generate them]

---

**Questions?** See the comprehensive testing documentation in the related PR at Mapsui/quickstart.
```

### 10. Address Review Feedback

Once the PR is submitted:
1. Monitor for review comments
2. Address any feedback promptly
3. Push additional commits if needed
4. Engage in discussion as needed

## Quick Reference: What Changed

### In the WinUI Section:

**Before:**
- Only Visual Studio instructions
- Referenced MainPage.xaml (incorrect default)
- No troubleshooting
- No CLI option

**After:**
- Both Visual Studio and CLI instructions
- Corrected to MainWindow.xaml
- Comprehensive troubleshooting section
- Complete `dotnet` CLI workflow
- Better organization and structure

### Lines Affected:
- **Original**: Lines 254-291 (37 lines)
- **Updated**: Lines 254-364 (110 lines)
- **Net Addition**: ~70 lines

### Content Summary:
```
=== "WinUI"
    Using Visual Studio:
        [Original instructions with MainWindow correction]
    
    ---
    
    Using Command Line:
        Step 1: Install templates
        Step 2: Create project
        Step 3: Add Mapsui package
        Step 4-6: Edit files and run
        
        Troubleshooting:
            - Template not found
            - XAML compilation errors
            - Map doesn't appear
```

## Important Notes

1. **Only the WinUI section changes** - no other quickstart sections are modified
2. **Backward compatible** - original instructions are preserved
3. **Tested** - all code validated in working project
4. **Ready to merge** - no dependencies on other PRs

## Verification Checklist

Before submitting the PR, verify:

- [ ] Only `docs/general/markdown/index.md` is modified
- [ ] WinUI section includes both VS and CLI approaches
- [ ] File names corrected (MainWindow not MainPage)
- [ ] Troubleshooting section present
- [ ] All other sections unchanged
- [ ] Commit message is clear and descriptive
- [ ] PR description references testing PR
- [ ] Branch is up-to-date with main

## Support

If you encounter any issues:
1. Review the files in `Mapsui/quickstart` repository
2. Check `TESTING-RESULTS.md` for detailed analysis
3. Refer to `PROJECT-SUMMARY.md` for overview
4. Review the working project in `WinUI.Quickstart/`

---

**Ready to proceed?** Follow the steps above to create your PR to Mapsui/Mapsui!
