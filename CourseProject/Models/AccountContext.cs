using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public AccountContext()
        {
            Database.EnsureCreated();
        }
        public int findIdByLogin(string login)
        {
            var account = Accounts.ToList().Where(x => x.Login == login);
            return (!account.Any())? 0 : account.First().Id;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1;port=3307;database=freelance;Password=111;UserId=root;convert zero datetime=True;");
        }
    }
}
