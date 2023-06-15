using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Session1.Convertres
{

    public class DiscountBackgroundConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value != null)
            {
                double count = (double)value;
                if (count >= 0)
                {
                    if (count != 0)
                    {
                        return "#7fff00";
                    }
                    else
                    {
                        return null;
                    }
                }

                else
                {
                    return null;
                }
            }

            else { return null; }
        }
        

    
       
         
        

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
