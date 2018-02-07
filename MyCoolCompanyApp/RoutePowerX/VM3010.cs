using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MyCoolCompanyApp.RoutePowerX
{
    public class VM3010: INotifyPropertyChanged
    {
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
                this.items = value;
                OnPropertyChanged(nameof(Items));
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
                this.selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        #endregion

        public VM3010()
        {
            items = new ObservableCollection<VM3010GridDataItem>()
            {
                new VM3010GridDataItem("ordersml.jpg","236296","PURVIS    TRACEY",1,1,1,true,"2225 BELMONT AVE","Charge Only","10000000000"),
                new VM3010GridDataItem("ordersml.jpg","557899","CANADIAN SPRINGS - VIG",1,1,1,true,"2226 BELMONT AVE","Charge Only","10000000001")
            };

            this.selectedItem = items[0];
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



    public class VM3010GridDataItem : INotifyPropertyChanged
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
                this.imgSrc = value;
                OnPropertyChanged(nameof(ImgSrc));
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
                this.customerNumber = value;
                OnPropertyChanged(nameof(CustomerNumber));
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
                this.customerName = value;
                OnPropertyChanged(nameof(CustomerName));
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
                this.serviceFlag = value;
                OnPropertyChanged(nameof(ServiceFlag));
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
                this.rsqDba = value;
                OnPropertyChanged(nameof(RsqDba));
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
                if (this.cstDba != value)
                {
                    this.cstDba = value;
                    OnPropertyChanged(nameof(CstDba));
                }
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
                this.presold = value;
                OnPropertyChanged(nameof(Presold));
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
                this.address = value;
                OnPropertyChanged(nameof(Address));
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
                this.payType = value;
                OnPropertyChanged(nameof(PayType));
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
                this.phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
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
