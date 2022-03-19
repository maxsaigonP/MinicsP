using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThucHanh_0306191060.Areas.Admin.Models;
using ThucHanh_0306191060.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ThucHanh_0306191060.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ThucHanh_0306191060Context _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CustomerController(ThucHanh_0306191060Context context, IWebHostEnvironment webHostEnvironment)
        {

            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Cart()
        {
            if (HttpContext.Session.GetString("role") == null)
            {
                return RedirectToAction("Login", "Home", new { Area = "Admin" });
            }
            int id = int.Parse(HttpContext.Session.GetString("userid"));
            Account user = await _context.Account.FindAsync(id);
            ViewBag.userphone = user.Phone;
            ViewBag.useraddress = user.ShipperAddress;
            ViewBag.stt = 0;

            var lst = await _context.Cart.Include(p => p.Product).Where(c => c.AccountId == id).Where(c => c.Status == false).ToListAsync();

            return View(lst);
        }
        public async Task<IActionResult> CartList()
        {
            if (HttpContext.Session.GetString("role") == null)
            {
                return RedirectToAction("Login", "Home", new { Area = "Admin" });
            }
            int id = int.Parse(HttpContext.Session.GetString("userid"));
            Account user = await _context.Account.FindAsync(id);
            ViewBag.userphone = user.Phone;
            ViewBag.useraddress = user.ShipperAddress;
            ViewBag.userid = HttpContext.Session.GetString("userid");
            HttpContext.Session.SetString("address", user.ShipperAddress);
            List<Invoice> lst = await _context.Invoice.Where(c => c.AccountId == id).Where(c => c.Complete == false).ToListAsync();

            return View(lst);
        }
        public IActionResult Profile()
        {
            if (HttpContext.Session.GetString("role") == null)
            {
                return RedirectToAction("Login", "Home", new { Area = "Admin" });
            }
            int id = int.Parse(HttpContext.Session.GetString("userid"));
            var ac = _context.Account.Find(id);
            ViewBag.phone = ac.Phone;
            ViewBag.username = ac.Username;
            ViewBag.address = ac.ShipperAddress;
            ViewBag.avatar = ac.Avatar;
            ViewBag.email = ac.Email;
            ViewBag.userid = int.Parse(HttpContext.Session.GetString("userid"));

            return View();
        }
        public IActionResult AccountHistory()
        {
            int userid = int.Parse(HttpContext.Session.GetString("userid"));
            var his = _context.History.Include(a => a.Account).Where(h => h.AccountId == userid);

            return View(his);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Account.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
          
            return View(account);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(IFormFile AvatarFile,string Password,string Avatar, string Email,string Phone,string ShipperAddress,int Id)
        {
            Account account = await _context.Account.FindAsync(Id);
            account.Password = Password;
            account.Avatar = Avatar;
            account.Email = Email;
            account.Phone = Phone;
            account.AvatarFile = AvatarFile;
            account.ShipperAddress = ShipperAddress;
            if(account!=null)
            {
                try
                {

                    _context.Update(account);
                    if (AvatarFile != null)
                    {
                        var fileDelete = Path.Combine(_webHostEnvironment.WebRootPath, "images", "account", account.Avatar);
                        FileInfo file = new FileInfo(fileDelete);
                        file.Delete();
                    }

                    if (AvatarFile != null)
                    {
                        var fileName = account.Id.ToString() + Path.GetExtension(AvatarFile.FileName);
                        var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "account");
                        var filePath = Path.Combine(uploadPath, fileName);
                        using (FileStream fs = System.IO.File.Create(filePath))
                        {
                            account.AvatarFile.CopyTo(fs);
                            fs.Flush();
                        }
                        account.Avatar = fileName;
                        _context.Update(account);
                        await _context.SaveChangesAsync();
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }
           

            return View(account);
        }
    }
}
