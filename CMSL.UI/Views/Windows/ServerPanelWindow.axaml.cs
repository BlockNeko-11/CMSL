using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Platform;
using CMSL.Core.Info;
using CMSL.UI.ViewModels.Windows;

namespace CMSL.UI.Views.Windows;


// Title -> Server Name
public partial class ServerPanelWindow : Window
{
    public ServerPanelWindow()
    {
        InitializeComponent();

        if (SystemInfo.IsWindows11)
        {
            Background = new SolidColorBrush(Colors.Transparent);
            
            (VisualRoot as Window)!.TransparencyLevelHint = new List<WindowTransparencyLevel>
            {
                WindowTransparencyLevel.Mica
            };
        }

        if (SystemInfo.OS == OSType.Linux)
        {
            UseNativeTitleBar();
        }
        
#if DEBUG
        MainGrid.ShowGridLines = true;
        NavigationGrid.ShowGridLines = true;
#endif
    }

    private void UseNativeTitleBar()
    {
        ExtendClientAreaChromeHints = ExtendClientAreaChromeHints.SystemChrome;
        ExtendClientAreaToDecorationsHint = false;
        ExtendClientAreaTitleBarHeightHint = -1;

        CustomTitleBar.IsVisible = false;
    }

    private void NavigationBar_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var i = NavigationBar.SelectedIndex;
        var vm = GetViewModel();
        vm.CurrentPage = vm.NavigationBarItems[i]
            .ViewModel;
    }

    private ServerPanelWindowViewModel GetViewModel()
    {
        return (ServerPanelWindowViewModel) DataContext!;
    }
}
