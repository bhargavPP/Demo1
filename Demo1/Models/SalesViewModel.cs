using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1.Models
{
    public class SalesViewModel
    {
     //   public SalesOrders SalesOrder { get; set; }
        public IEnumerable<SalesOrders> SalesOrders { get; set; }
        public SalesOrderDetails SalesOrderDetails { get; set; }
        
    }
}
