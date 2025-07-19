using System.Collections.ObjectModel;
using CMSL.UI.Models.Navigation;
using CMSL.UI.Utils;
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
                ImageUtils.LoadFromResource("avares://CMSL.UI/Assets/Images/home.png"),
                "Home",
                new HomePageViewModel()
            ),

            new NavigationBarItem(
                ImageUtils.LoadFromResource("avares://CMSL.UI/Assets/Images/servers.png"),
                "Servers",
                new ServersPageViewModel()
            ),

            new NavigationBarItem(
                ImageUtils.LoadFromResource("avares://CMSL.UI/Assets/Images/settings.gif"),
                "Settings",
                new SettingsPageViewModel()
            ),

            new NavigationBarItem(
                ImageUtils.LoadFromResource("avares://CMSL.UI/Assets/Images/about.gif"),
                "About",
                new AboutPageViewModel()
            )
        };

        CurrentPage = NavigationBarItems[0].ViewModel;
    }
}