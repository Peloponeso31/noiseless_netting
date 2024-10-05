﻿using System.Windows;
using Front.Core.Services.Navigation;
using Microsoft.Extensions.DependencyInjection;

namespace Front;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{

    public IServiceProvider Services { get; }
    public new static App Current => (App)Application.Current;
    
    public App()
    {
        Services = InitServices();
        InitializeComponent();
    }
    
    private IServiceProvider InitServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<INavigationService, NavigationService>();

        return services.BuildServiceProvider();
    }
}