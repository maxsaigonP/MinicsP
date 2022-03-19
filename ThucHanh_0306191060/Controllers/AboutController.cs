using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThucHanh_0306191060.Data;

namespace ThucHanh_0306191060.Controllers
{
    public class AboutController : Controller
    {
        private readonly ThucHanh_0306191060Context _context;

        public AboutController(ThucHanh_0306191060Context context)
        {

            _context = context;
        }
        public async Task<IActionResult> About()
        {
           
            return View();
        }
    }
}
