using demExVar1.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace demExVar1.Pages
{
    public class orderViewModel
    {

        public ObservableCollection<orderProduct> ordPrd { get; } = new ObservableCollection<orderProduct>();

        public orderViewModel()
        {

            var keysIDArray = PageHelper.Order.Keys.ToArray();

            var valuesAmountArray = PageHelper.Order.Values.ToArray();

            var table = PageHelper.connectDb.Product.Where(x => keysIDArray.Contains(x.ProductID)).ToList();

            for (int i = 0; i < table.Count; i++)
            {   
                
                ordPrd.Add(new orderProduct() { Id = table[i].ProductID, Price= table[i].ProductCost,
                                                Discount= (double)table[i].ProductDiscount,
                                                Photo = table[i].ProductPhoto,
                                                ProductName = table[i].ProductName,
                                                ProductDescription= table[i].ProductDescription,
                                                ProductManufacturer= table[i].ProductManufacturer,
                                                Count = Convert.ToInt32(valuesAmountArray[i]) });

            }
        }
    }
};
