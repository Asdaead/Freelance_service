using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public OrderContext()
        {
            Database.EnsureCreated();
        }
        public string findOrderById(int id)
        {
            var order = Orders.ToList().Where(x => x.Id == id);
            return (!order.Any()) ? "" : order.First().ShortDesc;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1;port=3307;database=freelance;Password=111;UserId=root;convert zero datetime=True;");
        }
    }
}
