using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoolCompanyApp.RoutePowerX
{
    public class VM3000: BindableBase
    {

        public VM3000(INavigationService navigationService)
        {
            this.ViewInvoiceCmd = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync("Dlg3300");
            });

        }


        DelegateCommand _viewInvoiceCmd;
        public DelegateCommand ViewInvoiceCmd
        {
            get
            {
                return _viewInvoiceCmd;
            }
            private set
            {
                _viewInvoiceCmd = value;
            }
        }

    }
}
