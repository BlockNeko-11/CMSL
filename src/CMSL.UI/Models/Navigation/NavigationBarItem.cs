using Avalonia.Media.Imaging;
using CMSL.UI.ViewModels.Pages;

namespace CMSL.UI.Models.Navigation;

public class NavigationBarItem
{
    public string Icon { get; set; }

    public string Title { get; set; }

    public PageViewModelBase ViewModel { get; set; }

    public NavigationBarItem(string icon, string title, PageViewModelBase viewModel)
    {
        Icon = icon;
        Title = title;
        ViewModel = viewModel;
    }
}
