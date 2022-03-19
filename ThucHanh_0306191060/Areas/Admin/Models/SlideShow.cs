﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThucHanh_0306191060.Areas.Admin.Models
{
    public class SlideShow
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        public Product Product { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống"),MaxLength(100,ErrorMessage ="Tối đa 100 ký tự")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống"), MaxLength(100, ErrorMessage = "Tối đa 100 ký tự")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string Image { get; set; }

        [NotMapped]
        [DisplayName("Hình ảnh")]
        public IFormFile ImageFile { get; set; }
    }
}
