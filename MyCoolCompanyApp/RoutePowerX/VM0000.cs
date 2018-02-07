using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyCoolCompanyApp.RoutePowerX
{
    public class VM0000
    {
        public VM0000()
        {
            this.ServiceCustomerCmd = new Command(execute: () =>
            {
                
            });

        }

        public ICommand ServiceCustomerCmd
        {
            get;
            private set;
        }
    }
}
