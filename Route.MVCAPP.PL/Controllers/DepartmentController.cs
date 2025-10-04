using System.Reflection.Metadata.Ecma335;
using System.Security.Policy;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Route.MVCAPP.BLL.DTOs;
using Route.MVCAPP.BLL.DTOs.Departments;
using Route.MVCAPP.BLL.Services.Departments;
using Route.MVCAPP.DAL.Models.Departments;
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
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentService departmentService,
            ILogger<DepartmentController> logger,
            IWebHostEnvironment environment , IMapper mapper)
        {
            _departmentService = departmentService;
            _logger = logger;
            _environment = environment;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //#region Part 5 View Data and View Bag
            //ViewData["obj"] = "Hello From View Data";
            //ViewBag.obj2 = "Hello From View Bag"; 
            //#endregion
            var departments = await _departmentService.GetAllDepartmentsAsync();

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
        public async  Task<IActionResult> Create(DepartmentViewModel departmentVM)
        {
            if (!ModelState.IsValid) //Server Side Validation
            {
                return View(departmentVM);
            }
            var message = string.Empty;

            try
            {
                var CreatedDepartment = _mapper.Map<DepartmentViewModel, CreatedDepartmentDto>(departmentVM);

                //var CreatedDepartmentDto = new CreatedDepartmentDto()
                //{
                //    Code = departmentVM.Code,
                //    Name = departmentVM.Name,
                //    Description = departmentVM.Description,
                //    CreationDate = departmentVM.CreationDate
                //};
                var result =await _departmentService.CreateDepartmentAsync(CreatedDepartment);
                #region Part 6 Temp Data
                if (result > 0)
                {
                    TempData["Message"] = "Department Created Successfully :)";

                }
                else
                {
                    TempData["Message"] = "Failed to Create Department";
                    ModelState.AddModelError(string.Empty, message);

                } 
                #endregion
                return RedirectToAction("Index");
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
        #region Part 9 Department Controller - Details
        public async Task<IActionResult> Details(int? id)

        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            var department =await _departmentService.GetDepartmentByIdAsync(id.Value);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }


        #endregion
        #region Part 1 Department Controller - Edit 
        [HttpGet]

        public async  Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue )
            {
                return BadRequest(); //400
            }
            var department =await _departmentService.GetDepartmentByIdAsync(id.Value);
            if (department == null)
            {
                return NotFound(); //404

            }
            var departmentVM = _mapper.Map<DepartmentDetailsDto,DepartmentViewModel>(department);
            //return View(new DepartmentViewModel()
            //{

            //    Code = department.Code,
            //    Name = department.Name,
            //    Description = department.Description,
            //    CreationDate = department.CreationDate
            //});
            return View(departmentVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int id, DepartmentViewModel departmentVM)
        {
            if (!ModelState.IsValid)
            {
                return View(departmentVM);
            }
            var message = string.Empty;
            try
            {
                var UpdateDepartment = _mapper.Map<DepartmentViewModel, UpdatedDepartmentDto>(departmentVM);

                //var UpdateDepartment = new UpdatedDepartmentDto()
                //{
                //    Id = id,
                //    Code = departmentVM.Code,
                //    Name = departmentVM.Name,
                //    Description = departmentVM.Description,
                //    CreationDate = departmentVM.CreationDate
                //};
                var Updated = await _departmentService.UpdateDepartmentAsync(UpdateDepartment) > 0;
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

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var message = string.Empty;
            try
            {
                var deleted =await _departmentService.DeleteDepartmentAsync(id) ;

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
