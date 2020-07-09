using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppGiamSatMoiTruong.Models;
using WebAppGiamSatMoiTruong.Models.CustomModels;

namespace WebAppGiamSatMoiTruong.Controllers
{
    public class AccountsController : Controller
    {
        private GiamSatMoiTruongDbContext _context;
        public AccountsController(GiamSatMoiTruongDbContext context)
        {
            _context = context;
        }

        // GET: Accounts
        public async Task<IActionResult> Login()
        {
            _context = new GiamSatMoiTruongDbContext();
            return View(await _context.Accounts.ToListAsync());
        }

        [HttpPost]
        public bool isSignIn(string username, string password)
        {
            foreach (var i in _context.Accounts)
            {
                if (username == i.UserName && password == i.Password)
                {
                    return true;
                }
            }
            return false;
        }
        [HttpPost]
        public List<Account> GetAccounts()
        {
            return _context.Accounts.ToList();
        }
        public async Task<IActionResult> ListUser()
        {
            _context = new GiamSatMoiTruongDbContext();
            return View(await _context.Accounts.ToListAsync());
        }
        [HttpGet]
        public JsonResult getAllUser()
        {
            try
            {
                List<Account> li = _context.Accounts.ToList();
                List<AccountShow> list = new List<AccountShow>();
                for (int i = 0; i < li.Count(); i++)
                {
                    AccountShow acs = new AccountShow
                    {
                        UserName = li[i].UserName,
                        FullName = li[i].FullName,
                        PhoneNumber = li[i].PhoneNumber,
                        Email = li[i].Email,
                        Dob = li[i].DOB,
                        Actions = ""
                    };
                    list.Add(acs);
                }
                /* apg.draw = int.Parse(HttpContext.Session.GetString("draw"));*/
                return Json(new { data = list });
            }
            catch 
            {
                return null;
            }
        }
        private bool AccountExists(string id)
        {
            return _context.Accounts.Any(e => e.UserName == id);
        }
    }
}
