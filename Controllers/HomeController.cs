using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheWaterProject.Models;
using TheWaterProject.Models.ViewModels;

namespace TheWaterProject.Controllers
{
    public class HomeController : Controller
    {
        private IWaterRepository _repo;


        public HomeController(IWaterRepository context)
        {
            _repo = context;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 5;

            var Blah = new ProjectsListViewModel
            {
                Projects = _repo.Projects //Pagingation = Showing a limited number of rows per page
                .OrderBy(x => x.ProjectName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Projects.Count()
                }
            };
            return View(Blah);
        }
    }
}
