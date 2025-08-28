using Avalonia.Controls;

namespace CMSL.UI.Views.Pages.ServerPanel;

public partial class TerminalPageView : UserControl
{
    public TerminalPageView()
    {
        InitializeComponent();
        
#if DEBUG
        MainGrid.ShowGridLines = true;
#endif
    }
}
