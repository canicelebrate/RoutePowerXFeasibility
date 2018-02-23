using MyCoolCompanyApp.Controls.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyCoolCompanyApp.Controls
{
    /// <summary>

    /// CustomReturnEntry Interface

    /// </summary>

    public class CustomReturnEntry : Entry
    {
        /// <summary>
        /// Return Type Property of the Entry
        /// </summary>
        public static readonly BindableProperty ReturnTypeProperty =
            BindableProperty.Create(BindablePropertyConstants.ReturnTypePropertyName, typeof(ReturnType), typeof(CustomReturnEntry), ReturnType.Default);



        /// <summary>
        /// Command Property that occurs when the user finalizes the text in an entry with the return key
        /// </summary>
        public static readonly BindableProperty ReturnCommandProperty =
            BindableProperty.Create(BindablePropertyConstants.ReturnCommandPropertyName, typeof(ICommand), typeof(CustomReturnEntry));


        /// <summary>
        /// Backing store for the ReturnCommandParameter bindable property
        /// </summary>
        public static readonly BindableProperty ReturnCommandParameterProperty =
            BindableProperty.Create(BindablePropertyConstants.ReturnCommandParameterPropertyName, typeof(object), typeof(CustomReturnEntry));

        /// <summary>
        /// Backing store for the SelectAllOnFocus bindable property
        /// </summary>
        public static readonly BindableProperty SelectAllOnFocusProperty =
            BindableProperty.Create("SelectAllOnFocus", typeof(bool), typeof(CustomReturnEntry),false,BindingMode.TwoWay,propertyChanged:(bindable, oldValue, newValue) =>
            {
                Debugger.Log(1, "Debug", newValue.ToString());
                var entry = (CustomReturnEntry)bindable;
            });

        //public static readonly BindableProperty HasErrorProperty = 
        //    BindableProperty.Create(BindablePropertyConstants.HasErrorPropertyName, typeof(bool), typeof(CustomReturnEntry));


        public static readonly BindableProperty ErrorMessageProperty = 
            BindableProperty.Create(BindablePropertyConstants.ErrorMessagePropertyName, typeof(String), typeof(CustomReturnEntry),null,BindingMode.TwoWay);

        public String ErrorMessage
        {
            get { return (String)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }


        public static readonly BindableProperty FocusOnRowTappedProperty = BindableProperty.Create("FocusOnRowTapped", typeof(bool), typeof(CustomReturnEntry), default(bool));

        public bool FocusOnRowTapped
        {
            get { return (bool)GetValue(FocusOnRowTappedProperty); }
            set { SetValue(FocusOnRowTappedProperty, value); }
        }

        //public bool HasError
        //{
        //    get { return (Type)GetValue(HasErrorProperty); }
        //    set { SetValue(HasErrorProperty, value); }
        //}


        /// <summary>
        /// Type of the Keyboard Return Key
        /// </summary>
        public ReturnType ReturnType
        {
            get => (ReturnType)GetValue(ReturnTypeProperty);
            set => SetValue(ReturnTypeProperty, value);
        }



        /// <summary>
        /// Occurs when the user finalizes the text in an entry with the return key
        /// </summary>
        public ICommand ReturnCommand
        {
            get => (ICommand)GetValue(ReturnCommandProperty);
            set => SetValue(ReturnCommandProperty, value);
        }



        /// <summary>
        /// Gets or sets the ReturnCommand parameter
        /// </summary>
        public object ReturnCommandParameter
        {
            get => GetValue(ReturnCommandParameterProperty);
            set => SetValue(ReturnCommandParameterProperty, value);
        }

        /// <summary>
        /// Gets or sets the SelectAllOnFocus parameter
        /// </summary>
        public bool SelectAllOnFocus
        {
            get
            {
                return (bool)GetValue(SelectAllOnFocusProperty);
            }
            set
            {
                SetValue(SelectAllOnFocusProperty, value);
            }
        }


        public event EventHandler ReturnKeyPressed;
        internal void OnRetrunKeyPress()
        {
            Debugger.Log(1, "Debug", $"Return Key Pressed at {DateTime.Now}");
            this.ReturnKeyPressed?.Invoke(this, EventArgs.Empty);
        }

    }
}
