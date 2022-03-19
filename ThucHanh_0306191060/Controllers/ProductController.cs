using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThucHanh_0306191060.Areas.Admin.Models;
using ThucHanh_0306191060.Data;
using Microsoft.AspNetCore.Http;
using PagedList;
using PagedList.Mvc;
namespace ThucHanh_0306191060.Controllers

{
    public class ProductController : Controller
    {
        private readonly ThucHanh_0306191060Context _context;
        public ProductController(ThucHanh_0306191060Context context)
        {
            _context = context;
           
        }
        public async Task<IActionResult> Product()
        {
            var lstProduct = await _context.Products.Include(p => p.ProductType).ToListAsync();
            if (HttpContext.Session.GetString("role") != null)
            {
                int id = int.Parse(HttpContext.Session.GetString("userid"));
            }
            //var lst= await _context.Cart.Where(p => p.AccountId == id).ToListAsync();
            //ViewBag.lstid = await _context.Cart.Where(p => p.AccountId == id).ToListAsync();
            //HttpContext.Session.SetInt32("dem", lst.Count);
            return View( lstProduct);
        }

        public async Task<IActionResult> ProductDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.userid = HttpContext.Session.GetString("userid");
            var product = await _context.Products
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.comment = await _context.Comment.Include(a=>a.Account).Where(c => c.ProductId == id).ToListAsync();
            return View(product);
        }
        public async Task<IActionResult> Search(int? id, string ten, string loai)
        {
            ViewBag.loaisp = await _context.ProductTypes.Include(p => p.Products).ToListAsync();
            if (id == null)
            {
                id = 1;
            }

            int pageSize = 6;
            int pageNumber = (id ?? 1);
            var lst = await _context.Products.Where(p => p.Id == 0).OrderBy(p=>p.Id).ToListAsync();
            if (!String.IsNullOrEmpty(ten))
            {
                var lstsearch = await _context.Products.Where(s => s.Name!.Contains(ten)).OrderBy(p => p.Id).ToListAsync();
                if (id == null)
                {
                    id = 1;
                }

                 pageSize = 6;
                pageNumber = (id ?? 1);
                return View(lstsearch.ToPagedList(pageNumber, pageSize));
            }
            if (!String.IsNullOrEmpty(loai))
            {
                var lstsearch = await _context.Products.Where(s => s.ProductTypeId == int.Parse(loai)).ToListAsync();
                if (id == null)
                {
                    id = 1;
                }

                 pageSize = 6;
                 pageNumber = (id ?? 1);
                return View(lstsearch.ToPagedList(pageNumber, pageSize));
            }
           
            return View(lst.ToPagedList(pageNumber,pageSize));
        }
        //[HttpPost]
        //public async Task<IActionResult> Search(string ten,string loai,int? id)
        //{
        //    ViewBag.loaisp = await _context.ProductTypes.Include(p => p.Products).ToListAsync();
        //    if (!String.IsNullOrEmpty(ten))
        //    {
        //       var lstsearch = await _context.Products.Where(s => s.Name!.Contains(ten)).OrderBy(p=>p.Id).ToListAsync();
        //        if (id == null)
        //        {
        //            id = 1;
        //        }
         
        //        int pageSize = 6;
        //        int pageNumber = (id ?? 1);
        //        return View(lstsearch.ToPagedList(pageNumber, pageSize));
        //    }
        //    if (!String.IsNullOrEmpty(loai))
        //    {
        //        var lstsearch = await _context.Products.Where(s => s.ProductTypeId==int.Parse(loai)).ToListAsync();
        //        if (id == null)
        //        {
        //            id = 1;
        //        }

        //        int pageSize = 6;
        //        int pageNumber = (id ?? 1);
        //        return View(lstsearch.ToPagedList(pageNumber, pageSize));
        //    }
        //    var lst = await _context.Products.Where(p => p.Id == 0).ToListAsync();


        //    return View(lst);
        //}
    }
}
