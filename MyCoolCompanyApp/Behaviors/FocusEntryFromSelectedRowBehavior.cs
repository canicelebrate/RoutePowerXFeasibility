using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyCoolCompanyApp.Behaviors
{
    public class FocusEntryFromSelectedRowBehavior : Behavior<Entry>
    {
        public Entry AssociatedEntry { get; private set; }

        protected override void OnAttachedTo(Entry entry)
        {
            base.OnAttachedTo(entry);
            AssociatedEntry = entry;
            ((ListView)BindingContext).ItemSelected += MyView_ItemSelected;
            ((ListView)BindingContext).Focused += MyListView_Focused;
            entry.Focused += Entry_Focused;
            entry.Unfocused += Entry_Focused;

        }

        private void MyListView_Focused(object sender, FocusEventArgs e)
        {
            Debugger.Log(1, "Debug", $"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff")} ListView is focused.");
        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            Entry entry = e.VisualElement as Entry;
            string info = e.IsFocused ? "focused" : "unfocused";
            Debugger.Log(1, "Debug", $"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff")} Entry:{entry.Text} is {info}.");

            /**/
            if (e.IsFocused)
            {
                ListView ls = (ListView)BindingContext;
                if (ls.SelectedItem != AssociatedEntry.BindingContext)
                {
                    Task.Run(async ()=>{
                        await Task.Delay(100);
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            Debugger.Log(1, "Debug", $"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff")} ListView.SelectedItem will be set to:{AssociatedEntry.BindingContext.ToString()}.");
                            //ls.SelectedItem = AssociatedEntry.BindingContext;
                        });
                    });
                    
                }
            }
            //*/
        }

        private void MyView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (AssociatedEntry.BindingContext == e.SelectedItem)
            {
                if (!AssociatedEntry.IsFocused)
                {
                    Debugger.Log(1, "Debug", $"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff")} Entry:{AssociatedEntry.Text} will get focus in MyView_ItemSelected.");
                    AssociatedEntry.Focus();
                }
            }
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            ((ListView)BindingContext).ItemSelected -= MyView_ItemSelected;
            ((ListView)BindingContext).Focused -= MyListView_Focused;
            entry.Focused -= Entry_Focused;
            entry.Unfocused -= Entry_Focused;
            base.OnDetachingFrom(entry);
        }
    }
}
