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
            /*for(int i = 0; i <= 20; i++)
            {
                Account acc = new Account()
                {
                    UserName = "Stringyyyy" + i,
                    Password = "123",
                    FullName = "Quan ML" + i,
                    DOB = DateTime.Now,
                    Email = "QuanML" + i + "@gmail.com",
                    PhoneNumber = "123123",
                    Active = true
                };
                _context.Accounts.Add(acc);
                _context.SaveChanges();
            }*/
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

                /*  int length = int.Parse(HttpContext.Session.GetString("length"));
                  int start = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(int.Parse(HttpContext.Session.GetString("start")) / length))) + 1;
                  string searchValue = HttpContext.Session.GetString("search[value]");
                  string sortColumnName = HttpContext.Session.GetString("columns[" + HttpContext.Session.GetString("order[0][column]") + "][name]");
                  string sortDirection = HttpContext.Session.GetString("order[0][dir]");

                  AccountPaging apg = new AccountPaging();
                  apg.data = new List<AccountShow>();
                  start = (start - 1) * length;
                  List<Account> listAccount = _context.Account.ToList<Account>();
                  apg.recordsTotal = listAccount.Count;
                  //filter
                  if (!string.IsNullOrEmpty(searchValue))
                  {
                      listAccount = listAccount.Where(x => x.UserName.ToLower().Contains(searchValue.ToLower()) ||
                          x.Email.ToLower().Contains(searchValue.ToLower()) ||
                          x.FullName.ToLower().Contains(searchValue.ToLower()) ||
                          x.PhoneNumber.ToLower().Contains(searchValue.ToLower())
                      ).ToList<Account>();
                  }
                  //sorting
                  if (sortColumnName.Equals("Role"))
                  {
                      //sort UTF 8
                      sortColumnName = "RoleID";
                  }
                  *//*listAccount = listAccount.OrderBy(sortColumnName + " " + sortDirection).ToList<Account>();*//*
                  //}
                  apg.recordsFiltered = listAccount.Count;
                  //paging
                  listAccount = listAccount.Skip(start).Take(length).ToList<Account>();*/
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
            catch (Exception ex)
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
