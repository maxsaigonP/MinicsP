using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThucHanh_0306191060.Areas.Admin.Models;
using ThucHanh_0306191060.Data;

namespace ThucHanh_0306191060.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        private readonly ThucHanh_0306191060Context _context;

        public HomeController(ILogger<HomeController> logger, ThucHanh_0306191060Context context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
        
            List<Account> lst = await _context.Account.ToListAsync();
            if (lst.Count != 0)
            {
                foreach (var i in lst)
                {
                    if (i.Username == username && i.Password == password)
                    {
                        if (i.IsAdmin == true)
                        {
                            HttpContext.Session.SetString("role", "admin");
                            HttpContext.Session.SetString("userid", i.Id.ToString());
                            HttpContext.Session.SetString("address", i.ShipperAddress);
                            HttpContext.Session.SetString("username", i.Username);
                            HttpContext.Session.SetString("avatar", i.Avatar);
                            //his
                            //his
                            History h = new History();
                            DateTime now = DateTime.Now;
                            h.AccountId = int.Parse(HttpContext.Session.GetString("userid"));
                            h.Time = now;
                            h.Action = "Đăng nhập thành công";
                            _context.Add(h);
                            _context.SaveChanges();
                            return RedirectToAction("Index", "Accounts", new { Area = "Admin" });
                        }
                        else
                        {
                            HttpContext.Session.SetString("role", "user");
                            HttpContext.Session.SetString("username", i.Username);
                            HttpContext.Session.SetString("userid", i.Id.ToString());
                            HttpContext.Session.SetString("address", i.ShipperAddress);
                            //his
                            History h = new History();
                            DateTime now = DateTime.Now;
                            h.AccountId = int.Parse(HttpContext.Session.GetString("userid"));
                            h.Time = now;
                            h.Action = "Đăng nhập thành công";
                            _context.Add(h);
                            _context.SaveChanges();
                            return RedirectToAction("Index", "Home", new { Area = "" });
                        }
                    }
                }

            }

            return View();
        }
        public async Task<IActionResult> Logout()
        {
            //his
            History h = new History();
            DateTime now = DateTime.Now;
            h.AccountId = int.Parse(HttpContext.Session.GetString("userid"));
            h.Time = now;
            h.Action = "Đăng xuất thành công";
            _context.Add(h);
            _context.SaveChanges();
            HttpContext.Session.SetString("role", "");
            HttpContext.Session.SetString("userid", "");
            HttpContext.Session.SetString("address", "");
            HttpContext.Session.SetString("username", "");
            return RedirectToAction("login", "home", new { Area = "Admin" });

            
        }
        public async Task<IActionResult> ThongKe()
        {
            return View();


        }
    }
}
