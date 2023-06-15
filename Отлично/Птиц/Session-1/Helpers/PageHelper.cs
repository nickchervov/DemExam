using Session1.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Session1.Helpers
{
    internal class PageHelper
    {

         
        public static Frame MainFrame;
        public static TextBlock PageName;
        public static DatabaseEntities ConnectDB = new DatabaseEntities();
        public static Button BucketAccess;
        public static int AccessId;

    }
}
