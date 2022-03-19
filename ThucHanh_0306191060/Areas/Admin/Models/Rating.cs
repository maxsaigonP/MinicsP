using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThucHanh_0306191060.Areas.Admin.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int Quantily { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
