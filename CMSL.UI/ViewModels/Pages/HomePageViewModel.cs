using CommunityToolkit.Mvvm.ComponentModel;

namespace CMSL.UI.ViewModels.Pages;

public partial class HomePageViewModel : PageViewModelBase
{
    [ObservableProperty] 
    private int _count;

    public HomePageViewModel()
    {
        Count = 0;
    }
}
