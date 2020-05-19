using CourseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.ViewModels
{
    public class SearchModel
    {
        public IEnumerable<Order> allOrders { get; set; }

        public string SearchString { get; set; }
    }
}
