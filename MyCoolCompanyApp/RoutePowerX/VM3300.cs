using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Prism.Commands;
using Prism.Navigation;

namespace MyCoolCompanyApp.RoutePowerX
{
    public class VM3300 : INotifyPropertyChanged
    {
        #region fields
        ObservableCollection<string> invTypes;
        string selectedInvType;
        ObservableCollection<VM3300GridDataItem> items;
        VM3300GridDataItem selectedItem;
        #endregion

        public VM3300(INavigationService navigationService)
        {
            selectedInvType = "Sales";

            invTypes = new ObservableCollection<string>
            {
                "Sales",
                "Rtns",
                "Dmgd",
                "Exch",
                "Other"
            };

            items = new ObservableCollection<VM3300GridDataItem>
            {
                new VM3300GridDataItem
                (
                    "1314","Koala Cola 4/12-6",5,10,0,10
                ),
                new VM3300GridDataItem
                (
                    "1315","Dt Cola 4/12-6",5,10,1,10
                ),
                new VM3300GridDataItem
                (
                    "1316","Lemon Lime 4/12-6",5,10,2,10
                ),
                new VM3300GridDataItem
                (
                    "1317","DT Lemon Lime 4/12-6",5,10,3,10
                ),
                new VM3300GridDataItem
                (
                    "1318","Koala Cola 2/12-6",5,10,4,10
                ),
                new VM3300GridDataItem
                (
                    "1319","DT Koala Cola 2/12-6",5,10,5,10
                ),
                new VM3300GridDataItem
                (
                    "1320","Lemon Lime 2/12-6",5,10,6,10
                ),
                new VM3300GridDataItem
                (
                    "1321","DT Lemon Lime 2/12-6",5,10,7,10
                ),
            };

            this.selectedItem = this.items[0];


            this.ExitCmd = new DelegateCommand(async () =>
            {
                await navigationService.GoBackAsync();
            });
        }


        DelegateCommand _exitCmd;
        public DelegateCommand ExitCmd
        {
            get
            {
                return _exitCmd;
            }
            private set
            {
                _exitCmd = value;
            }
        }

        public ObservableCollection<string> InvTypes
        {
            get
            {
                return this.invTypes;
            }
            set
            {
                this.invTypes = value;
                OnPropertyChanged(nameof(InvTypes));
            }
        }
        public string SelectedInvType
        {
            get
            {
                return this.selectedInvType;
            }
            set
            {
                this.selectedInvType = value;
                OnPropertyChanged(nameof(SelectedInvType));
            }
        }

        public ObservableCollection<VM3300GridDataItem> Items
        {
            get
            {
                return this.items;
            }
            set
            {
                this.items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public VM3300GridDataItem SelectedItem
        {
            get
            {
                return this.selectedItem;
            }
            set
            {
                this.selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }


        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        #endregion
    }

    public class VM3300GridDataItem : INotifyPropertyChanged
    {
        #region fields
        string itemNumber;
        string name;
        int unitQty;
        int caseQty;

        //buildTo - 需求数量
        int buildToUnitQty;
        int buildToCaseQty;
        #endregion

        public VM3300GridDataItem(string itemNumber,string name, int unitQty, int caseQty,int buildToUnitQty,int buildToCaseQty)
        {
            this.itemNumber = itemNumber;
            this.name = name;
            this.unitQty = unitQty;
            this.caseQty = caseQty;
            this.buildToUnitQty = buildToUnitQty;
            this.buildToCaseQty = buildToCaseQty;
        }

        public string ItemNumber
        {
            get
            {
                return this.itemNumber;
            }
            set
            {
                this.itemNumber = value;
                OnPropertyChanged(nameof(ItemNumber));
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int UnitQty
        {
            get
            {
                return this.unitQty;
            }
            set
            {
                this.unitQty = value;
                OnPropertyChanged(nameof(UnitQty));
            }
        }

        public int CaseQty
        {
            get
            {
                return this.caseQty;
            }
            set
            {
                this.caseQty = value;
                OnPropertyChanged(nameof(CaseQty));
            }
        }

        public int BuildToUnitQty
        {
            get
            {
                return this.buildToUnitQty;
            }
            set
            {
                if (this.buildToUnitQty != value) { 
                    this.buildToUnitQty = value;
                    OnPropertyChanged(nameof(BuildToUnitQty));
                }
            }
        }

        public int BuildToCaseQty
        {
            get
            {
                return this.buildToCaseQty;
            }
            set
            {
                this.buildToCaseQty = value;
                OnPropertyChanged(nameof(BuildToCaseQty));
            }
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        #endregion
    }
}
