﻿using ReactiveUI;
using Splat;
using System.Reflection;
using System.Windows;

namespace AirportAppRx
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetCallingAssembly());
        }
    }
}
