using System.Collections.ObjectModel;
using CMSL.UI.Models.Navigation;
using CMSL.UI.ViewModels.Pages;
using CMSL.UI.ViewModels.Pages.ServerPanel;
using CommunityToolkit.Mvvm.ComponentModel;
using FluentIcons.Common;

namespace CMSL.UI.ViewModels.Windows;

public partial class ServerPanelWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<NavigationBarItem> _navigationBarItems;
    
    [ObservableProperty]
    private PageViewModelBase _currentPage;

    [ObservableProperty] 
    private bool _running;

    public ServerPanelWindowViewModel()
    {
        NavigationBarItems =
        [
            new NavigationBarItem(
                Icon.Home,
                "Dashboard",
                new DashboardPageViewModel()
            ),
            new NavigationBarItem(
                Icon.WindowApps,
                "Terminal",
                new TerminalPageViewModel()
            )
        ];
        
        CurrentPage = NavigationBarItems[0].ViewModel;
        Running = false;
    }
}
