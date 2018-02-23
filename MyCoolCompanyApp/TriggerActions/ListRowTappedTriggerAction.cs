using MyCoolCompanyApp.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyCoolCompanyApp.TriggerActions
{
    public class ListRowTappedTriggerAction : TriggerAction<ListView>
    {
        #region :: Fields ::
        ListView _listView;
        #endregion

        #region :: Properties ::

        public ListView ListView
        {
            get
            {
                return _listView;
            }
            set
            {
                _listView = value;
            }
        }
        #endregion


        protected override void Invoke(ListView entry)
        {
            SelectedItemChangedEventArgs e;
            Element element = entry;
            do
            {
                element = element.Parent;

            } while (!(element is ViewCell) || element == null);

            if(element != null)
            {
                ViewCell cell = element as ViewCell;
                if(cell != null)
                {

                }
            }

            if(_targetFocusElement != null)
            {
                _targetFocusElement.Focus();
            }

            //Matched the ParentListView, select next row
            if(_parentListView != null)
            {
                IList listData = _parentListView.ItemsSource as IList;



                if (listData != null)
                {
                    var currentSelectedItem = _parentListView.SelectedItem;

                    bool foundNext = false;
                    bool checkNext = false;
                    for(int i=0;i< listData.Count;i++)
                    {
                        if(currentSelectedItem == listData[i])
                        {
                            checkNext = true;
                        }
                        
                        if (checkNext)
                        {
                            if (i < (listData.Count - 1))
                            {
                                _parentListView.SelectedItem = listData[i+1];
                                foundNext = true;
                            }
                            break;
                        }
                    }


                    if (foundNext)
                    {
                        _parentListView.ScrollTo(_parentListView.SelectedItem, ScrollToPosition.MakeVisible, true);
                    }
                }
            }
        }
    }
}
