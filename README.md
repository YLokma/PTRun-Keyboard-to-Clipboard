# PowerToys Run: Keyboard-to-Clipboard Plugin

Sometimes you have to jot down an idea or write down something quickly and have it saved on your clipboard, you can use this plugin just for that

## Requirements

- PowerToys (tested with v0.78.0)

## Installation

Install:
1. Download the [latest release](...)
2. Close PowerToys
3. Extract the `Keyboard-to-Clipboard` folder inside it to `%LocalAppData%\Microsoft\PowerToys\PowerToys Run\Plugins`
4. Start PowerToys

### Usage

1. Open PowerToys Run (default: `<Alt>` + `<Space>`)
2. Type the direct activation command (default: `c+`) and a space
3. Continue typing whatever you want to karenify
4. Select one of the entries, then press `<Enter>` to copy that into clipboard

## Building

1. Clone this repository
2. The build process takes the reference libraries from `%ProgramFiles%/PowerToys/`. If the install location differs or you want to build against another version, copy the following files to the `Keyboard-to-Clipboard/lib/` directory:
	- `PowerToys.Common.UI.dll`
	- `PowerToys.ManagedCommon.dll`
	- `Wox.Plugin.dll`
3. Build the project with `dotnet publish -c:Release`, or equivalent
