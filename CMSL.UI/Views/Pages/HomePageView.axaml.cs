using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using CMSL.Core.Logging;
using CMSL.UI.ViewModels.Pages;

namespace CMSL.UI.Views.Pages;

public partial class HomePageView : UserControl
{
    private int _clickTime;
    
    public HomePageView()
    {
        InitializeComponent();
    }

    // Funny game AwA
    private void CountButton_OnClick(object? sender, RoutedEventArgs e)
    {
        var d = Random.Shared.NextDouble();
        
        if (GetViewModel().Count >= 10)
        {
            Logger.Info($"You have clicked for {_clickTime} times!");
            return;
        }
        
        if (d < 0.6)
        {
            GetViewModel().Count++;
        }
        
        if (d > 0.6 && GetViewModel().Count >= 0)
        {
            GetViewModel().Count--;
        }
        
        _clickTime++;
    }
    
    private HomePageViewModel GetViewModel()
    {
        return (HomePageViewModel) DataContext!;
    }
}
