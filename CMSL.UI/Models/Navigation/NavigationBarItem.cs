using CMSL.UI.ViewModels.Pages;
using FluentIcons.Common;

namespace CMSL.UI.Models.Navigation;

public class NavigationBarItem
{
    public Icon Icon { get; set; }

    public string Title { get; set; }

    public PageViewModelBase ViewModel { get; set; }

    public NavigationBarItem(Icon icon, string title, PageViewModelBase viewModel)
    {
        Icon = icon;
        Title = title;
        ViewModel = viewModel;
    }
}
