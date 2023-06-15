using Session1.Database;
using Session1.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Session1.Convertres
{

    public class DiscountTextDecorationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Product itemsdisc = PageHelper.ConnectDB.Product.Where(x => (x.ID == (int)value)).FirstOrDefault();
            if (itemsdisc.Discount == 0 || itemsdisc.Discount == null)
            {
                return null;
            }

            else
            {

                return "Strikethrough";
            }


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
