using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1.Models
{
    public class SalesOrderDetails
    {
        [Key]
        [Column(Order =2)]
        [ForeignKey("SalesOrders")]

        public int OrderID { get; set; }

        [Key]
        [Column(Order = 3)]
        public int Sequence { get; set; }
        [MaxLength(200, ErrorMessage = "Maximum allwoed character is 200.")]
        [Required]

        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        public SalesOrders SalesOrders { get; set; }

    }
}
