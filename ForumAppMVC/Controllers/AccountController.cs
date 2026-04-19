using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MVCForumApp.Data;
using MVCForumApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVCForumApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly MVCForumAppContext _context;

        public AccountController(MVCForumAppContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Login,Password")] User account)
        {
            bool Accountexists = await _context.User.AnyAsync(a => a.Login == account.Login);

            if (Accountexists)
            {
                ModelState.AddModelError("Login", "User name was already taken");
            }


            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                HttpContext.Session.SetInt32("UserId", account.Id);
                HttpContext.Session.SetString("UserLogin", account.Login);
                return RedirectToAction("Index", "Topics");
            }

            return View(account);
        
        }

        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string login, string password)
        {
            bool Accountexists = await _context.User.AnyAsync(l => l.Login == login &&
                l.Password == password);

            if (!Accountexists) {
                ModelState.AddModelError("","Username or password are not correct");    }

            if (ModelState.IsValid) {
                var user = await _context.User.FirstOrDefaultAsync(u => u.Login == login);
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("UserLogin", user.Login);
                return RedirectToAction("Index", "Topics"); }

            return View();

        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }




    }
}
