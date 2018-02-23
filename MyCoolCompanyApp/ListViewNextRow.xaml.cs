using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCoolCompanyApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewNextRow : ContentPage
	{
        public ListViewNextRow()
        {
            InitializeComponent();
            //this.BindingContext = new ViewModels.ListViewNextRowViewModel(new ObservableCollection<ViewModels.ListViewNextRowItem> {
            //        new ViewModels.ListViewNextRowItem("123"),
            //        new ViewModels.ListViewNextRowItem("124"),
            //        new ViewModels.ListViewNextRowItem("125")
            //    });

            
		}
    }
}