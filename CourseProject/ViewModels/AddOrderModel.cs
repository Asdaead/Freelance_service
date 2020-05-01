using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.ViewModels
{
    public class AddOrderModel
    {
        public int OrderId { get; set; }
        public string CategoryId { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string Price { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
