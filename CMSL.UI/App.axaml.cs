using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Markup.Xaml;
using CMSL.Core;
using CMSL.Core.Info;
using CMSL.Core.Logging;
using CMSL.UI.ViewModels.Windows;
using CMSL.UI.Views.Windows;

namespace CMSL.UI;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        CMSLCore.Init();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
            
            desktop.Exit += DesktopOnExit;
        }
        
        AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
        TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
        
        Logger.Info($"CMSL Version: { AppInfo.Version }");
        Logger.Info($"OS: {SystemInfo.OS}");
        Logger.Info($"Arch: {SystemInfo.Arch}");

        base.OnFrameworkInitializationCompleted();
    }
    
    // For UI Thread
    private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        Logger.Err("Unhandled exception has caught!");
        Logger.Err($"Exception: {e.ExceptionObject as Exception}");
    }

    // For other threads
    private void OnUnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
    {
        Logger.Err("task execution exception has caught!");
        Logger.Err($"Exception: {e.Exception}");
        e.SetObserved();
    }

    private void DesktopOnExit(object? sender, ControlledApplicationLifetimeExitEventArgs e)
    {
        Logger.Info("Shutting down CMSL");
        Shutdown();
        Environment.Exit(0);
    }

    public static void Shutdown()
    {
        CMSLCore.Shutdown();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}