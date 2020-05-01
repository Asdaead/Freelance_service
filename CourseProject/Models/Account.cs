using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class Account
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Login { get; set; }
        public string Password { set; get; }
    }
}
