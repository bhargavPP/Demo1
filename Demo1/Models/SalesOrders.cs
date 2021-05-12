using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1.Models
{
    public class SalesOrders
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        public int OrderNumber { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
