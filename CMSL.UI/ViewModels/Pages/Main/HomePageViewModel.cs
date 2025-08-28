using CommunityToolkit.Mvvm.ComponentModel;

namespace CMSL.UI.ViewModels.Pages.Main;

public partial class HomePageViewModel : PageViewModelBase
{
    [ObservableProperty] 
    private int _count;

    [ObservableProperty] 
    private int _progress;

    public HomePageViewModel()
    {
        Count = 0;
        Progress = 0;
    }
}
