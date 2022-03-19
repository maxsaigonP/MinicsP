using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThucHanh_0306191060.Areas.Admin.Models;

namespace ThucHanh_0306191060.Data
{
    public class ThucHanh_0306191060Context : DbContext
    {
        public ThucHanh_0306191060Context (DbContextOptions<ThucHanh_0306191060Context> options)
            : base(options)
        {
        }

        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ThucHanh_0306191060.Areas.Admin.Models.InvoiceDetail> InvoiceDetail { get; set; }
        public DbSet<ThucHanh_0306191060.Areas.Admin.Models.Invoice> Invoice { get; set; }
        public DbSet<ThucHanh_0306191060.Areas.Admin.Models.Account> Account { get; set; }
        public DbSet<ThucHanh_0306191060.Areas.Admin.Models.Cart> Cart { get; set; }
        public DbSet<ThucHanh_0306191060.Areas.Admin.Models.Rating> Rating { get; set; }
        public DbSet<ThucHanh_0306191060.Areas.Admin.Models.About> About { get; set; }
        public DbSet<ThucHanh_0306191060.Areas.Admin.Models.Comment> Comment { get; set; }
        public DbSet<ThucHanh_0306191060.Areas.Admin.Models.History> History { get; set; }
        public DbSet<ThucHanh_0306191060.Areas.Admin.Models.SlideShow> SlideShow { get; set; }
    }
}
