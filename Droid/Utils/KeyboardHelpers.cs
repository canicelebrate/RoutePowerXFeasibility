using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using MyCoolCompanyApp.Controls.Enums;

namespace MyCoolCompanyApp.Droid.Utils
{
    static class KeyboardHelpers
    {
        internal static ImeAction GetKeyboardButtonType(ReturnType returnType)

        {

            switch (returnType)

            {

                case ReturnType.Go:

                    return ImeAction.Go;

                case ReturnType.Next:

                    return ImeAction.Next;

                case ReturnType.Send:

                    return ImeAction.Send;

                case ReturnType.Search:

                    return ImeAction.Search;

                case ReturnType.Done:

                    return ImeAction.Done;

                case ReturnType.Default:

                    return ImeAction.Done;

                default:

                    throw new System.Exception("Return Type Not Supported");

            }

        }
    }
}