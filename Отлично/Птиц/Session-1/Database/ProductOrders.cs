//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Session1.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductOrders
    {
        public int ID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public Nullable<int> Count { get; set; }
    
        public virtual Orders Orders { get; set; }
        public virtual Product Product { get; set; }
    }
}
