using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThucHanh_0306191060.Areas.Admin.Models
{
    public class Account
    {
        public int Id { get; set; }

        
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
         
        public string Phone { get; set; }
        public bool IsAdmin { get; set; }

        public string Avatar { get; set; }
        [NotMapped]
        [DisplayName("Hình ảnh")]
        public IFormFile AvatarFile { get; set; }

        [DisplayName("Địa chỉ giao hàng")]
        public string ShipperAddress { get; set; }

        public bool Status { get; set; }

        public List<Cart> Carts { get; set; }   

        public List<Invoice> Invoices { get; set; }
        public List<Rating> Ratings { get; set; }

        //public List<History> Historys { get; set; }
    }
}
