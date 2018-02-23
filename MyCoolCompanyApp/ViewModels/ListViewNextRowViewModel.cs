using MyCoolCompanyApp.Controls.Enums;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyCoolCompanyApp.ViewModels
{
    public class ListViewNextRowViewModel: BindableBase
    {
        private ObservableCollection<ListViewNextRowItem> _items;
        public ObservableCollection<ListViewNextRowItem> Items
        {
            get
            {
                return _items;
            }
            set
            {
                SetProperty<ObservableCollection<ListViewNextRowItem>>(ref _items, value, nameof(Items));
            }
        }

        private ListViewNextRowItem _selectedItem;
        public ListViewNextRowItem SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                SetProperty<ListViewNextRowItem>(ref _selectedItem, value, nameof(SelectedItem));
            }
        }


        public ListViewNextRowViewModel()
        {
            _items = new ObservableCollection<ListViewNextRowItem>
            {
                new ListViewNextRowItem
                (
                    "1314","1"
                ),
                new ListViewNextRowItem
                (
                    "1315","2"
                ),
                new ListViewNextRowItem
                (
                    "1316","3"
                )
            };

        } 


    }

    public class ListViewNextRowItem
    {
        public ListViewNextRowItem(string value,string value2)
        {
            this._value = value;
            this._value2 = value2;
            this._rt = ReturnType.Next;
            this._saof = true;
        }

        string _value;
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value  = Value;
            }
        }

        string _value2;
        public string Value2
        {
            get
            {
                return _value2;
            }
            set
            {
                _value2= Value;
            }
        }

        bool _needFocus;
        public bool NeedFocus
        {
            get
            {
                return _needFocus;
            }
            set
            {
                _needFocus = value;
            }
        }

        ReturnType _rt;
        public ReturnType ReturnType
        {
            get
            {
                return _rt;
            }
            set
            {
                _rt = value;
            }
        }

        Boolean _saof;
        public Boolean SelectAllOnFocus
        {
            get
            {
                return _saof;
            }
            set
            {
                _saof = value;
            }
        }

        public override string ToString()
        {
            return $"Value:{Value},Value2:{Value2}";
        }


    }
}
