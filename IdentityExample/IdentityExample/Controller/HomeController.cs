using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityExample.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityExample.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private ApplicationContext _context;
        public HomeController(ApplicationContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }
        /*Yetkisi olmayan kişilerin sayfaya erişmemesi için Authorize tagi kullanıldı*/
        [Authorize]
        public ActionResult Employees()
        {
            var employeeList = _context.Employees.Where(p => !p.IsDeleted).ToList();
            ViewData["Title"] = "Employee List";
            return View(employeeList);
        }

       
    }
}