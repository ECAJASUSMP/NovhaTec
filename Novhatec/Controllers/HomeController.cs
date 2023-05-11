using Microsoft.AspNetCore.Mvc;
using Novhatec.Models;
using System.Diagnostics;

using Novhatec.Servicios;

namespace Novhatec.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var results = await _userService.GetResults();
            return View(results);
        }

        public async Task<IActionResult> Privacy()
        {
            var users = await _userService.GetUsers();
            return View(users);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}