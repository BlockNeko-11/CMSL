using Avalonia.Media.Imaging;
using CMSL.UI.ViewModels.Pages;

namespace CMSL.UI.Models.Navigation;

public class NavigationBarItem
{
    public Bitmap? ImageSource { get; set; }

    public string Title { get; set; }

    public PageViewModelBase ViewModel { get; set; }

    public NavigationBarItem(Bitmap? imageSource, string title, PageViewModelBase viewModel)
    {
        ImageSource = imageSource;
        Title = title;
        ViewModel = viewModel;
    }
}
