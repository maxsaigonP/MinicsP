using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThucHanh_0306191060.Areas.Admin.Models
{
    public class About
    {
        public int Id { get; set; }
        
        public string title { get; set; }
        public string description { get; set; }
        public string content { get; set; }
    }
}
