# Mapsui Quick Start Tests

This repository contains implementations of the Mapsui quick start guides to validate their accuracy and identify any issues.

## Contents

### MAUI Quick Start
- **Location**: `maui-quickstart/MapsuiMauiQuickStart/`
- **Status**: ✅ Successfully implemented and built
- **Framework**: .NET 9.0 (Android target)
- **Findings**: See [MAUI_QUICKSTART_FINDINGS.md](MAUI_QUICKSTART_FINDINGS.md)

## Purpose

This repository serves to:
1. Test and validate Mapsui quick start guides
2. Identify issues or outdated information in the documentation
3. Provide working examples for reference
4. Document findings and recommendations for documentation improvements

## Key Findings

### MAUI Quick Start
- ❌ **Critical**: Documentation references .NET 7, should be .NET 9
- ⚠️ **Missing**: Prerequisites section (MAUI templates and workload installation)
- ✅ **Working**: All code examples work as documented
- ✅ **Clear**: Step-by-step instructions are easy to follow

For detailed findings, see [MAUI_QUICKSTART_FINDINGS.md](MAUI_QUICKSTART_FINDINGS.md)

## Building the Projects

### MAUI Quick Start

Prerequisites:
```bash
# Install MAUI templates
dotnet new install Microsoft.Maui.Templates

# Install/restore MAUI workload
dotnet workload restore
```

Build:
```bash
cd maui-quickstart/MapsuiMauiQuickStart
dotnet build
```

## Related Documentation

- [Mapsui Documentation](https://mapsui.com)
- [Mapsui Quick Start Guide](https://github.com/Mapsui/Mapsui/blob/main/docs/general/markdown/index.md)
