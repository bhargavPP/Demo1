using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo1.Models;

namespace Demo1.DbContext
{
    public class Demo1DbContext : IdentityDbContext
    {
        public Demo1DbContext(DbContextOptions<Demo1DbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesOrderDetails>().HasKey(s => new { s.OrderID, s.Sequence });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<SalesOrders> SalesOrder { get; set; }
        public DbSet<SalesOrderDetails> SalesOrderDetail { get; set; }
    }
}
