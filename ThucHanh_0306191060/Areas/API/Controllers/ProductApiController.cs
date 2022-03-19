using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ProductApiController : ControllerBase
    {
        private readonly ThucHanh_0306191060Context _context;


        public ProductApiController(ThucHanh_0306191060Context context)
        {

            _context = context;

        }
        [HttpGet]

        public string AddComment(string content,int accountID,int rating,int productID)
        {
            DateTime now = DateTime.Now;
            Comment cmt = new Comment();
            cmt.Content = content;
            cmt.AccountId = accountID;
            cmt.Status = true;
            cmt.Time = now;
            cmt.ProductId = productID;
            //
            Rating rt = new Rating();
            rt.Quantily = rating;
            rt.ProductId = productID;
            rt.AccountId = accountID;
            _context.Add(rt);

            _context.Add(cmt);
            _context.SaveChanges();
            return "Thanh cong";
        }
    }
}
