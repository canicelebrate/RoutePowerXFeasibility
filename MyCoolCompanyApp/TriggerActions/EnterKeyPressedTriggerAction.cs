using MyCoolCompanyApp.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyCoolCompanyApp.TriggerActions
{
    public class EnterKeyPressedTriggerAction: TriggerAction<CustomReturnEntry>
    {
        #region :: Fields ::
        VisualElement _targetFocusElement;
        ListView _parentListView;
        #endregion

        #region :: Properties ::
        public VisualElement TargetFocusElement
        {
            get
            {
                return _targetFocusElement;
            }
            set
            {
                _targetFocusElement = value;
            }
        }

        public ListView ParentListView
        {
            get
            {
                return _parentListView;
            }
            set
            {
                _parentListView = value;
            }
        }
        #endregion


        protected override void Invoke(CustomReturnEntry entry)
        {
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
