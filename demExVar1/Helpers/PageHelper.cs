using demExVar1.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace demExVar1.Helpers
{
    internal class PageHelper
    {
        public static int roleId;

        public static int UserId;

        public static TextBlock PageName;

        public static Frame MainFrame;

        public static double orderSum;

        public static double orderDiscount;

        public static Dictionary<int, int> Order = new Dictionary<int, int>();

        public static bookShopDbEntities connectDb = new bookShopDbEntities();
    }
}
