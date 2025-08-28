using System.Collections.ObjectModel;
using CMSL.UI.Models.Navigation;
using CMSL.UI.ViewModels.Pages;
using CMSL.UI.ViewModels.Pages.Main;
using CommunityToolkit.Mvvm.ComponentModel;
using FluentIcons.Common;

namespace CMSL.UI.ViewModels.Windows;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<NavigationBarItem> _navigationBarItems;
    
    [ObservableProperty]
    private PageViewModelBase _currentPage;
    
    public MainWindowViewModel()
    { 
        NavigationBarItems = 
        [
            new NavigationBarItem(
                Icon.Home,
                "Home",
                new HomePageViewModel()
            ),
            new NavigationBarItem(
                Icon.ServerMultiple,
                "Servers",
                new ServersPageViewModel()
            ),
            new NavigationBarItem(
                Icon.ArrowDownload,
                "Downloads",
                new DownloadsPageViewModel()
            ),
            new NavigationBarItem(
                Icon.Settings,
                "Settings",
                new SettingsPageViewModel()
            ),
            new NavigationBarItem(
                Icon.Info,
                "About",
                new AboutPageViewModel()
            )
        ];

        CurrentPage = NavigationBarItems[0].ViewModel;
    }
}
