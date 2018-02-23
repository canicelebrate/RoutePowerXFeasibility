using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyCoolCompanyApp.Behaviors
{
    public class ListViewMoveToNextRowBehavior : Behavior<ListView>
    {
        public ListView AssociatedListView { get; private set; }

        protected override void OnAttachedTo(ListView listView)
        {
            base.OnAttachedTo(listView);
            AssociatedListView = listView;
        }


        protected override void OnDetachingFrom(ListView entry)
        {

            base.OnDetachingFrom(entry);
        }
    }
}
