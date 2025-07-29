using System.Collections.ObjectModel;
using CMSL.UI.Models.Navigation;
using CMSL.UI.ViewModels.Pages;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CMSL.UI.ViewModels.Windows;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<NavigationBarItem> _navigationBarItems;
    
    [ObservableProperty]
    private PageViewModelBase _currentPage;
    
    public MainWindowViewModel()
    { 
        NavigationBarItems = new ObservableCollection<NavigationBarItem> {
            new NavigationBarItem(
                "home.png",
                "Home",
                new HomePageViewModel()
            ),

            new NavigationBarItem(
                "servers.png",
                "Servers",
                new ServersPageViewModel()
            ),

            new NavigationBarItem(
                "settings.gif",
                "Settings",
                new SettingsPageViewModel()
            ),

            new NavigationBarItem(
                "about.gif",
                "About",
                new AboutPageViewModel()
            )
        };

        CurrentPage = NavigationBarItems[0].ViewModel;
    }
}
