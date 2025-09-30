using System.Reflection.Metadata.Ecma335;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Route.MVCAPP.BLL.DTOs;
using Route.MVCAPP.BLL.DTOs.Departments;
using Route.MVCAPP.BLL.Services.Departments;
using Route.MVCAPP.DAL.Persistence.Repositories.Departments;
using Route.MVCAPP.PL.ViewModels.Departments;

namespace Route.MVCAPP.PL.Controllers
{
    #region Part 7 Department Controller - Index
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IWebHostEnvironment _environment;

        public DepartmentController(IDepartmentService departmentService, ILogger<DepartmentController> logger, IWebHostEnvironment environment)
        {
            _departmentService = departmentService;
            _logger = logger;
            _environment = environment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();

            return View(departments);
        }
        #endregion
        #region Part 8 Department Controller - Create
        [HttpGet]
        public IActionResult Create(int id)
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentViewModel departmentVM)
        {
            if (!ModelState.IsValid) //Server Side Validation
            {
                return View(departmentVM);
            }
            var message = string.Empty;

            try
            {
                var CreatedDepartmentDto = new CreatedDepartmentDto()
                {
                    Code = departmentVM.Code,
                    Name = departmentVM.Name,
                    Description = departmentVM.Description,
                    CreationDate = departmentVM.CreationDate
                };
                var result = _departmentService.CreateDepartment(CreatedDepartmentDto);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    message = "Failed to Create Department";
                    ModelState.AddModelError(string.Empty, message);
                    return View(departmentVM);
                }
            }
            catch (Exception ex)
            {
                //1- Log Exception
                _logger.LogError(ex, ex.Message);
                //2- Set Message for User
                if (_environment.IsDevelopment())
                {
                    message = ex.Message;
                    return View(departmentVM);
                }
                else
                {
                    message = "Department is not Created";
                    return View("Error", message);
                }

            }
        }
        #endregion
        #region Part 9 Department Controller - Details
        public IActionResult Details(int? id)

        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }


        #endregion
        #region Part 1 Department Controller - Edit 
        [HttpGet]

        public IActionResult Edit(int? id)
        {
            if (!id.HasValue )
            {
                return BadRequest(); //400
            }
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department == null)
            {
                return NotFound(); //404

            }
            return View(new DepartmentViewModel()
            {
              
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreationDate = department.CreationDate
            });
        }
        [HttpPost]
        public IActionResult Edit([FromRoute] int id, DepartmentViewModel departmentVM)
        {
            if (!ModelState.IsValid)
            {
                return View(departmentVM);
            }
            var message = string.Empty;
            try
            {
                var UpdateDepartment = new UpdatedDepartmentDto()
                {
                    Id = id,
                    Code = departmentVM.Code,
                    Name = departmentVM.Name,
                    Description = departmentVM.Description,
                    CreationDate = departmentVM.CreationDate
                };
                var Updated = _departmentService.UpdateDepartment(UpdateDepartment) > 0;
                if (Updated)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    message = "An Error Has been Occured :(";
                    
                }
            }
            catch (Exception ex)
            {
                //1- Log Exception
                _logger.LogError(ex, ex.Message);
                //2- Set Message for User

                message = _environment.IsDevelopment() ? ex.Message : "An Error Has been Occured :(";
            }
            ModelState.AddModelError(string.Empty, message);
            return View(departmentVM);
        }
        #endregion
        #region Part 2 Department Controller - Delete
        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (!id.HasValue || id <= 0)
        //    {
        //        return BadRequest();
        //    }
        //    var department = _departmentService.GetDepartmentById(id.Value);
        //    if (department == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(department);
        //}
        [HttpPost]
        public IActionResult Delete([FromRoute]int id)
        {
            var message = string.Empty;
            try
            {
                var deleted = _departmentService.DeleteDepartment(id) ;

                if (deleted)
                {
                    return RedirectToAction(nameof(Index));
                }
                message = "An Error Has been Occured :(";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                message = _environment.IsDevelopment() ? ex.Message : "An Error Has been Occured :(";
            }
            return RedirectToAction(nameof(Delete), new { id });
        }

        #endregion








    }
    }
