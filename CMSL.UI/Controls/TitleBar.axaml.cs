using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace CMSL.UI.Controls;

public partial class TitleBar : UserControl
{
    public TitleBar()
    {
        InitializeComponent();
        
        #if DEBUG
        TitleGrid.ShowGridLines = true;
        #endif
    }
    
    // props
    
    public static readonly StyledProperty<string> IconProperty =
        AvaloniaProperty.Register<TitleBar, string>(nameof(Icon));

    public string Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public static readonly StyledProperty<string> TitleProperty =
        AvaloniaProperty.Register<TitleBar, string>(nameof(Title), "");

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    
    public static readonly StyledProperty<int> TitleFontSizeProperty =
        AvaloniaProperty.Register<TitleBar, int>(nameof(FontSize), 14);
    
    public int TitleFontSize
    {
        get => GetValue(TitleFontSizeProperty);
        set => SetValue(TitleFontSizeProperty, value);
    }
    
    public static readonly StyledProperty<bool> IsMaximizeButtonVisibleProperty =
        AvaloniaProperty.Register<TitleBar, bool>(nameof(IsMaximizeButtonVisible), true);
    
    public bool IsMaximizeButtonVisible
    {
        get => GetValue(IsMaximizeButtonVisibleProperty);
        set => SetValue(IsMaximizeButtonVisibleProperty, value);
    }
    
    // events

    private Window GetHostWindow()
    {
        return (Window) VisualRoot;
    }
    
    private void MinimizeButton_OnClick(object? sender, RoutedEventArgs e)
    {
        GetHostWindow().WindowState = WindowState.Minimized;
    }

    private void MaximizeButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (GetHostWindow().WindowState == WindowState.Normal)
        {
            GetHostWindow().WindowState = WindowState.Maximized;
            MaximizeButtonToolTip.Content = "Restore Down";
        }
        else
        {
            GetHostWindow().WindowState = WindowState.Normal;
            MaximizeButtonToolTip.Content = "Maximize";
        }
    }

    private void CloseButton_OnClick(object? sender, RoutedEventArgs e)
    {
        GetHostWindow().Close();
    }
}
