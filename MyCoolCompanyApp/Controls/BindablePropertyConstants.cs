using MyCoolCompanyApp.Controls.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoolCompanyApp.Controls
{
    static class BindablePropertyConstants
    {
        public const string ReturnTypePropertyName = nameof(ReturnType);

        public const string ReturnCommandPropertyName = nameof(CustomReturnEntry.ReturnCommand);

        public const string ReturnCommandParameterPropertyName = nameof(CustomReturnEntry.ReturnCommandParameter);

        public const string SelectAllOnFocusPropertyName = nameof(CustomReturnEntry.SelectAllOnFocus);

        //public const string HasErrorPropertyName = nameof(CustomReturnEntry.HasError);

        public const string ErrorMessagePropertyName = nameof(CustomReturnEntry.ErrorMessage);
    }
}
