using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCoolCompanyApp.RoutePowerX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dlg3300 : ContentPage
    {

        public Dlg3300()
        {
            InitializeComponent();

            this.BindingContext = new RoutePowerX.VM3300();
        }
    }
}
