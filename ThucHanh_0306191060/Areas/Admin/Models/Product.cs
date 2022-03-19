using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThucHanh_0306191060.Areas.Admin.Models
{
    public class Product
    {
        public int Id { get; set; }

        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage ="Không được bỏ trống")]
        public string Name { get; set; }
        [DisplayName("Mô tả")]
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string Description { get; set; }

        [DisplayName("Giá tiền (VNĐ)")]
        [DisplayFormat(DataFormatString = "{0:#,##0} VNĐ")]
        public int Price { get; set; }
        [DisplayName("Số lượng")]
        public int Quantily { get; set; }

        [DisplayName("Loại sản phẩm")]
        public int ProductTypeId { get; set; }

        [DisplayName("Loại sản phẩm")]
        public ProductType ProductType { get; set; }    
        [DisplayName("Hình ảnh")]
        public string Image { get; set; }

        [NotMapped]
        [DisplayName("Hình ảnh")]
        public IFormFile ImageFile { get; set; }

        public bool Status { get; set; }

        public List<Cart> Carts { get; set; }

        public List<Rating> Ratings { get; set; }

        public List<InvoiceDetail> InvoiceDetails { get; set; }
        public List<Comment> Comments { get; set; }
        public List<SlideShow> SlideShows { get; set; }
    }
}
