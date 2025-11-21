# NetEvolve.Extensions.Strings

[![NuGet](https://img.shields.io/nuget/v/NetEvolve.Extensions.Strings.svg)](https://www.nuget.org/packages/NetEvolve.Extensions.Strings/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/NetEvolve.Extensions.Strings.svg)](https://www.nuget.org/packages/NetEvolve.Extensions.Strings/)
[![License](https://img.shields.io/github/license/dailydevops/extensions.strings.svg)](LICENSE)

A modern .NET library providing essential extension methods for `System.String` to simplify common string operations. Part of the [Daily DevOps & .NET - NetEvolve](https://daily-devops.net/) project.

## Features

- 🎯 **Simple & Intuitive API** - Extension methods that feel natural to use
- 🚀 **Multi-Framework Support** - Compatible with .NET Standard 2.0, .NET 8.0, .NET 9.0, and .NET 10.0
- 📦 **Zero Dependencies** - Minimal footprint (only requires `NetEvolve.Arguments`)
- 🔒 **Null-Safe** - Proper argument validation with meaningful exceptions

## Installation

Install the package via NuGet Package Manager:

```bash
dotnet add package NetEvolve.Extensions.Strings
```

Or via the Package Manager Console:

```powershell
Install-Package NetEvolve.Extensions.Strings
```

## Usage

### EnsureEndsWith

Ensures that a string ends with the specified suffix. If the string already ends with the suffix, the original string is returned; otherwise, the suffix is appended.

```csharp
using System;

string path = "C:\\Users\\Documents";
string result = path.EnsureEndsWith("\\"); 
// Result: "C:\\Users\\Documents\\"

string url = "https://example.com/";
string result2 = url.EnsureEndsWith("/");
// Result: "https://example.com/" (unchanged, already ends with "/")

// Case-insensitive comparison
string text = "Hello";
string result3 = text.EnsureEndsWith("WORLD", StringComparison.OrdinalIgnoreCase);
// Result: "HelloWORLD"
```

**Parameters:**
- `value` (string): The string to check
- `suffix` (string): The suffix to ensure
- `comparison` (StringComparison): Optional comparison mode (default: `CurrentCulture`)

**Exceptions:**
- `ArgumentNullException`: Thrown if `value` or `suffix` is null

### EnsureStartsWith

Ensures that a string starts with the specified prefix. If the string already starts with the prefix, the original string is returned; otherwise, the prefix is prepended.

```csharp
using System;

string path = "Documents\\file.txt";
string result = path.EnsureStartsWith("C:\\");
// Result: "C:\\Documents\\file.txt"

string url = "example.com";
string result2 = url.EnsureStartsWith("https://");
// Result: "https://example.com"

// Case-insensitive comparison
string text = "world";
string result3 = text.EnsureStartsWith("HELLO", StringComparison.OrdinalIgnoreCase);
// Result: "HELLOworld"
```

**Parameters:**
- `value` (string): The string to check
- `prefix` (string): The prefix to ensure
- `comparison` (StringComparison): Optional comparison mode (default: `CurrentCulture`)

**Exceptions:**
- `ArgumentNullException`: Thrown if `value` or `prefix` is null

## Supported Frameworks

- .NET Standard 2.0
- .NET 8.0
- .NET 9.0
- .NET 10.0

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request. For major changes, please open an issue first to discuss what you would like to change.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Links

- [GitHub Repository](https://github.com/dailydevops/extensions.strings)
- [NuGet Package](https://www.nuget.org/packages/NetEvolve.Extensions.Strings/)
- [Release Notes](https://github.com/dailydevops/extensions.strings/releases)
- [Daily DevOps & .NET](https://daily-devops.net/)
