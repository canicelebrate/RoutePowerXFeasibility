using Prism.Ioc;
using Prism.Modularity;
using MyCoolCompanyApp.Views;
using MyCoolCompanyApp.ViewModels;

namespace MyCoolCompanyApp
{
    public class MyCoolCompanyAppModule : IModule
    {
        public void Initialize() { /* deprecated */ }

        public void OnInitialized()
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
        }
    }
}
