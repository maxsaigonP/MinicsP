using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ThucHanh_0306191060.Models;
using ThucHanh_0306191060.Areas.Admin.Models;
using ThucHanh_0306191060.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
namespace ThucHanh_0306191060.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ThucHanh_0306191060Context _context;
     
        public HomeController(ILogger<HomeController> logger, ThucHanh_0306191060Context context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var lstl = await _context.ProductTypes.Take(3).ToListAsync();
          
            var lst = await _context.Products.ToListAsync();
            var lsts = await _context.SlideShow.ToListAsync();
            ViewBag.slideshow = lsts;
            var lstloai1 = await _context.Products.Where(p => p.ProductTypeId == lstl[0].Id).ToListAsync();
            var lstloai2 = await _context.Products.Where(p => p.ProductTypeId == lstl[1].Id).ToListAsync();
            var lstloai3 = await _context.Products.Where(p => p.ProductTypeId == lstl[2].Id).ToListAsync();
            ViewBag.lstloai1 = lstloai1;
            ViewBag.lstloai2 = lstloai2;
            ViewBag.lstloai3 = lstloai3;
            ViewBag.name1 = lstl[0].Name;
            ViewBag.name2 = lstl[1].Name;
            ViewBag.name3 = lstl[2].Name;
            return View(lst);
        }
        public IActionResult Testimonial()
        {
            return View();
        }
        public IActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DangKy(string username,string password,string email,string phone,string shipperaddress)
        {
            Account ac = new Account();
            ac.Username = username;
            ac.Password = password;
            ac.Email = email;
            ac.Phone = phone;
            ac.IsAdmin = false;
            ac.Avatar="noavatar.png";
            ac.Status = true;
            ac.ShipperAddress = shipperaddress;
            _context.Add(ac);
            _context.SaveChanges();
            return RedirectToAction("Login", "Home", new { Area = "Admin" });
        }
        public IActionResult Why()
        {
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
