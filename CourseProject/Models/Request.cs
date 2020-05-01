using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int AccountId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
