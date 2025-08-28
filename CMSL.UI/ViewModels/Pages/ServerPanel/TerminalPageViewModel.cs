using CommunityToolkit.Mvvm.ComponentModel;

namespace CMSL.UI.ViewModels.Pages.ServerPanel;

public partial class TerminalPageViewModel : PageViewModelBase
{
    [ObservableProperty] 
    public string _log;

    public TerminalPageViewModel()
    {
        Log = "";
    }
}
