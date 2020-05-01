using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.ViewModels
{
    public class AddRequestModel
    {
        public int OrderId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
