using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MBSA.Models;
using MBSA.Models.Interfaces;
using MBSA.Models.DataProvider;

namespace MBSA.Controllers
{
    public class HomeController : Controller
    {
        IProjectRepo projectRepo;
        public HomeController()
        {
            projectRepo = new ProjectRepository();
        }
        public IActionResult Index()
        {
            return View();
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
      
        public JsonResult GetProjects(int PageSize, int PageNumber)
        {
            return new JsonResult(projectRepo.GetProjects(PageSize,PageNumber));
        }
        public int GetTotalRecordCount()
        {
            return projectRepo.GetTotalCount();
        }
    }
}
