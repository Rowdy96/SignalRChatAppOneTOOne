using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalRChatApp.Models;

namespace SignalRChatApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ChatAppContext _context;
        private UserManager<Users> _userManager { get; set; }
        public HomeController(ChatAppContext context, UserManager<Users> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserList()
        {
            var username = User.Identity.Name;
            Users user = await _userManager.FindByNameAsync(username);
            List<Users> users = _context.Users.Where(u=> u.Id!=user.Id).ToList();
            return View(users);
        }
        public IActionResult Chatbox([FromRoute]string id)
        {
            Users user = _context.Users.Find(id);
            return View(user);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
