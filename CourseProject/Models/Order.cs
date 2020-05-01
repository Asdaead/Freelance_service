using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class Order
    {
        public int Id { set; get; }
        public string ShortDesc { set; get; }
        public string LongDesc { set; get; }
        public string Price { set; get; }
        public int AccountId { set; get; }
        public DateTime Date { set; get; }
        public string CategoryId { set; get; }
    }
}
