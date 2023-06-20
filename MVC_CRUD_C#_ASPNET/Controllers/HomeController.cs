using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD_C__ASPNET.Models;
using MVC_CRUD_C__ASPNET.Models.ViewModels;

using System.Diagnostics;

namespace MVC_CRUD_C__ASPNET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MvccrudCAspnetContext _DBContext;

        public HomeController(ILogger<HomeController> logger, MvccrudCAspnetContext context)
        {
            _logger = logger;
            _DBContext = context;
        }

        public IActionResult Index()
        {
            List<User> listaUser = _DBContext.Users.Include(c => c.oPosition).ToList();
            return View(listaUser);
        }

        [HttpGet]
        public IActionResult UserDetail(int idUser)
        {
            UserVM oUserVM = new UserVM()
            {
                oUser = new User(),
                oPositionList = _DBContext.Positions.Select(cargo => new SelectListItem()
                {
                    Text = cargo.Description,
                    Value = cargo.Id.ToString()
                }).ToList()

            };

            if (idUser != 0)
            {
                oUserVM.oUser = _DBContext.Users.Find(idUser);
            }
            return View(oUserVM);
        }

        [HttpPost]
        public IActionResult UserDetail(UserVM oUserVM)
        {
            if (oUserVM.oUser.Id == 0)
            {
                _DBContext.Users.Add(oUserVM.oUser);
            }
            else
            {
                _DBContext.Users.Update(oUserVM.oUser);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        [HttpGet]
        public IActionResult UserDelete(int idUser)
        {

            User oUser = _DBContext.Users.Include(c=>c.oPosition).Where(e=>e.Id == idUser).FirstOrDefault();
            return View(oUser);
        }

        [HttpPost]
        public IActionResult UserDelete(User oUser)
        {
            _DBContext.Users.Remove(oUser);
            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}