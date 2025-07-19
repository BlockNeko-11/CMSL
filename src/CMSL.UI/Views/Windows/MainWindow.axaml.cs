using System.Diagnostics;
using Avalonia.Controls;
using CMSL.UI.ViewModels.Windows;

namespace CMSL.UI.Views.Windows;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        #if DEBUG
        MainGrid.ShowGridLines = true;
        #endif
    }

    private void NavigationBar_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var i = NavigationBar.SelectedIndex;
        var vm = GetViewModel();
        
        var item = vm.NavigationBarItems[i];

        Debug.WriteLine("Current Page: " + item.Title);
        vm.CurrentPage = item.ViewModel;
    }

    private MainWindowViewModel GetViewModel()
    {
        return (MainWindowViewModel) DataContext!;
    }
}
