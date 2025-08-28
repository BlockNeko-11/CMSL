using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using CMSL.Core.Logging;
using CMSL.UI.ViewModels.Pages.Main;
using CMSL.UI.ViewModels.Windows;
using CMSL.UI.Views.Windows;

namespace CMSL.UI.Views.Pages.Main;

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

    private void CrashButton_OnClick(object? sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void ProgressButton_OnClick(object? sender, RoutedEventArgs e)
    {
        GetViewModel().Progress++;
    }

    private void ServerPanelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        ServerPanelWindow panel = new ServerPanelWindow
        {
            Title = "111",
            DataContext = new ServerPanelWindowViewModel()
        };
        
        panel.Show();
    }
}
