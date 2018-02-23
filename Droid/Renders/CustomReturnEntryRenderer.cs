using System;
using Android.Views;
using Android.Widget;
using Android.Runtime;
using Android.Content;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using MyCoolCompanyApp.Controls;
using MyCoolCompanyApp.Droid.Renders;
using MyCoolCompanyApp.Droid.Utils;

[assembly: ExportRenderer(typeof(CustomReturnEntry), typeof(CustomReturnEntryRenderer))]
namespace MyCoolCompanyApp.Droid.Renders
{

    /// <summary>

    /// CustomReturnEntry Implementation

    /// </summary>

    [Preserve(AllMembers = true)]

    public sealed class CustomReturnEntryRenderer : EntryRenderer
    {
        #region :: Field ::
        DateTime? _lastEnterKeyPressed = null;
        #endregion
        public CustomReturnEntryRenderer(Context context) : base(context)
        {

        }



        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init()
        {
            var temp = DateTime.Now;
        }



        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            var customEntry = Element as CustomReturnEntry;


            if (Control != null && customEntry != null)
            {

                Control.ImeOptions = KeyboardHelpers.GetKeyboardButtonType(customEntry.ReturnType);

                //Control.FocusChange += (sender, args) =>
                //{
                //    if (args.HasFocus)
                //    {
                //        if (!string.IsNullOrEmpty(Control.Text))
                //        {
                //            Control.SetSelection(Control.Text.Length);
                //        }
                //    }
                //};


                //Control.FocusChange += Control_FocusChange;

                Control.EditorAction += Control_EditorAction;
                //Control.EditorAction += (object sender, TextView.EditorActionEventArgs args) =>
                //{
                //    if (args?.Event?.KeyCode == Keycode.Enter)
                //        return;

                //    var dtNow = DateTime.Now;
                //    bool shouldTriggerEvent = false;
                //    if(_lastEnterKeyPressed == null)
                //    {

                //        shouldTriggerEvent = true;
                //    }
                //    else
                //    {
                //        TimeSpan ts = dtNow - _lastEnterKeyPressed.Value;
                //        if(ts.TotalMilliseconds > 100)
                //        {
                //            shouldTriggerEvent = true;
                //        }
                //    }
                //    _lastEnterKeyPressed = dtNow;

                //    if (shouldTriggerEvent)
                //    {
                //        customEntry.ReturnCommand?.Execute(null);
                //        customEntry.OnRetrunKeyPress();
                //    }

                //};

            }

        }

        private void Control_FocusChange(object sender, FocusChangeEventArgs e)
        {
            if (e.HasFocus)
            {
                Control.EditorAction -= Control_EditorAction;
                Control.EditorAction += Control_EditorAction;
            }
            else
            {
                Control.EditorAction -= Control_EditorAction;
            }

    
        }

        private void Control_EditorAction(object sender, TextView.EditorActionEventArgs args)
                {
            //Control.EditorAction -= Control_EditorAction;
            CustomReturnEntry customEntry = (CustomReturnEntry)Element;
                    if (args?.Event?.KeyCode == Keycode.Enter)
                        return;

                    var dtNow = DateTime.Now;
        bool shouldTriggerEvent = false;
                    if(_lastEnterKeyPressed == null)
                    {

                        shouldTriggerEvent = true;
                    }
                    else
                    {
                        TimeSpan ts = dtNow - _lastEnterKeyPressed.Value;
                        if(ts.TotalMilliseconds > 100)
                        {
                            shouldTriggerEvent = true;
                        }
                    }
                    _lastEnterKeyPressed = dtNow;

                    if (shouldTriggerEvent)
                    {
                        customEntry.ReturnCommand?.Execute(null);
customEntry.OnRetrunKeyPress();
                    }

                }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == CustomReturnEntry.ReturnTypeProperty.PropertyName)
            {
                var customEntry = sender as CustomReturnEntry;

                if (Control != null && customEntry != null)
                    Control.ImeOptions = KeyboardHelpers.GetKeyboardButtonType(customEntry.ReturnType);
            }
            else if(e.PropertyName == CustomReturnEntry.SelectAllOnFocusProperty.PropertyName)
            {
                var customEntry = sender as CustomReturnEntry;

                if (Control != null && customEntry != null)
                    Control.SetSelectAllOnFocus(customEntry.SelectAllOnFocus);
            }
            else if (e.PropertyName == CustomReturnEntry.ErrorMessageProperty.PropertyName)
            {
                var customEntry = sender as CustomReturnEntry;

                if (Control != null && customEntry != null)
                {
                    var icon = this.Context.GetDrawable(Resource.Drawable.entry_error_hint);
                    icon.SetBounds(0, 0, icon.IntrinsicWidth, icon.IntrinsicHeight);
                    
                    Control.SetError(customEntry.ErrorMessage, icon);
                }
            }


        }

    }
}