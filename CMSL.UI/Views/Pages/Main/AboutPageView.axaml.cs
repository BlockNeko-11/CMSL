using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Interactivity;
using CMSL.Core.Info;

namespace CMSL.UI.Views.Pages.Main;

public partial class AboutPageView : UserControl
{
    public AboutPageView()
    {
        InitializeComponent();
    }

    private void SourceCodeButton_OnClick(object? sender, RoutedEventArgs e)
    {
        switch (SystemInfo.OS)
        {
            case OSType.Windows:
                Process.Start("explorer", "\"https://github.com/BlockNeko-11/CMSL\"");
                break;
            case OSType.Linux:
                Process.Start("xdg-open", "\"https://github.com/BlockNeko-11/CMSL\"");
                break;
            case OSType.MacOS:
                Process.Start("open", "\"https://github.com/BlockNeko-11/CMSL\"");
                break;
        }
    }
}
