using ManagedCommon;
//using System.Windows.Forms;
using Wox.Plugin;

namespace Community.Powertoys.Run.Plugin.Keyboard_to_Clipboard;

public class Plugin : IPlugin
{
    public string Name => "Keyboard to Clipboard";
    public string Description => "Insert keyboard input and copy it to the clipboard";
    public static string PluginID => "255E141EAF5D45569752CB12D3C674EC";

    private PluginInitContext? _context;
    private string? _iconPath;

    public void Init(PluginInitContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        _context = context;
        _context.API.ThemeChanged += (_, theme) => UpdateIconPath(theme);
        UpdateIconPath(_context.API.GetCurrentTheme());
    }

    public List<Result> Query(Query query)
    {
        ArgumentNullException.ThrowIfNull(query);
        if (string.IsNullOrEmpty(query.Search))
            return new();

        var options = new Options[] {
            new(),
        };
        return options
            .Select(options => {
                var result = query.Search;
                return new Result()
                {
                    QueryTextDisplay = query.Search,
                    IcoPath = _iconPath,
                    Title = result,
                    SubTitle = Name,
                    Action = _ => {
                        Clipboard.SetText(result);
                        return true;
                    },
                };
            })
            .ToList();
    }

    private void UpdateIconPath(Theme theme)
    {
        _iconPath = theme is Theme.Light or Theme.HighContrastWhite
            ? "res/ClipboardManager.dark.png"
            : "res/ClipboardManager.light.png";
    }
}

public record struct Options();