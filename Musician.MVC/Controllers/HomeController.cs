using Microsoft.AspNetCore.Mvc;
using Musician.Business.Abstract;
using Musician.Entity.Concrete;
using Musician.MVC.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace Musician.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITeacherService _teacherService;

        public HomeController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        public async Task<IActionResult> Index()
        {
            List<Teacher> teachers = await _teacherService

            return View();
        }

    }
}