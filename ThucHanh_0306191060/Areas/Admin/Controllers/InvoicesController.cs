using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThucHanh_0306191060.Areas.Admin.Models;
using ThucHanh_0306191060.Data;
using PagedList;
using PagedList.Mvc;

namespace ThucHanh_0306191060.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InvoicesController : Controller
    {
        private readonly ThucHanh_0306191060Context _context;

        public InvoicesController(ThucHanh_0306191060Context context)
        {
            _context = context;
        }

        // GET: Admin/Invoices
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Login", "Home");
            }
            var thucHanh_0306191060Context = _context.Invoice.Include(i => i.Account).Where(i=>i.Complete==true);
            return View(await thucHanh_0306191060Context.ToListAsync());
        }
        //GET thong ke doanh thu
        public async Task<IActionResult> ThongKeDoanhThu(int? id)
        {
            if (HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Login", "Home");
            }
            if(id==null)
            {
               id = 1;
            }
            var lst = await _context.Invoice.Include(a=>a.Account).OrderBy(i => i.Id).ToListAsync();
            int pageSize = 5;
            int pageNumber = (id ?? 1);
            ViewBag.lstsp = await _context.Products.ToListAsync();
            var thucHanh_0306191060Context = _context.Invoice.Include(i => i.Account).Where(i => i.Complete == true);
            return View(lst.ToPagedList(pageNumber,pageSize));
        }
        //GET tk theo sp
        public async Task<IActionResult> ThongKeDoanhThuTheoSP(int? id)
        {
            if (HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                id = 1;
            }
            var lst = await _context.InvoiceDetail.Include(p => p.Product).OrderBy(i => i.Id).ToListAsync();
            int pageSize = 5;
            int pageNumber = (id ?? 1);
            ViewBag.lstsp = await _context.Products.ToListAsync();
           
            return View(lst.ToPagedList(pageNumber, pageSize));
        }
        //GET tk top 5?
        public async Task<IActionResult> ThongKeTop()
        {
            var cthd = await _context.InvoiceDetail.Include(h => h.Invoice).Include(p => p.Product).ThenInclude(pt => pt.ProductType).Where(c => c.Invoice.Complete == true).Where(b => b.Status == true).ToListAsync();
            return View(cthd);
        }
        [HttpPost]
        public async Task<IActionResult> ThongKeTop(int top)
        {
            if(top<=0)
            {
                top = 5;
            }
            var cthd = await _context.InvoiceDetail.Include(h => h.Invoice).Include(p => p.Product).ThenInclude(pt => pt.ProductType).Where(c => c.Invoice.Complete == true).Where(b => b.Status == true).ToListAsync();
            for(int i=0;i<=cthd.Count;i++)
            {
                for(int j= i+1;j<cthd.Count;j++)
                {
                    if(cthd[i].Product.Id==cthd[j].Product.Id)
                    {
                        cthd[i].Quantity += cthd[j].Quantity;
                        cthd.RemoveAt(j);
                        --j;
                        continue;
                    }
                }
            }
            var lstResult = cthd.OrderByDescending(m => m.Quantity).Take(top);
            return View(lstResult);
        }
        //POST tk theo sp
        [HttpPost]
        public async Task<IActionResult> ThongKeDoanhThuTheoSP(string idSP,int? id1)
        {
            var lst = await _context.InvoiceDetail.Include(p => p.Product).Where(i => i.ProductId == int.Parse(idSP)).OrderBy(i=>i.Id).ToListAsync();
            ViewBag.lstsp = await _context.Products.ToListAsync();
            if (lst.Count>0)
            {
                var price = lst[0].Product.Price;
                var total1 = lst.Sum(iv => iv.Quantity);
              
                ViewBag.total = total1 * price;
            }
            if (id1 == null)
            {
                id1 = 1;
            }
         
            int pageSize = 100;
            int pageNumber = (id1 ?? 1);
            return View(lst.ToPagedList(pageNumber, pageSize));
        }
        //POST tk theo ngay
        [HttpPost]

        public  IActionResult ThongKeDoanhThu(DateTime startDate,DateTime endDate,int? id1)
        {
           DateTime enddate= endDate.AddDays(1);
            var iv = _context.Invoice.Where(i => i.IssuedDate >= startDate && i.IssuedDate <= enddate).Where(i=>i.Complete==true).OrderBy(i=>i.Id);
            ViewBag.total = iv.Sum(i=>i.Total);
            if (id1 == null)
            {
                id1 = 1;
            }

            int pageSize = 100;
            int pageNumber = (id1 ?? 1);
            return View(iv.ToPagedList(pageNumber, pageSize));
        }
        // GET: Admin/Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
          
            var invoice = await _context.Invoice
                .Include(i => i.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Admin/Invoices/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Set<Account>(), "Id", "Id");
            return View();
        }

        // POST: Admin/Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,AccountId,IssuedDate,ShippingAddress,ShippingPhone,Total,Status")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Set<Account>(), "Id", "Id", invoice.AccountId);
            return View(invoice);
        }

        // GET: Admin/Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Set<Account>(), "Id", "Id", invoice.AccountId);
            return View(invoice);
        }

        // POST: Admin/Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,AccountId,IssuedDate,ShippingAddress,ShippingPhone,Total,Status")] Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Set<Account>(), "Id", "Id", invoice.AccountId);
            return View(invoice);
        }

        // GET: Admin/Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .Include(i => i.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Admin/Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.Invoice.FindAsync(id);
            _context.Invoice.Remove(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoice.Any(e => e.Id == id);
        }
    }
}
