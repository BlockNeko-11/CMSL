using System.Diagnostics;
using System.Runtime.InteropServices;
using Avalonia.Controls;
using Avalonia.Platform;
using CMSL.UI.ViewModels.Windows;

namespace CMSL.UI.Views.Windows;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
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

    private MainWindowViewModel GetViewModel()
    {
        return (MainWindowViewModel) DataContext!;
    }
}
