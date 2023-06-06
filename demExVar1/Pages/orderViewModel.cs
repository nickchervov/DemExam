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
                int productIdValue = table[i].ProductID;

                int productCostValue = table[i].ProductCost;

                double productDiscountValue = (double)table[i].ProductDiscount;

                string productNameValue = table[i].ProductName;

                string productDescrValue = table[i].ProductDescription;

                string productManufValue = table[i].ProductManufacturer;  
                
                string productPhotoUrlValue = table[i].ProductPhoto;

                string[] subItems = new string[]
                {
                    $"{productPhotoUrlValue}",
                    $"Наименование товара: {productNameValue}\n" +
                    $"Описание товара: {productDescrValue}\n" +
                    $"Производитель: {productManufValue}\n" +
                    $"Цена: {productCostValue}\n",
                    $"{valuesAmountArray[i]}"
                };

                ordPrd.Add(new orderProduct() { Id = productIdValue, Price= productCostValue, Discount= productDiscountValue, Photo = subItems[0], Product = subItems[1], Count = Convert.ToInt32(subItems[2]) });

            }
        }
    }
};
