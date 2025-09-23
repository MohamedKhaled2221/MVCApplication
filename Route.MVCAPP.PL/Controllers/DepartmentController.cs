using Microsoft.AspNetCore.Mvc;
using Route.MVCAPP.BLL.Services;
using Route.MVCAPP.DAL.Persistence.Repositories.Departments;

namespace Route.MVCAPP.PL.Controllers
{
    #region Part 7 Department Controller - Index
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();

            return View(departments);
        }


    } 
    #endregion
}
