using CMSL.Core.Info;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CMSL.UI.ViewModels.Pages.Main;

public partial class AboutPageViewModel : PageViewModelBase
{
    [ObservableProperty] 
    private string _version;

    public AboutPageViewModel()
    {
        Version = "Current version: " + AppInfo.Version;
    }
}
