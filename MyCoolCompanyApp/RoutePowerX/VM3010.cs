using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Prism.Mvvm;
using Prism.Commands;
using Prism.Navigation;

namespace MyCoolCompanyApp.RoutePowerX
{
    public class VM3010: BindableBase
    {
        #region infrastructure
        INavigationService _navigationService;

        #endregion


        #region fields 
        ObservableCollection<VM3010GridDataItem> items;
        VM3010GridDataItem selectedItem;
        #endregion

        #region properties
        public ObservableCollection<VM3010GridDataItem> Items
        {
            get
            {
                return this.items;
            }
            set
            {
                SetProperty<ObservableCollection<VM3010GridDataItem>>(ref this.items, value, nameof(Items));
            }
        }

        public VM3010GridDataItem SelectedItem
        {
            get
            {
                return this.selectedItem;
            }
            set
            {
                SetProperty<VM3010GridDataItem>(ref this.selectedItem, value, nameof(SelectedItem));
            }
        }
        #endregion

        #region Commands
        DelegateCommand _selectCustomerCmd;
        public DelegateCommand SelectCustomerCmd
        {
            get
            {
                return _selectCustomerCmd;
            }
            private set
            {
                _selectCustomerCmd = value;
            }
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

        #endregion

        public VM3010(INavigationService navigationService)
        {
            _navigationService = navigationService;

            items = new ObservableCollection<VM3010GridDataItem>()
            {
                new VM3010GridDataItem("ordersml.jpg","236296","PURVIS    TRACEY",1,1,1,true,"2225 BELMONT AVE","Charge Only","10000000000"),
                new VM3010GridDataItem("ordersml.jpg","557899","CANADIAN SPRINGS - VIG",1,1,1,true,"2226 BELMONT AVE","Charge Only","10000000001")
            };

            this.selectedItem = items[0];


            this._selectCustomerCmd = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("Dlg3000");
            });

            this._exitCmd = new DelegateCommand(async () =>
            {
                await navigationService.GoBackAsync();
            });
        }


    }



    public class VM3010GridDataItem : BindableBase
    {
        #region fields
        string imgSrc;
        string customerNumber;
        string customerName;
        int serviceFlag;
        int rsqDba;
        int cstDba;
        bool presold;


        string address;
        string payType;
        string phoneNumber;
        

        //buildTo - 需求数量
        int buildToUnitQty;
        int buildToCaseQty;
        #endregion

        public VM3010GridDataItem(string imgSrc, string customerNumber, string customerName, int serviceFlag, 
            int rsqDba, int cstDba,bool presold,
            string address,string payType,string phoneNumber)
        {
            this.imgSrc = imgSrc;
            this.customerNumber = customerNumber;
            this.customerName = customerName;
            this.serviceFlag = serviceFlag;
            this.rsqDba = rsqDba;
            this.cstDba = cstDba;
            this.presold = presold;
            this.address = address;
            this.payType = payType;
            this.phoneNumber = phoneNumber;
        }

        public string ImgSrc
        {
            get
            {
                return this.imgSrc;
            }
            set
            {
                SetProperty<String>(ref this.imgSrc, value, nameof(ImgSrc));
            }
        }

        public string CustomerNumber
        {
            get
            {
                return this.customerNumber;
            }
            set
            {
                SetProperty<String>(ref this.customerNumber, value, nameof(CustomerNumber));
            }
        }

        public string CustomerName
        {
            get
            {
                return this.customerName;
            }
            set
            {
                SetProperty<String>(ref this.customerName, value, nameof(CustomerName));
            }
        }

        public int ServiceFlag
        {
            get
            {
                return this.serviceFlag;
            }
            set
            {
                SetProperty<int>(ref this.serviceFlag, value, nameof(ServiceFlag));
            }
        }

        public int RsqDba
        {
            get
            {
                return this.rsqDba;
            }
            set
            {
                SetProperty<int>(ref this.rsqDba, value, nameof(RsqDba));
            }
        }

        public int CstDba
        {
            get
            {
                return this.cstDba;
            }
            set
            {
                SetProperty<int>(ref this.cstDba, value, nameof(CstDba));
            }
        }

        public bool Presold
        {
            get
            {
                return this.presold;
            }
            set
            {
                SetProperty<bool>(ref this.presold, value, nameof(Presold));
            }
        }


        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                SetProperty<String>(ref this.address, value, nameof(Address));
            }
        }


        public string PayType
        {
            get
            {
                return this.payType;
            }
            set
            {
                SetProperty<String>(ref this.payType, value, nameof(PayType));
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                SetProperty<String>(ref this.phoneNumber, value, nameof(PhoneNumber));
            }
        }

    }
}
