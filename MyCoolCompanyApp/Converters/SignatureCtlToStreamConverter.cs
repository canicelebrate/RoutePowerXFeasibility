using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SignaturePad.Forms;

namespace MyCoolCompanyApp.Converters
{
    public class SignatureCtlToStreamConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SignaturePadView sigView = null;
            if(value is SignaturePadView)
            {
                sigView = value as SignaturePadView;
            }
            else
            {
                sigView = parameter as SignaturePadView;
            }

            if(sigView == null)
            {
                throw new ArgumentOutOfRangeException("value or parameter should act as SignaturePadView",innerException:null);
            }

            return sigView.GetImageStreamAsync(SignatureImageFormat.Png).Result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
