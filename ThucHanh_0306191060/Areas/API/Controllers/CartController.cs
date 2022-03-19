using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThucHanh_0306191060.Areas.Admin.Models;
using ThucHanh_0306191060.Data;

namespace ThucHanh_0306191060.Areas.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ThucHanh_0306191060Context _context;
     

        public CartController(ThucHanh_0306191060Context context)
        {

            _context = context;
           
        }
        [HttpGet]

        public string AddCart(int accountID,int productID,int soLuong)
        {
            if(HttpContext.Session.GetString("role")==""|| HttpContext.Session.GetString("role") == null|| HttpContext.Session.GetString("role")=="admin")
            {
                return "Thêm thất bại (admin)";
            }
            var check = _context.Products.Find(productID);
            if(check.Quantily<soLuong)
            {

                return "Hết hàng";
            }
            var cart = _context.Cart.Where(c => c.ProductId == productID).Where(c=>c.AccountId==accountID&&c.Status==false).FirstOrDefault();
            if(cart!=null)
            {
                cart.Quantity += soLuong;
                _context.Update(cart);
                _context.SaveChanges();
                return "Thành công";
            }
            Cart c = new Cart();
            c.AccountId = accountID;
            c.ProductId = productID;
            c.Quantity = soLuong;
            c.Status = false;

            History h = new History();
            DateTime now = DateTime.Now;
            h.AccountId = int.Parse(HttpContext.Session.GetString("userid"));
            h.Time = now;
            var pName = _context.Products.Find(productID);
            h.Action = "Thêm sản phẩm "+pName.Name+" vào giỏ hàng";
            _context.Add(h);
            _context.Add(c);
            _context.SaveChanges();
            return "Thêm sản phẩm thành công";
        }
        [HttpGet]

        public string RemoveCart(int cartID)
        {
            Cart cart = _context.Cart.Find(cartID);
            if (cart != null)
            {
                History h = new History();
                DateTime now = DateTime.Now;
                h.AccountId = int.Parse(HttpContext.Session.GetString("userid"));
                h.Time = now;
                h.Action = "Xoá sản phẩm" + "ra khỏi giỏ hàng";
                _context.Add(h);
                _context.Cart.Remove(cart);
                _context.SaveChanges();
                return "Xoá thành công";
            }
            return "Xoá thất bại";
            
        }
        [HttpGet]

        public string RemoveInvoice(int ivID)
        {
            var iv = _context.Invoice.Where(iv=>iv.Id==ivID&&iv.Status==false).FirstOrDefault();
            var ivd = _context.InvoiceDetail.Where(i => i.InvoiceId == ivID&&i.Status==false).ToList();
            if(iv!=null&&ivd!=null)
            {
                _context.Invoice.Remove(iv);
                foreach(var i in ivd)
                {
                    _context.InvoiceDetail.Remove(i);
                }
                var lstCart = _context.Cart.Where(c => c.AccountId == iv.AccountId).ToList();
                if (lstCart.Count > 0)
                {
                    foreach (var i in lstCart)
                    {
                        _context.Remove(i);
                        _context.SaveChanges();
                    }
                }
                _context.SaveChanges();
                return "Huỷ đơn thành công";
            }
            return "Huỷ đơn thất bại";

        }
        [HttpGet]

        public string EditCart(int cartID,int act)
        {
            Cart cart = _context.Cart.Find(cartID);
            if(cart!=null)
            {
                if (act == 0)
                {
                    cart.Quantity++;
                }
                else
                {
                    if(cart.Quantity==0)
                    {
                        return "TB"; 
                    }
                    cart.Quantity--;
                }
                _context.Cart.Update(cart);
                _context.SaveChanges();
                return "TT";

            }
           
            return "Cập nhật thất bại";

        }
        public int price(int id)
        {
            int gia = 0;
            var sp = _context.Products.Find(id);
            if(sp!=null)
            {
                gia =sp.Price;
                return gia;
            }
            
            return 0;

        }
        [HttpGet]

        public int Total(int accountID)
        {
            int total = 0;
            List<Cart> lst = _context.Cart.Where(c => c.AccountId == accountID&&c.Status==false).ToList();
            if(lst.Count>0)
            {
                foreach (var i in lst)
                {
                    total =total+ price(i.ProductId)*i.Quantity;
                }
                return total;
            }
            return 0;
           
        }
        [HttpGet]

        public string Pay(int accountID, string shippingPhone, int total,string lst)
        {
            DateTime now = DateTime.Now;
            Invoice iv = new Invoice();
            iv.Code = "123";
            iv.AccountId = accountID;
            iv.ShippingAddress = HttpContext.Session.GetString("address");
            iv.ShippingPhone = shippingPhone;
            iv.Total = total;
            iv.IssuedDate = now;
            iv.Status = false;
            iv.Complete = false;
            //
            History h = new History();
   
            h.AccountId = accountID;
            h.Time = now;
            h.Action = "Đặt hàng thành công";
            _context.Add(h);
            _context.Add(iv);
            _context.SaveChanges();


            //
            var a = iv.Id;
            var ivID = _context.Invoice.Where(i => i.AccountId == accountID).FirstOrDefault();
            JArray jsonArray = JArray.Parse(lst);
        
            for(int i=0;i<jsonArray.ToArray().Length;i++)
            {

                InvoiceDetail ivd = new InvoiceDetail();
                JToken token = jsonArray.ToArray()[i]["id"];
                JToken token1 = jsonArray.ToArray()[i]["quantity"];
                JToken token2 = jsonArray.ToArray()[i]["price"];
                JToken token3 = jsonArray.ToArray()[i]["cartid"];
                ivd.InvoiceId = a;
                ivd.ProductId = (int)token;
                ivd.Quantity = (int)token1;
                ivd.UnitPrice = (int)token2;
                ivd.Status = false;
                //
                var p = _context.Products.Find((int)token);
                if(p.Quantily< (int)token1)
                {
                    _context.Remove(iv);
                    return "Không đủ số lượng hàng";
                }
                p.Quantily -= (int)token1;
                var cart = _context.Cart.Find((int)token3);
                cart.Status = true;
                _context.Update(cart);
                _context.Add(ivd);
                
                _context.SaveChanges();
                

            }
            
            return "Đặt hàng thành công";



        }
    
        
        [HttpGet]
        public string Duyet(int ivID)
        {
            Invoice iv = _context.Invoice.Find(ivID);
            if(iv!=null)
            {
                var ivd = _context.InvoiceDetail.Where(ivd => ivd.InvoiceId == ivID).ToList();
                if(ivd!=null)
                {
                    foreach(var i in ivd)
                    {
                        i.Status = true;
                        _context.Update(i);
                    }
                }
                iv.Status = true;
                //
                History h = new History();
                DateTime now = DateTime.Now;
                h.AccountId = int.Parse(HttpContext.Session.GetString("userid"));
                h.Time = now;
                h.Action = "Duyệt đơn hàng "+ivID.ToString();
                _context.Add(h);
                _context.Update(iv);
                _context.SaveChanges();
            }
            

            return "Duyệt đơn thành công";


        }
        [HttpGet]
        public string XacNhan(int ivID, int accountID)
        {
            Invoice iv = _context.Invoice.Find(ivID);
            if (iv != null)
            {
                History h = new History();
                DateTime now = DateTime.Now;
                h.AccountId = int.Parse(HttpContext.Session.GetString("userid"));
                h.Time = now;
                h.Action = "Đã nhận được đơn hàng "+ivID.ToString();
                _context.Add(h);
                //
                iv.Complete = true;
                _context.Update(iv);
                _context.SaveChanges();
            }
            var lstCart = _context.Cart.Where(c => c.AccountId == accountID).ToList();
            if(lstCart.Count>0)
            {
                foreach(var i in lstCart)
                {
                    _context.Remove(i);
                    _context.SaveChanges();
                }
            }
            return "Xác nhận thành công";


        }
        
        [HttpGet]
        public IActionResult CheckLogin()
        {

            return RedirectToAction("Login", "Home");
        }

    }



}

