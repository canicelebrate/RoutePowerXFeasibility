using Prism.Autofac;
using System;

using Xamarin.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism;
using Prism.Ioc;
using XLabs.Forms.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyCoolCompanyApp
{
	public partial class App : PrismApplication
    {
        /* 
 * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
 * This imposes a limitation in which the App class must have a default constructor. 
 * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
 */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            //await NavigationService.NavigateAsync("NavigationPage/Dlg0000");
            //await NavigationService.NavigateAsync("NavigationPage/ListViewNextRow");
            await NavigationService.NavigateAsync("NavigationPage/Dlg9340");

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<RoutePowerX.Dlg0000,RoutePowerX.VM0000>("Dlg0000");
            containerRegistry.RegisterForNavigation<RoutePowerX.Dlg3000, RoutePowerX.VM3000>("Dlg3000");
            containerRegistry.RegisterForNavigation<RoutePowerX.Dlg3010, RoutePowerX.VM3010>("Dlg3010");
            containerRegistry.RegisterForNavigation<RoutePowerX.Dlg3300, RoutePowerX.VM3300>("Dlg3300");
            containerRegistry.RegisterForNavigation<RoutePowerX.Dlg9340, RoutePowerX.VM9340>("Dlg9340");
            

            containerRegistry.RegisterForNavigation<ListViewNextRow, ViewModels.ListViewNextRowViewModel>("ListViewNextRow");
        }
    }
}

