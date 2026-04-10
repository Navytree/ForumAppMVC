using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCForumApp.Data;
using MVCForumApp.Models;

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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User account)
        {
            bool Accountexists = await _context.User.AnyAsync(a => a.Login == account.Login);

            if (Accountexists)
            {
                ModelState.AddModelError("Login", "Nazwa użytkownika jest już zajęta.");
            }


            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Topics");
            }

                return View(account);
        
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User loginData)
        {
            bool Accountexists = await _context.User.AnyAsync(l => l.Login == loginData.Login &&
                l.Password == loginData.Password);

            if (!Accountexists) {
                ModelState.AddModelError("","Login lub hasło nie są poprawne.");    }

            if (ModelState.IsValid) {
                return RedirectToAction("Index", "Topics"); }

            return View(loginData);

        }






    }
}
