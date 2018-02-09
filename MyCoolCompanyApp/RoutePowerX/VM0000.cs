using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyCoolCompanyApp.RoutePowerX
{
    public class VM0000: BindableBase, INavigationAware
    {
        public VM0000(INavigationService navigationService)
        {
            this.ServiceCustomerCmd = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync("Dlg3010");
            });

        }

        public VM0000()
        {

        }

        DelegateCommand _serviceCustomerCmd;
        public DelegateCommand ServiceCustomerCmd
        {
            get
            {
                return _serviceCustomerCmd;
            }
            private set
            {
                _serviceCustomerCmd = value;
            }
        }


        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }



        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}
