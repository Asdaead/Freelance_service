using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class CategoryContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public CategoryContext()
        {
            Database.EnsureCreated();
        }
        public string getNameById(string id)
        {
           return Categories.ToList().Where(x => x.Id == Int64.Parse(id)).First().Name;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1;port=3307;database=freelance;Password=12colombo90;UserId=root;convert zero datetime=True;charset=utf8");
        }
    }
}
