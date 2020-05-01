using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class RequestContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }
        AccountContext accountContext = new AccountContext();
        OrderContext orderContext = new OrderContext();
        public RequestContext()
        {
            Database.EnsureCreated();
        }
        public IEnumerable<Request> getAccountRequests(string login)
        {
            var accountId = accountContext.findIdByLogin(login);
            var requests = Requests.ToList().Where(x => x.AccountId == accountId);
            return requests;
        }
        public IEnumerable<Request> getOrdersRequest(string login)
        {
            var accountId = accountContext.findIdByLogin(login);
            var accountOrders = orderContext.Orders.ToList().Where(x => x.AccountId == accountId);
            IEnumerable<Request> allOrdersRequests = new List<Request>();
            foreach (var order in accountOrders)
            {
                IEnumerable<Request> orderRequests = Requests.ToList().Where(x => x.AccountId == order.Id);
                allOrdersRequests = allOrdersRequests.Concat(orderRequests).ToList();
            }
            return allOrdersRequests.OrderByDescending(x => x.Date);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1;port=3307;database=freelance;Password=111;UserId=root;convert zero datetime=True;");
        }
    }
}
