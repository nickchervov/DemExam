using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace demExVar1.Pages
{
    public class orderProduct
    {
        private int id;
        private int price;
        private double discount;
        private string photo;
        private string productName;
        private string productDescription;
        private string productManufacturer;
        private int count;

        public int Id
        {
            get { return id; }

            set { id = value; }
        }

        public int Price
        {
            get { return price; }

            set { price = value; }
        }

        public double Discount
        {
            get { return discount; }

            set { discount = value; }
        }

        public string Photo
        {
            get { return photo; }
            set
            {
                photo = value;
            }
        }
        public string ProductName
        {
            get { return productName; }
            set
            {
                productName = value;
            }
        }

        public string ProductDescription
        {
            get { return productDescription; }

            set { productDescription = value; }
        }

        public string ProductManufacturer
        {
            get { return productManufacturer; }

            set { productManufacturer = value; }
        }

        public int Count
        {
            get { return count; }
            set
            {
                count = value;
            }
        }
    }
}
